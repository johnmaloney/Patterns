using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Patterns.PipesFilter.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace PatternsTests
{
    [TestClass]
    public class PPipelineTests
    {
        [TestMethod]
        public async Task assemble_parallel_pipe_expect_proper_completion()
        {
            var context = new DataResultContext();

            var parentPipe = new MockParaParentPipe()
                .CombineWith(new MockDataRetrievalPipe("FIRST", 100))
                .CombineWith(new MockDataRetrievalPipe("SECOND", 200))
                .CombineWith(new MockDataRetrievalPipe("THIRD", 300))
                .CombineWith(new MockDataRetrievalPipe("FOURTH", 400))
                .CombineWith(new MockDataRetrievalPipe("FIFTH", 450))
                .ExtendWith(new MockDummyPipe());

            await parentPipe.Process(context);

            Assert.AreEqual(5, context.Results.Count);

            var timedPipe = parentPipe as MockParaParentPipe;

            // This check is to ensure that all five tasks ran asynchronously //
            // Each one had a time between 100 and 450 milliseconds If all ran in parallel //
            // the elapsed time should never be above 500ms eventhough the summary is well above that // 
            Assert.IsTrue(timedPipe.Time <= 515);
        }
    }

    public class DataResultContext : IPipeContext
    {
        public Dictionary<string, string> Results { get; set; }

        public DataResultContext()
        {
            this.Results = new Dictionary<string, string>();
        }
    }

    internal class MockParaParentPipe : AParallelPipe, IParallelPipe
    {
        public long Time { get; set; }

        public override async Task Process(IPipeContext context)
        {
            var timer = Stopwatch.StartNew();

            // The idea here is that the parallel processes should execute //
            // prior to this pipe executing its items //
            await this.ProcessAll(context);

            Time = timer.ElapsedMilliseconds;

            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }

    internal class MockDataRetrievalPipe : AParallelPipe, IParallelPipe
    {
        private readonly int delayTime;

        public string Name { get; private set; }

        public MockDataRetrievalPipe(string name, int delay)
        {
            this.Name = name;
            this.delayTime = delay;
        }

        public override async Task Process(IPipeContext context)
        {
            var knownContext = context as DataResultContext;

            lock (knownContext)
            {
                knownContext.Results.Add(this.Name, delayTime.ToString());
            }

            await Task.Delay(delayTime);

            // The idea here is that the parallel processes should execute //
            // prior to this pipe executing its items //
            await this.ProcessAll(context);

            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }

    }

    internal class MockDummyPipe : APipe, IPipe
    {
        public override async Task Process(IPipeContext context)
        {
            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }
}

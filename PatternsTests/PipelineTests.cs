using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Patterns.PipesFilter.Interfaces;

namespace PatternsTests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void generate_a_tree_based_pipeline_expect_proper_execution()
        {
            var context = new MathPipeContext(initialValue: 20);

            var masterPipe = new AdditionPipe()
                .ExtendWith(
                    new SubtractionPipe()
                    .ExtendWith(new SubtractionPipe())
                    .ExtendWith(new SubtractionPipe())
                )
                .ExtendWith(
                    new AdditionPipe()
                    .ExtendWith(new AdditionPipe())
                    .ExtendWith(
                        new AdditionPipe()
                        .ExtendWith(new MultiplicationPipe())
                    )
                )
                .ExtendWith(new SubtractionPipe());

            masterPipe.Process(context);

            // 20 + 1 = 21: 
            // 21 -1 - 1 - 1 = 18
            // 18 + 1 + 1 + 1 = 21
            // 21 * 2 = 42
            // 42 - 1 = 41
            Assert.AreEqual(41, context.Result);
        }

        [TestMethod]
        public void setup_pipe_line_with_null_expect_null_return()
        {
            var context = new MathPipeContext(initialValue: 20);

            var masterPipe = new AdditionPipe()
                .ExtendWith(new SubtractionPipe());

            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                    Assert.IsNotNull(masterPipe.NextPipe);
                else
                    Assert.IsNull(masterPipe.NextPipe);
            }
        }
    }

    #region Mock Pipes

    internal class MathPipeContext : IPipeContext
    {
        public int Result { get; set; }

        public MathPipeContext(int initialValue)
        {
            this.Result = initialValue;
        }
    }

    internal class AdditionPipe : APipe
    {
        public override async Task Process(IPipeContext context)
        {
            var data = context as MathPipeContext;
            if (data != null)
            {
                data.Result++;
            }

            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }

    internal class SubtractionPipe : APipe
    {
        public override async Task Process(IPipeContext context)
        {
            var data = context as MathPipeContext;
            if (data != null)
            {
                data.Result--;
            }

            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }

    internal class MultiplicationPipe : APipe
    {
        public override async Task Process(IPipeContext context)
        {
            var data = context as MathPipeContext;
            if (data != null)
            {
                data.Result = data.Result * 2;
            }

            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }

    internal class DivisionPipe : APipe
    {
        public override async Task Process(IPipeContext context)
        {
            while (this.HasNextPipe)
                await this.NextPipe.Process(context);
        }
    }

    #endregion
}

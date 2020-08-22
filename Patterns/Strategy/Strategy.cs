using Patterns.Strategy.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
    public enum As
    {
        Default=0,
        v1=1,
        v2=2,
        v3=3,
        v4=4
    }

    public static class Strategy
    {
        // This structure defined the types of strategy interfaces as the parent container // 
        // and then the versions of strategy instances inside that parent group //
        // Here is an example set //
        // [0] : IStringSearch ==> { v1:StringSearch, v2:TreeSearch, v3:MockSearch } //
        private static ConcurrentDictionary<Type, ConcurrentDictionary<As, IStrategy>> domainStrategies;

        internal static ConcurrentDictionary<Type, ConcurrentDictionary<As, IStrategy>> DomainStrategies
        {
            get
            {
                if (Strategy.domainStrategies == null)
                    Strategy.domainStrategies = Strategy.DefineStrategyStore();

                return Strategy.domainStrategies;
            }
        }
        
        public static T For<T>(As version = As.Default) where T : class, IStrategy
        {
            ConcurrentDictionary<As, IStrategy> versionedContainer;

            if (Strategy.DomainStrategies.TryGetValue(typeof(T), out versionedContainer))
            {
                if (versionedContainer.TryGetValue(version, out IStrategy versionedPolicy))
                {
                    return versionedPolicy as T;
                }
                else
                    throw new NotSupportedException($"The strategy version : {version} of {typeof(T)} was not in the container.");
            }
            else
                throw new ApplicationException($"The strategy of type {typeof(T)} was not available in the container.");
        }

        internal static ConcurrentDictionary<Type, ConcurrentDictionary<As, IStrategy>> DefineStrategyStore()
        {
            var strategyStore = new ConcurrentDictionary<Type, ConcurrentDictionary<As, IStrategy>>();
            return strategyStore;
        }

        public static void AddStrategy<T>(T policyInstance, As version = As.Default) where T : IStrategy
        {
            if (Strategy.DomainStrategies.ContainsKey(typeof(T)))
            {
                var versionedContainer = Strategy.DomainStrategies[typeof(T)];
                if (versionedContainer.ContainsKey(version))
                {
                    throw new NotSupportedException($"Adding a strategy implementation of the type : {typeof(T)} at version : {version} is not allowed when it is already in the container.");
                }
                else
                {

                    versionedContainer.AddOrUpdate(version, policyInstance,
                    (key, versionedStrategy) =>
                    {
                        versionedStrategy = policyInstance;
                        return versionedStrategy;
                    });
                }
            }
            else // The Type Container was not found, we need to create a new one //
            {
                var strategyVersionContainer = new ConcurrentDictionary<As, IStrategy>();
                strategyVersionContainer.TryAdd(version, policyInstance);

                Strategy.DomainStrategies.TryAdd(typeof(T), strategyVersionContainer);
                
            }
            
        }
    }
}

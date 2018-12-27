using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoIdentity.Utilities
{
    public static class MockHelper
    {
        public static List<double> GetRandomValueCollection(Random rand, double desiredTotal, int partitions)
        {
            // calculate the weights
            var weights = new List<double>();
            for (int i = 0; i < partitions; i++)
            {
                weights.Add(rand.NextDouble());
            }
            var totalWeight = weights.Sum();

            var result = new List<double>();
            double allocatedWeight = 0;
            double allocatedCount = 0;
            foreach (var weight in weights)
            {
                var newAllocatedWeight = allocatedWeight + weight;
                var newAllocatedCount = (double)(desiredTotal * (newAllocatedWeight / totalWeight));
                var thisAllocatedCount = newAllocatedCount - allocatedCount;
                allocatedCount = newAllocatedCount;
                allocatedWeight = newAllocatedWeight;
                result.Add(thisAllocatedCount);
            }
            return result;
        }
    }
}

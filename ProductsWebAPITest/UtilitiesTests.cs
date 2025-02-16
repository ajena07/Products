using ProductsWebAPI.Common;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Xunit;

namespace ProductsWebAPI.Tests
{
    public class UtilitiesTests
    {
        [Fact]
        public void GenerateIdUsingSeedHashing_ShouldGenerateConsistentIds_ForSameInput()
        {
            // Arrange
            string productName = "TestProduct";
            string productType = "TestType";
            ConcurrentBag<int> generatedIds = [];

            // Act
            Parallel.ForEach(Enumerable.Range(0, 1000), _ =>
            {
                int id = Utilities.GenerateIdUsingSeedHashing(productName, productType);
                generatedIds.Add(id);
            });

            // Assert
            Assert.Equal(1000, generatedIds.Count);
            Assert.Single(generatedIds.Distinct()); // Ensure all IDs are the same for the same input
        }

        [Fact]
        public void GenerateIdUsingSeedHashing_ShouldGenerateUniqueIds_ForDifferentInputs()
        {
            // Arrange
            ConcurrentBag<int> generatedIds = [];

            // Act
            Parallel.ForEach(Enumerable.Range(0, 1000), i =>
            {
                string productName = $"TestProduct{i}";
                string productType = $"TestType{i}";
                int id = Utilities.GenerateIdUsingSeedHashing(productName, productType);
                generatedIds.Add(id);
            });

            // Assert
            Assert.Equal(1000, generatedIds.Count);
            Assert.Equal(1000, generatedIds.Distinct().Count()); // Ensure all IDs are unique for different inputs
        }
    }
}

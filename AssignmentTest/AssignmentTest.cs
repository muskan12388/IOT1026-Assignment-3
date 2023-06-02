using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class PackTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;

             // Create a new pack using the specified maximum capacity
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

           // Assert that the maximum count of items in the pack matches the specified value
            Assert.AreEqual(pack.GetMaxCount(), PackMaxItems);
        }

        [TestMethod]
        public void ConstructorNegativeMaxCountTest()
        {
             // Assert that attempting to create a pack with a negative max count throws an exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(-10, 20, 20));
        }

        [TestMethod]
        public void ConstructorNegativeMaxVoloumeTest()
        {
                        // Assert that attempting to create a pack with a negative max volume throws an exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, -20, 20));
        }

        [TestMethod]
        public void ConstructorNegativeMaxWightTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, 20, -20));
        }

        [TestMethod]
        public void AddSignleItemTestToAnEmptyPack()
        {   // Assert that attempting to create a pack with a negative max weight throws an exception
            Pack pack = new(10, 20, 30);
            bool result = pack.Add(new Arrow());
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OverMaxCountTest()
        {               // Create a new pack with a maximum count of 1 item

            Pack pack = new(1, 20, 30);
            pack.Add(new Arrow());
            Assert.AreEqual(false, pack.Add(new Arrow()));
        }

        [TestMethod]
        public void OverMaxWeightTest()
        {       // Create a new pack with a maximum weight of 2
            Pack pack = new(10, 20, 2);
            Assert.AreEqual(false, pack.Add(new Sword()));
        }

        [TestMethod]
        public void OverMaxVolumeTest()
        {
            // Create a new pack with a maximum volume of 2
            Pack pack = new(10, 2, 30);
            Assert.AreEqual(false, pack.Add(new Sword()));
        }

        [TestMethod]
        public void AddItemWithNegativeWeight()
        {
              // Create a new pack
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(10, -20)));
        }

        [TestMethod]
        public void AddItemWithNegativeVolume()
        {
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(-10, 20)));
        }

        [TestMethod]
        public void AddItemWithZeroWeight()
        {
            Pack pack = new(10, 2, 30);

             // Attempt to add an Arrow item with a negative weight
            // Assert that it throws an exception due to the invalid weight value
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(10, 0)));
        }

        [TestMethod]
        public void AddItemWithZeroVolume()
        {
            // Create a new pack
            Pack pack = new(10, 2, 30);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Arrow(0, 20)));
        }
    }
}

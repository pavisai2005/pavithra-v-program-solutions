using NUnit.Framework;

namespace Assignment_05_NUnit
{
    [TestFixture]
    public class MathUtilityTests
    {
        [Test]
        public void Add_With3And5_Returns8()
        {
            int result = MathUtility.Add(3, 5);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Subtract_With10And4_Returns6()
        {
            int result = MathUtility.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }
    }
}
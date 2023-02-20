using Domain.Entities.Coordinates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace TestCubeIntersection.Domain
{
    public class CoordinateUnitTest
    {
        [TestMethod]
        [TestCase(3, 10, 30)]
        public void Should_Set_The_Coordinates(int x, int y, int z)
        {
            //Arrange
            Coordinate coordinate = new Coordinate();
            
            //Act
            coordinate.SetCoordinates(x, y, z);

            //Assert
            Assert.That(coordinate.X, Is.EqualTo(x));
            Assert.That(coordinate.Y, Is.EqualTo(y));
            Assert.That(coordinate.Z, Is.EqualTo(z));
        }

        [TestMethod]
        [TestCase(0, 0, 0)]
        public void New_Coordinate_Should_Have_Default_Initial_Values(int x, int y, int z)
        {
            //Arrange
            Coordinate coordinate;

            //Act
            coordinate = new Coordinate();

            //Assert
            Assert.That(coordinate.X, Is.EqualTo(x));
            Assert.That(coordinate.Y, Is.EqualTo(y));
            Assert.That(coordinate.Z, Is.EqualTo(z));
        }
    }
}
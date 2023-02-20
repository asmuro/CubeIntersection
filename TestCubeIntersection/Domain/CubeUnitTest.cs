using Domain.Entities.Coordinates;
using Domain.Entities.Cubes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace TestCubeIntersection.Domain
{
    public class CubeUnitTests
    {
        [Test]
        public void Should_Set_The_Center_Of_The_Cube()
        {
            //Arrange
            Cube cube1 = new Cube();
            Coordinate center = new Coordinate();
            center.SetCoordinates(3, 9, 8);

            //Act
            cube1.SetCenter(center);

            //Assert
            Assert.That(cube1.Center, Is.EqualTo(center));
        }

        [Test]
        public void Should_Set_The_Dimension_Of_The_Cube()
        {
            //Arrange
            Cube cube1 = new Cube();
            int dimension = 12;

            //Act
            cube1.SetDimension(dimension);

            //Assert
            Assert.That(cube1.Dimension, Is.EqualTo(dimension));
        }

        [TestMethod]
        [TestCase(0, 0, 0, 0)]
        public void New_Cube_Should_Have_Default_Initial_Values(int x, int y, int z, double dimension)
        {
            //Arrange
            Cube cube1;

            //Act
            cube1 = new Cube();

            //Assert
            Assert.That(cube1.Center.X, Is.EqualTo(x));
            Assert.That(cube1.Center.Y, Is.EqualTo(y));
            Assert.That(cube1.Center.Z, Is.EqualTo(z));
            Assert.That(cube1.Dimension, Is.EqualTo(dimension));
        }
    }
}
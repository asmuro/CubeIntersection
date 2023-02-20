using Domain.Entities.Coordinates;
using Domain.Entities.Cubes;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TestCubeIntersection.Domain
{
    public class IntersectionServiceUnitTest
    {
        [Test]
        public async Task Dummy_Shapes_Should_Return_A_False_Intersection_Result()
        {
            //Arrange
            IShape shape1 = Substitute.For<IShape>();
            IShape shape2 = Substitute.For<IShape>();
            IntersectionService intersectionService = new IntersectionService();

            //Act
            var intersectResult = await intersectionService.IntersectsAsync(shape1, shape2);

            //Assert
            Assert.That(intersectResult, Is.EqualTo(false));
        }

        [Test]
        public async Task Dummy_Shapes_Should_Return_A_Zero_Intersection_Volume()
        {
            //Arrange
            IShape shape1 = Substitute.For<IShape>();
            IShape shape2 = Substitute.For<IShape>();
            IntersectionService intersectionService = new IntersectionService();

            //Act
            double intersectionVolumeResult = await intersectionService.IntersectionVolumeAsync(shape1, shape2);

            //Assert
            Assert.That(intersectionVolumeResult, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0, 0, 0, 1, 0, 0, 0, 2, true)]
        public async Task Should_Return_A_Real_Cube_Intersection_Result(int cube1CenterX, int cube1CenterY, int cube1CenterZ,
            int cube1Dimension, int cube2CenterX, int cube2CenterY, int cube2CenterZ, int cube2Dimension, bool expectedIntersect)
        {
            //Arrange
            Cube cube1 = CreateCube(cube1CenterX, cube1CenterY, cube1CenterZ, cube1Dimension);
            Cube cube2 = CreateCube(cube2CenterX, cube2CenterY, cube2CenterZ, cube2Dimension);
            IntersectionService intersectionService = new IntersectionService();

            //Act
            var intersectResult = await intersectionService.IntersectsAsync(cube1, cube2);

            //Assert
            Assert.That(intersectResult, Is.EqualTo(expectedIntersect));
        }

        [TestMethod]
        [TestCase(0, 0, 0, 1, 0, 0, 0, 2, 1)]
        public async Task Should_Return_A_Real_Cube_IntersectionVolume_Result(int cube1CenterX, int cube1CenterY, int cube1CenterZ,
            int cube1Dimension, int cube2CenterX, int cube2CenterY, int cube2CenterZ, int cube2Dimension, double expectedVolume)
        {
            //Arrange
            Cube cube1 = CreateCube(cube1CenterX, cube1CenterY, cube1CenterZ, cube1Dimension);
            Cube cube2 = CreateCube(cube2CenterX, cube2CenterY, cube2CenterZ, cube2Dimension);
            IntersectionService intersectionService = new IntersectionService();

            //Act
            double intersectionVolumeResult = await intersectionService.IntersectionVolumeAsync(cube1, cube2);

            //Assert
            Assert.That(intersectionVolumeResult, Is.EqualTo(expectedVolume));
        }

        #region Helpers

        private Cube CreateCube(int cubeCenterX, int cubeCenterY, int cubeCenterZ,
            int cubeDimension)
        {
            Cube cube = new Cube();
            Coordinate coordinate = new Coordinate();
            coordinate.SetCoordinates(cubeCenterX, cubeCenterY, cubeCenterZ);
            cube.SetCenter(coordinate);
            cube.SetDimension(cubeDimension);
            return cube;
        }

        #endregion
    }
}
using Domain.Entities.Cubes;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TestCubeIntersection
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestMethod]
        public void Should_Return_IntersectionCubeService_When_Cube_Passed_As_Parameter()
        {
            //Arrange
            Cube cube1 = new Cube();
            Cube cube2 = new Cube();
            IntersectionFactory intersectionFactory = new IntersectionFactory();

            //Act
            IIntersectionService intersectionCubeService = intersectionFactory.GetIntersectionService(cube1, cube2);

            //Assert
            Assert.IsInstanceOf(typeof(IntersectionCubeService), intersectionCubeService);
        }

        [Test]
        [TestCase(0, 0, 0, 1, 0, 0, 0, 2, true)]
        [TestCase(0, 1, 0, 1, 0, 0, 0, 2, true)]
        [TestCase(-1, 0, 0, 1, 0, 0, 0, 2, true)]
        [TestCase(0, 0, 2, 1, 0, 0, 0, 2, false)]
        [TestCase(0, 0, 0, 2, 0, 0, 0, 2, true)]
        [TestCase(3, 3, 3, 2, 0, 0, 0, 100, true)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, true)]
        public async Task Should_Detect_Intersection_Of_Two_Cubes(int cube1CenterX, int cube1CenterY, int cube1CenterZ,
            int cube1Dimension, int cube2CenterX, int cube2CenterY, int cube2CenterZ, int cube2Dimension, bool expectedValue)
        {
            //Arrange
            Cube cube1 = new Cube();
            cube1.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube1CenterX, cube1CenterY, cube1CenterZ));
            cube1.SetDimension(cube1Dimension);
            Cube cube2 = new Cube();
            cube2.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube2CenterX, cube2CenterY, cube2CenterZ));
            cube2.SetDimension(cube2Dimension);
            IIntersectionFactory intersectionFactory = Substitute.For<IIntersectionFactory>();
            intersectionFactory.GetIntersectionService(default, default).ReturnsForAnyArgs(new IntersectionCubeService());
            IIntersectionService intersectionCubeService = intersectionFactory.GetIntersectionService(cube1, cube2);

            //Act
            bool intersects = await intersectionCubeService.IntersectsAsync(cube1, cube2);

            //Assert
            Assert.That(intersects, Is.EqualTo(expectedValue));
        }

        [TestMethod]
        [TestCase(0, 0, 0, 1, 0, 0, 0, 2, 1)]
        [TestCase(0, 1, 0, 1, 0, 0, 0, 2, 0.5)]
        [TestCase(-1, 0, 0, 1, 0, 0, 0, 2, 0.5)]
        [TestCase(0, 0, 0, 2, 0, 0, 0, 2, 8)]
        [TestCase(3, 3, 3, 2, 0, 0, 0, 100, 8)]
        [TestCase(2, 2, 2, 2, 0, 0, 0, 2, 0)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public async Task Should_Calculate_Intersected_Volume_Of_Two_Cubes(int cube1CenterX, int cube1CenterY, int cube1CenterZ,
            int cube1Dimension, int cube2CenterX, int cube2CenterY, int cube2CenterZ, int cube2Dimension, double expectedVolume)
        {
            //Arrange
            Cube cube1 = new Cube();
            cube1.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube1CenterX, cube1CenterY, cube1CenterZ));
            cube1.SetDimension(cube1Dimension);
            Cube cube2 = new Cube();
            cube2.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube2CenterX, cube2CenterY, cube2CenterZ));
            cube2.SetDimension(cube2Dimension);
            IIntersectionFactory intersectionFactory = Substitute.For<IIntersectionFactory>();
            intersectionFactory.GetIntersectionService(default, default).ReturnsForAnyArgs(new IntersectionCubeService());
            IIntersectionService intersectionCubeService = intersectionFactory.GetIntersectionService(cube1, cube2);

            //Act
            double intersectedVolume = await intersectionCubeService.IntersectionVolumeAsync(cube1, cube2);

            //Assert
            Assert.That(intersectedVolume, Is.EqualTo(expectedVolume));
        }

        [TestMethod]
        [TestCase(0, 0, 2, 1, 0, 0, 0, 2)]
        public async Task Should_Calculate_Negative_Intersection_Volume_Of_Non_Intersecting_Cubes(int cube1CenterX, int cube1CenterY, int cube1CenterZ,
            int cube1Dimension, int cube2CenterX, int cube2CenterY, int cube2CenterZ, int cube2Dimension)
        {
            //Arrange
            Cube cube1 = new Cube();
            cube1.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube1CenterX, cube1CenterY, cube1CenterZ));
            cube1.SetDimension(cube1Dimension);
            Cube cube2 = new Cube();
            cube2.SetCenter(new Domain.Entities.Coordinates.Coordinate(cube2CenterX, cube2CenterY, cube2CenterZ));
            cube2.SetDimension(cube2Dimension);
            IIntersectionFactory intersectionFactory = Substitute.For<IIntersectionFactory>();
            intersectionFactory.GetIntersectionService(default, default).ReturnsForAnyArgs(new IntersectionCubeService());
            IIntersectionService intersectionCubeService = intersectionFactory.GetIntersectionService(cube1, cube2);

            //Act
            double intersectedVolume = await intersectionCubeService.IntersectionVolumeAsync(cube1, cube2);

            //Assert
            Assert.IsTrue(intersectedVolume < 0);
        }
    }
}
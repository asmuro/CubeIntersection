using Domain.Entities.Cubes;
using Domain.Interfaces;
using Domain.Services;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TestCubeIntersection.Domain
{
    public class IntersectionFactoryUnitTest
    {
        [Test]
        public void Should_Return_A_Dummy_Intersection_Factory()
        {
            //Arrange
            IIntersectionFactory intersectionFactory = new IntersectionFactory();
            IShape shape1 = Substitute.For<IShape>();
            IShape shape2 = Substitute.For<IShape>();

            //Act
            IIntersectionService intersectionService = intersectionFactory.GetIntersectionService(shape1, shape2);

            //Assert
            Assert.That(intersectionService, Is.TypeOf(typeof(IntersectionDummyService)));
        }

        [Test]
        public void Should_Return_A_Cube_Intersection_Factory()
        {
            //Arrange
            IIntersectionFactory intersectionFactory = new IntersectionFactory();
            Cube cube1 = new();
            Cube cube2 = new();

            //Act
            IIntersectionService intersectionService = intersectionFactory.GetIntersectionService(cube1, cube2);

            //Assert
            Assert.That(intersectionService, Is.TypeOf(typeof(IntersectionCubeService)));
        }
    }
}
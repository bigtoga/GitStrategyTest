using System;
using NUnit.Framework;
using Tournaments.Models;
using Models.Contracts;
using Tournaments.Contracts;
using Moq;

namespace DataTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentException_WhenDbContextIsnull()
        {
            //Action & Assert           

            var message = "An instance of DbContext is required";
            var ex = Assert.Throws<ArgumentNullException>(() => new TournamentsRepository<ITeam>(null));
            StringAssert.Contains(message, ex.Message);
        }

        [Test]
        public void ReturnAnInstanceOfTournamentsRepository_WhenDbContextIsValid()
        {
            //Arrange
            var TournamentsDbContextMock = new Mock<TournamentsDbContext>();
            var tounamentRepository = new TournamentsRepository<ITeam>(TournamentsDbContextMock.Object);
            Assert.IsInstanceOf<TournamentsRepository<ITeam>>(tounamentRepository);
        }

        //[Test]
        //[GenericTestCase(typeof(Team))]

        //public void ReturnAnInstanceOfTournamentsRepository_WhenGenericDbContextIsValid(Type t)
        //{
        //    //Arrange
        //    var TournamentsDbContextMock = new Mock<TournamentsDbContext>();
        //    var tounamentRepository = new TournamentsRepository<t>(TournamentsDbContextMock.Object);
        //    Assert.IsInstanceOf<TournamentsRepository<t>>(tounamentRepository);
        //}
    }

}

using Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments;
using Tournaments.Contracts;
using Tournaments.Models;
using Tournaments.Services;

namespace ServicesTests.TeamServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ThrowArgumentException_WhenIdParameterIsNegative()
        {
            // Arrange
            var teamRepository = new Mock<ITournamentsRepository<Team>>();
            TeamService teamService = new TeamService(teamRepository.Object);
            int invalidId = -1;
            // Act & Assert
             Assert.That(
                      () => teamService.GetTeamById(invalidId).FirstOrDefault(), Throws.ArgumentException.With.Message.Contain("Invalid id"));
        }

        [Test]
        public void ShouldCallRepositoryGetById_WhenIdIsValid()
        {            
            // Arrange
            var teamRepositoryMock = new Mock<ITournamentsRepository<Team>>();
            TeamService teamService = new TeamService(teamRepositoryMock.Object);
            int teamOneId = 1;
            var teamOneMock = new Mock<Team>();
            teamOneMock.Setup(x => x.Id).Returns(teamOneId);
            var teamTwoMock = new Mock<Team>();
            teamTwoMock.Setup(x => x.Id).Returns(2);

            teamRepositoryMock.Setup(x => x.All()).Returns(new List<Team>() { teamOneMock.Object, teamTwoMock.Object });

            //Act
            var resultTeam = teamService.GetTeamById(teamOneId);

            //Assert
            teamRepositoryMock.Verify(x => x.All(),Times.Once);
            Assert.AreSame(resultTeam.FirstOrDefault(), teamOneMock.Object);          
        }
    }
}

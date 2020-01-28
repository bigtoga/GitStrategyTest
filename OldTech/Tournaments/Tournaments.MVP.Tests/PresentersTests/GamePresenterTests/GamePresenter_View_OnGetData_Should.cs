using Models.Contracts;
using Moq;
using NUnit.Framework;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;
using Tournaments.Models_project;
using Tournaments.Presenters;
using Tournaments.Views;

namespace TournamentsTests.PresentersTests.GamePresentersTests
{
    [TestFixture]
    public class View_OnCategoriesGetData_Should
    {
        [Test]
        public void CallGetAllGamesSortedById_WhenOnGetDataEventIsRaised()
        {

            //Arrange
            var viewMock = new Mock<IGameView>();
            viewMock.Setup(v => v.Model).Returns(new GameViewModel());

            var games = GetGames();
            var gameServiceMock = new Mock<IGameService>();
            gameServiceMock.Setup(c => c.GetAllGamesSortedById())
                    .Returns(games);

            GamePresenter gamePresenter = new GamePresenter(viewMock.Object, gameServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games); // TODO CHECK ORDER

        }

        private IEnumerable<Game> GetGames()
        {
            var team1 = new Team { Id = 1, Name = "Name 1" };
            var team2 = new Team { Id = 2, Name = "Name 2" };
            //team1Mock.Setup(x => x.Id).Returns(1);
            //var team2Mock = new Mock<Team>();
            //team2Mock.Setup(x => x.Id).Returns(2);
            var tournamentMock = new Mock<Tournament>();

            return new List<Game>()
            {
                new Game()
                {
                    Id=1,
                    StartTime=new DateTime(2017,02,01),
                    EndTime = new DateTime(2017, 02, 01),
                    Result="1:1",
                    Place="Place 1",
                    HostId=1,
                    Host=team1,
                    GuestId = 2,
                    Guest = team2,
                    TournamentId=1,
                    Tournament=tournamentMock.Object
                },
                new Game()
                {
                    Id=2,
                    StartTime=new DateTime(2017, 02, 02),
                    EndTime = new DateTime(2017, 02, 02),
                    Result="2:2",
                    Place="Place 2",
                    HostId=1,
                    Host=team1,
                    GuestId = 2,
                    Guest = team2,
                    TournamentId=1,
                    Tournament=tournamentMock.Object
                }
            }.AsQueryable();
        }
    }
}


using Models.Contracts;
using Models.Models;
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

namespace TournamentsTests.PresentersTests.PlayerPresentersTests
{
    [TestFixture]
    public class PlayerPresenter_View_OnGetData_Should
    {
        [Test]
        public void CallGetAllPlayersSortedById_WhenOnGetDataEventIsRaised()
        {

            //Arrange
            var viewMock = new Mock<IPlayerView>();
            viewMock.Setup(v => v.Model).Returns(new PlayerViewModel());

            var players = GetPlayers();
            var playerServiceMock = new Mock<IPlayerService>();
            playerServiceMock.Setup(c => c.GetAllPlayersSortedById())
                    .Returns(players);

            PlayerPresenter playerPresenter = new PlayerPresenter(viewMock.Object, playerServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(players, viewMock.Object.Model.Players); // TODO CHECK ORDER

        }

        private IEnumerable<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player()
                {
                    Id=1,
                    FirstName="player1firstname",
                    LastName="player1lastname",
                    NickName="player1nickname",
                    Picture="pictureurl",
                    Email="player1@players.com",
                    Rating=10,
                    IsCoach=false,
                    CV="player1cv",
                    TeamId=1,
                    Team=new Team() { Id=1, Name="Team1Name"},
                    UserId=new Guid(),
                    User=new User(),
                },
                new Player()
                {
                    Id=2,
                    FirstName="player2firstname",
                    LastName="player2lastname",
                    NickName="player2nickname",
                    Picture="pictureurl",
                    Email="player2@players.com",
                    Rating=11,
                    IsCoach=false,
                    CV="player2cv",
                    TeamId=1,
                    Team=new Team() { Id=1, Name="Team1Name"},
                    UserId=new Guid(),
                    User=new User(),
                }

            }.AsQueryable();
        }
    }
}


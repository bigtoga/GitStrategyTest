using Moq;
using NUnit.Framework;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Tournaments.Models;
using Tournaments.Presenters;
using Tournaments.Views;

namespace Tournaments.PresentersTests.TournamentPresenterTests
{
    [TestFixture]
    public class TournamentPresenter_View_OnUpdateItem_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ITournamentView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int tournamentId = 1;
            string expectedError = String.Format("Item with id {0} was not found", tournamentId);
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(t => t.GetTournamentById(tournamentId)).Returns<Tournament>(null);

            TournamentPresenter tournamentPresenter = new TournamentPresenter
                (viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(tournamentId));
            var actualResult = viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage;

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, actualResult);
        }

        //[Test]
        //public void AddModelError_WhenItemCannotBeUpdated()
        //{
        //    // Arrange
        //    var viewMock = new Mock<ITeamView>();
        //    viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
        //    string errorKey = string.Empty;
        //    int teamId = 1;
        //    string expectedError = String.Format("Item with id {0} cannot be updated", teamId);
        //    var teamServiceMock = new Mock<ITeamService>();
        //    var team = new Team() { Id = teamId };
        //    var teamList = (IEnumerable<Team>) new List<Team>() { team };
        //    teamServiceMock.Setup(t => t.GetTeamById(teamId)).Returns<List<Team>>(x=>teamList);
        //    var modelStateMock = new Mock<ModelStateDictionary>();
        //    modelStateMock.Setup(m => m.IsValid).Returns(false);
        //    viewMock.Setup(v => v.ModelState).Returns(modelStateMock.Object);

        //    TeamPresenter teamPresenter = new TeamPresenter
        //        (viewMock.Object, teamServiceMock.Object);

        //    // Act
        //    viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(teamId));
        //    var actualResult = viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage;

        //    // Assert
        //    Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
        //    StringAssert.AreEqualIgnoringCase(expectedError, actualResult);
        //}

        [Test]
        public void TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ITournamentView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int tournamentId = 1;
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(c => c.GetTournamentById(tournamentId)).Returns<Tournament>(null);

            TournamentPresenter tournamentPresenter = new TournamentPresenter
                (viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(tournamentId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Tournament>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<ITournamentView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            int tournamentId = 1;
            var tournamentName = "Tournament 1";
            var tournamentDate = new DateTime(2017, 02, 01);
            var tournamentPrize = 1;
            
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(c => c.GetTournamentById(tournamentId)).Returns(new List<Tournament> { new Tournament() { Id = tournamentId, Name=tournamentName, Date=tournamentDate,Prize=tournamentPrize } });

            TournamentPresenter tournamentPresenter = new TournamentPresenter(viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(tournamentId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Tournament>()), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<ITournamentView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            int tournamentId = 1;
            var tournamentName = "Tournament 1";
            var tournamentDate = new DateTime(2017, 02, 01);
            var tournamentPrize = 1;
            var tournament = new Tournament() { Id = tournamentId, Name = tournamentName, Date = tournamentDate, Prize = tournamentPrize };
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(c => c.GetTournamentById(tournamentId)).Returns(new List<Tournament> { tournament});

            TournamentPresenter tournamentPresenter = new TournamentPresenter(viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(tournamentId));

            // Assert
            tournamentServiceMock.Verify(c => c.UpdateTournament(tournament), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<ITournamentView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            int tournamentId = 1;
            var tournamentName = "Tournament 1";
            var tournamentDate = new DateTime(2017, 02, 01);
            var tournamentPrize = 1;
            var tournament = new Tournament() { Id = tournamentId, Name = tournamentName, Date = tournamentDate, Prize = tournamentPrize };
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(c => c.GetTournamentById(tournamentId)).Returns(new List<Tournament> { new Tournament() { Id = tournamentId, Name = tournamentName, Date = tournamentDate, Prize = tournamentPrize } });

            TournamentPresenter tournamentPresenter = new TournamentPresenter(viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(tournamentId));

            // Assert
            tournamentServiceMock.Verify(c => c.UpdateTournament(tournament), Times.Never());
        }
    }
}

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

namespace TournamentsTests.PresentersTests.TournamentPresentersTests
{
    [TestFixture]
    public class TournamentPresenter_View_OnGetData_Should
    {
        [Test]
        public void CallGetAllTournamentsSortedById_WhenOnGetDataEventIsRaised()
        {

            //Arrange
            var viewMock = new Mock<ITournamentView>();
            viewMock.Setup(v => v.Model).Returns(new TournamentViewModel());

            var tournaments = GetTournaments();
            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(c => c.GetAllTournamentsSortedById())
                    .Returns(tournaments);

            TournamentPresenter tournamentPresenter = new TournamentPresenter(viewMock.Object, tournamentServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(tournaments, viewMock.Object.Model.Tournaments); // TODO CHECK ORDER

        }

        private IEnumerable<Tournament> GetTournaments()
        {
            return new List<Tournament>()
            {
                new Tournament()
                {

                    Id=1,
                    Name = "Tournament 1",
                    Date = new DateTime(2017,02,01),
                    Prize=1
                },
                new Tournament()
                {

                    Id=2,
                    Name = "Tournament 2",
                    Date = new DateTime(2017,02,02),
                    Prize=1
                },
            }.AsQueryable();
        }
    }
}


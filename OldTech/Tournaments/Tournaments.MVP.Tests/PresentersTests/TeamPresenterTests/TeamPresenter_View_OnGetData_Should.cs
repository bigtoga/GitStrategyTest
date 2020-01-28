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

namespace TournamentsTests.PresentersTests.TeamPresentersTestsk
{
    [TestFixture]
    public class TeamPresenter_View_OnGetData_Should
    {
        [Test]
        public void CallGetAllTeamsSortedById_WhenOnGetDataEventIsRaised()
        {

        //Arrange
       var viewMock = new Mock<ITeamView>();
            viewMock.Setup(v => v.Model).Returns(new TeamViewModel());
            
            var teams = GetTeams();
        var teamServiceMock = new Mock<ITeamService>();
        teamServiceMock.Setup(c => c.GetAllTeamsSortedById())
                .Returns(teams);

        TeamPresenter teamPresenter = new TeamPresenter(viewMock.Object, teamServiceMock.Object);

        // Act
        viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(teams, viewMock.Object.Model.Teams); // TODO CHECK ORDER

        }

    private IEnumerable<Team> GetTeams()
    {
            return new List<Team>()
            {
                new Team()
                {

                    Id=1,
                    Name = "Team 1",
                    Rating = 11,
                    Players=null
                },
                new Team()
                {

                    Id=2,
                    Name = "Team 2",
                    Rating = 22,
                    Players=null
                },
            }.AsQueryable();
    }
    }
}


using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Views;
using Services.Services.Contracts;
using Tournaments.Services;
using Tournaments.Presenters;
using System.Web;
using Tournaments.Models;
using WebFormsMvp;

namespace TournamentsTests.PresentersTests.TeamPresentersTests
{
    [TestFixture]
    public class TeamPresenter_Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainingTeamService_WhenTeamManagementServiceIsNull()
        {
            var mockedTeamView = new Mock<ITeamView>();        
            Assert.That(
                         () => new TeamPresenter(mockedTeamView.Object, null), Throws.ArgumentNullException.With.Message.Contain("TeamService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedTeamView = new Mock<ITeamView>();
            var mockedTeamService = new Mock<ITeamService>();
            Assert.DoesNotThrow(() => new TeamPresenter(mockedTeamView.Object, mockedTeamService.Object));
        }

        [Test]
        public void ReturnsAnInstanceOfTeamPresenter_WhenAllArgumentsAreValid()
        {
            var mockedTeamView = new Mock<ITeamView>();
            var mockedTeamService = new Mock<ITeamService>();
            Assert.IsInstanceOf<TeamPresenter>(new TeamPresenter(mockedTeamView.Object, mockedTeamService.Object));
        }
    }
}

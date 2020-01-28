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

namespace TournamentsTests.PresentersTests.TournamentPresentersTests
{
    [TestFixture]
    public class TournamentPresenter_Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainingTournamentService_WhenTournamentServiceIsNull()
        {
            var mockedTournamentView = new Mock<ITournamentView>();        
            Assert.That(
                         () => new TournamentPresenter(mockedTournamentView.Object, null), Throws.ArgumentNullException.With.Message.Contain("TournamentService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedTournamentView = new Mock<ITournamentView>();
            var mockedTournamentService = new Mock<ITournamentService>();
            Assert.DoesNotThrow(() => new TournamentPresenter(mockedTournamentView.Object, mockedTournamentService.Object));
        }

        [Test]
        public void ReturnsAnInstanceOfTournamentPresenter_WhenAllArgumentsAreValid()
        {
            var mockedTournamentView = new Mock<ITournamentView>();
            var mockedTournamentService = new Mock<ITournamentService>();
            Assert.IsInstanceOf<TournamentPresenter>(new TournamentPresenter(mockedTournamentView.Object, mockedTournamentService.Object));
        }
    }
}

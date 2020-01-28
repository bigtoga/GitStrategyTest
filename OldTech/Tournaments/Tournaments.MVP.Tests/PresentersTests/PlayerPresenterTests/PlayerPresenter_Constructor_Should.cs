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

namespace TournamentsTests.PresentersTests.PlayerPresentersTests
{
    [TestFixture]
    public class PlayerPresenters_Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainingPlayerService_WhenPlayerServiceIsNull()
        {
            var mockedPlayerView = new Mock<IPlayerView>();        
            Assert.That(
                         () => new PlayerPresenter(mockedPlayerView.Object, null), Throws.ArgumentNullException.With.Message.Contain("PlayerService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedPlayerView = new Mock<IPlayerView>();
            var mockedPlayerService = new Mock<IPlayerService>();
            Assert.DoesNotThrow(() => new PlayerPresenter(mockedPlayerView.Object, mockedPlayerService.Object));
        }

        [Test]
        public void ReturnsAnInstanceOfPlayerPresenter_WhenAllArgumentsAreValid()
        {
            var mockedPlayerView = new Mock<IPlayerView>();
            var mockedPlayerService = new Mock<IPlayerService>();
            Assert.IsInstanceOf<PlayerPresenter>(new PlayerPresenter(mockedPlayerView.Object, mockedPlayerService.Object));
        }
    }
}

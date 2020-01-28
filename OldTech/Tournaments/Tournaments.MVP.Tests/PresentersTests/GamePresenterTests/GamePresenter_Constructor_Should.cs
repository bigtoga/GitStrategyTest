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

namespace TournamentsTests.PresentersTests.GamePresentersTests
{
    [TestFixture]
    public class GamePresenter_Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainingGameService_WhenGameServiceIsNull()
        {
            var mockedGameView = new Mock<IGameView>();        
            Assert.That(
                         () => new GamePresenter(mockedGameView.Object, null), Throws.ArgumentNullException.With.Message.Contain("GameService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedGameView = new Mock<IGameView>();
            var mockedGameService = new Mock<IGameService>();
            Assert.DoesNotThrow(() => new GamePresenter(mockedGameView.Object, mockedGameService.Object));
        }

        [Test]
        public void ReturnsAnInstanceOfGamePresenter_WhenAllArgumentsAreValid()
        {
            var mockedGameView = new Mock<IGameView>();
            var mockedGameService = new Mock<IGameService>();
            Assert.IsInstanceOf<GamePresenter>(new GamePresenter(mockedGameView.Object, mockedGameService.Object));
        }
    }
}

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

namespace TournamentsTests.PresentersTests.SponsorPresentersTests
{
    [TestFixture]
    public class SponsorPresenter_Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainingSponsorService_WhenSponsorServiceIsNull()
        {
            var mockedSponsorView = new Mock<ISponsorView>();        
            Assert.That(
                         () => new SponsorPresenter(mockedSponsorView.Object, null), Throws.ArgumentNullException.With.Message.Contain("SponsorService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedSponsorView = new Mock<ISponsorView>();
            var mockedSponsorService = new Mock<ISponsorService>();
            Assert.DoesNotThrow(() => new SponsorPresenter(mockedSponsorView.Object, mockedSponsorService.Object));
        }

        [Test]
        public void ReturnsAnInstanceOfSponsorPresenter_WhenAllArgumentsAreValid()
        {
            var mockedSponsorView = new Mock<ISponsorView>();
            var mockedSponsorService = new Mock<ISponsorService>();
            Assert.IsInstanceOf<SponsorPresenter>(new SponsorPresenter(mockedSponsorView.Object, mockedSponsorService.Object));
        }
    }
}

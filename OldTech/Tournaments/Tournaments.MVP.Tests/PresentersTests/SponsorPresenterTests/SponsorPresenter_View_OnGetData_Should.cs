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

namespace TournamentsTests.PresentersTests.SponsorPresentersTests
{
    [TestFixture]
    public class SponsorPresenter_View_OnGetData_Should
    {
        [Test]
        public void CallGetAllSponsorsSortedById_WhenOnGetDataEventIsRaised()
        {

            //Arrange
            var viewMock = new Mock<ISponsorView>();
            viewMock.Setup(v => v.Model).Returns(new SponsorViewModel());

            var sponsors = GetSponsors();
            var sponsorServiceMock = new Mock<ISponsorService>();
            sponsorServiceMock.Setup(c => c.GetAllSponsorsSortedById())
                    .Returns(sponsors);

            SponsorPresenter sponsorPresenter = new SponsorPresenter(viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(sponsors, viewMock.Object.Model.Sponsors); // TODO CHECK ORDER

        }

        private IEnumerable<Sponsor> GetSponsors()
        {
            return new List<Sponsor>()
            {
                new Sponsor()
                {
                    Id=1,
                    Name = "Sponsor 1"
                },
                new Sponsor()
                {
                    Id=2,
                    Name = "Sponsor 2"
                }
            }.AsQueryable();
        }
    }
}


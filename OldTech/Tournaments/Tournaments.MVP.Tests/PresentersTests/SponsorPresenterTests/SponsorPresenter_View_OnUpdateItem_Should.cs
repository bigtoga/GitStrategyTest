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

namespace Tournaments.PresentersTests.SponsorPresenterTests
{
    [TestFixture]
    public class SponsorPresenter_View_OnUpdateItem_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<ISponsorView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int sponsorId = 1;
            string expectedError = String.Format("Item with id {0} was not found", sponsorId);
            var sponsorServiceMock = new Mock<ISponsorService>();
            sponsorServiceMock.Setup(t => t.GetSponsorById(sponsorId)).Returns<Sponsor>(null);

            SponsorPresenter sponsorPresenter = new SponsorPresenter
                (viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(sponsorId));
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
            var viewMock = new Mock<ISponsorView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int teamId = 1;
            var sponsorServiceMock = new Mock<ISponsorService>();
            sponsorServiceMock.Setup(c => c.GetSponsorById(teamId)).Returns<Sponsor>(null);

            SponsorPresenter sponsorPresenter = new SponsorPresenter
                (viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(teamId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Team>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<ISponsorView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            int sponsorId = 1;
            string sponsorName = "SponsorName";
            
            var sponsorServiceMock = new Mock<ISponsorService>();
            sponsorServiceMock.Setup(c => c.GetSponsorById(sponsorId)).Returns(new List<Sponsor> { new Sponsor() { Id = sponsorId, Name = sponsorName } });

            SponsorPresenter sponsorPresenter = new SponsorPresenter(viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(sponsorId));

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Sponsor>()), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState()
        {
            // Arrange
            var viewMock = new Mock<ISponsorView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            int sponsorId = 1;
            string sponsorName = "SponsorName";
            
            var sponsorServiceMock = new Mock<ISponsorService>();
            var sponsor = new Sponsor() { Id = sponsorId, Name = sponsorName };
            sponsorServiceMock.Setup(c => c.GetSponsorById(sponsorId)).Returns(new List<Sponsor>() { sponsor });

            SponsorPresenter sponsorPresenter = new SponsorPresenter(viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(sponsorId));

            // Assert
            sponsorServiceMock.Verify(c => c.UpdateSponsor(sponsor), Times.Once());
        }

        [Test]
        public void UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState()
        {
            // Arrange
            var viewMock = new Mock<ISponsorView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            int sponsorId = 1;
            string sponsorName = "SponsorName";
 
            var sponsorServiceMock = new Mock<ISponsorService>();
            var sponsor = new Sponsor() { Id = sponsorId, Name = sponsorName };
            sponsorServiceMock.Setup(c => c.GetSponsorById(sponsorId)).Returns(new List<Sponsor>() { sponsor });

            SponsorPresenter sponsorPresenter = new SponsorPresenter(viewMock.Object, sponsorServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUpdateItem += null, new IdEventArgs(sponsorId));

            // Assert
            sponsorServiceMock.Verify(c => c.UpdateSponsor(sponsor), Times.Never());
        }
    }
}

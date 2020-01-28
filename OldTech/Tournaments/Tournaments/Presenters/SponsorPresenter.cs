using Bytes2you.Validation;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;
using Tournaments.Services;
using Tournaments.Views;
using WebFormsMvp;

namespace Tournaments.Presenters
{
    public class SponsorPresenter : Presenter<ISponsorView>
    {
        private readonly ISponsorService sponsorService;

        public SponsorPresenter(ISponsorView view, ISponsorService sponsorService)
            : base(view)
        {
            Guard.WhenArgument(sponsorService, "SponsorService").IsNull().Throw();
            Guard.WhenArgument(view, "SponsorView").IsNull().Throw();

            this.sponsorService = sponsorService;
            this.View.MyInit += this.View_Init;
            this.View.OnGetData += this.View_OnGetData;
            this.View.OnInsertItem += this.View_OnInsertItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
            this.View.OnUpdateItem += this.View_OnUpdateItem;

        }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Sponsors = this.sponsorService.GetSponsors();
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Update sponsor Id cannot be null");
            }

            var sponsor = this.sponsorService.GetSponsorById((int)e.Id);
            if (sponsor == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            Sponsor item = this.sponsorService.GetSponsorById((int)e.Id).FirstOrDefault();


            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.sponsorService.UpdateSponsor(item);
            }
            else
            {
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} cannot be updated", e.Id));
                return;
            }
        }

        private void View_OnDeleteItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Delete sponsor Id cannot be null");
            }
            this.sponsorService.DeleteSponsor((int)e.Id);
        }

        private void View_OnInsertItem(object sender, EventArgs e)
        {
            Sponsor sponsor = new Sponsor();
            this.View.TryUpdateModel(sponsor);
            if (this.View.ModelState.IsValid)
            {
                this.sponsorService.InsertSponsor(sponsor);
            }
        }

        private void View_OnGetData(object sender, EventArgs e)
        {
            this.View.Model.Sponsors = this.sponsorService.GetAllSponsorsSortedById();
        }
    }
}

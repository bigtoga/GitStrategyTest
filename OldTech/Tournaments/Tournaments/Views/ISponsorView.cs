using System;
using System.Web.ModelBinding;
using Tournaments.Models_project;
using WebFormsMvp;

namespace Tournaments.Views
{
    public interface ISponsorView : IView<SponsorViewModel>
    {
        event EventHandler MyInit;
        event EventHandler OnGetData;
        event EventHandler OnInsertItem;
        event EventHandler<IdEventArgs> OnDeleteItem;
        event EventHandler<IdEventArgs> OnUpdateItem;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}

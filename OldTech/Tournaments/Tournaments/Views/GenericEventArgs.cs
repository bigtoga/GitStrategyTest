using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.Views
{
    public class GenericEventArgs<T> : EventArgs where T: class
    {
        public GenericEventArgs(T entity)
        {
            this.EntityProp = entity;
        }

        public T EntityProp{get;private set;}
    }
}
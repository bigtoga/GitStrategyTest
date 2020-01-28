using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournaments.Views
{
    public class IdEventArgs : EventArgs
    {
        public int? Id { get; private set; }

        public IdEventArgs(int? id)
        {
            this.Id = id;
        }
    }
}
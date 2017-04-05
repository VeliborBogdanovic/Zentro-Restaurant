using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class TerminiSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<TerminItem> termins = null;

            if (this.Id == 0)
            {
                termins = from termin in restoran.Terminis
                          select new TerminItem {  Id=termin.Id_termin,vreme=termin.vreme};
            }
            else
            {
                termins = from termin in restoran.Terminis
                          where termin.Id_termin==this.Id
                           select new TerminItem { Id = termin.Id_termin, vreme = termin.vreme };
            }
            TerminiResult rez = new TerminiResult();
            rez.termini = termins.ToList();
            rez.Success = true;
            return rez;

        }
    }
}
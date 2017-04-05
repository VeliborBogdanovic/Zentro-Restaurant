using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.DataLayer;

namespace Restaurant.BusinessLayer
{
    public class TerminItem: RestoranItem
    {
        public int Id { get; set; }
        public TimeSpan? vreme { get; set; }
    }
   
    public class TerminiResult : OperationResult
    {
        public List<TerminItem> termini { get; set; }
    }
    public class TerminiInsert : Operation
    {
        public TerminItem termin = new TerminItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.TerminiInsert(this.termin.vreme);
            return new OperationResult { Success = true };
        }
    }
    public class TerminiDelete : Operation
    {
        public TerminItem termin = new TerminItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.TerminiDelete(this.termin.Id);
            return new OperationResult { Success = true };
        }
    }
    public class TerminiUpdate : Operation
    {

        public TerminItem termin = new TerminItem();
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.TerminiUpdate(this.termin.Id, this.termin.vreme);
            return new OperationResult { Success = true };
        }
    }
    public class TerminiSelect : Operation
    {
        public TerminItem termin = new TerminItem();
        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<TerminItem> termins = null;

            if (this.termin.Id == 0)
            {
                termins = from termin in restoran.Terminis
                          select new TerminItem { Id = termin.Id_termin, vreme = termin.vreme };
            }
            else
            {
                termins = from termin in restoran.Terminis
                          where termin.Id_termin == this.termin.Id
                          select new TerminItem { Id = termin.Id_termin, vreme = termin.vreme };
            }
            return new TerminiResult { Success = true, termini = termins.ToList() };           
        }

    }

}
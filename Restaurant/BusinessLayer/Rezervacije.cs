using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class RezervacijeItem : RestoranItem
    {
        public int IdRez { get; set; }
        public string Ime { get; set; }
        public string Mail { get; set; }
        public DateTime Datum { get; set; }
        public string  Poruka { get; set; }
        public int idBrojLJudi { get; set; }
        public int IdTerm { get; set; }
        public int? BrojLjudi { get; set; }
        public TimeSpan? Termin { get; set; }


    }
    public class RezervazijaTerminSelect : Operation
    {
        public RezervacijeItem rezervacija = new RezervacijeItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<RezervacijeItem> rezervacije = null;

            if (this.rezervacija.IdRez == 0)
            {
                rezervacije = from rezervacija in restoran.Rezervacijes
                              join termin in restoran.Terminis on rezervacija.id_termin equals termin.Id_termin
                              join br in restoran.brojLjudis on rezervacija.IdBrojLjudi equals br.IdBrojLjudi
                              select new RezervacijeItem() { IdRez = rezervacija.Id_rezervacija, Ime = rezervacija.ime, Mail = rezervacija.e_mail, Datum = rezervacija.datum, Poruka = rezervacija.poruka, IdTerm = rezervacija.id_termin, idBrojLJudi = rezervacija.IdBrojLjudi, BrojLjudi = br.brojLjudi1, Termin = termin.vreme };
            }
            else
            {
                rezervacije = from rezervacija in restoran.Rezervacijes
                              join termin in restoran.Terminis on rezervacija.id_termin equals termin.Id_termin
                              join br in restoran.brojLjudis on rezervacija.IdBrojLjudi equals br.IdBrojLjudi
                              where rezervacija.Id_rezervacija == this.rezervacija.IdRez 
                              select new RezervacijeItem() { IdRez = rezervacija.Id_rezervacija, Ime = rezervacija.ime, Mail = rezervacija.e_mail, Datum = rezervacija.datum, Poruka = rezervacija.poruka, IdTerm = rezervacija.id_termin, idBrojLJudi = rezervacija.IdBrojLjudi, BrojLjudi = br.brojLjudi1, Termin = termin.vreme };
            }
            return new RezervacijaTerminResult { Success = true,Rezervacije = rezervacije.ToList() };           
        }

    }
    public class RezervacijaTerminResult : OperationResult
    {
        public List<RezervacijeItem> Rezervacije { get; set; }
    }
    public class RezervacijeInsert : Operation
    {
             
        public RezervacijeItem rezervacija = new RezervacijeItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.ReservationInsert(rezervacija.Ime, rezervacija.Mail, rezervacija.Datum, rezervacija.Poruka, rezervacija.idBrojLJudi, rezervacija.IdTerm);
            return new OperationResult { Success = true };
        }
    }
    public class RezervacijeDelete : Operation
    {
        public RezervacijeItem rezervacija = new RezervacijeItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.ReservationDelete(this.rezervacija.IdRez);
            return new OperationResult { Success = true };
        }
    }
    public class RezervacijeUpdate : Operation
    {

        public RezervacijeItem rezervacija= new RezervacijeItem();
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.ReservationUpdate(this.rezervacija.IdRez, this.rezervacija.Ime, this.rezervacija.Mail, this.rezervacija.Datum, this.rezervacija.Poruka, this.rezervacija.idBrojLJudi, this.rezervacija.IdTerm);
            return new OperationResult { Success = true };
        }
    }
}
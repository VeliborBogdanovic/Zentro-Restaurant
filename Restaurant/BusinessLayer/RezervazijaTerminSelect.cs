using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class RezervazijaTerminSelect : Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<RezervacijeItem> rezervacije = null;

            if (this.Id == 0)
            {
                rezervacije = from rezervacija in restoran.Rezervacijes
                              join termin in restoran.Terminis on rezervacija.id_termin equals termin.Id_termin
                              join br in restoran.brojLjudis on rezervacija.IdBrojLjudi equals br.IdBrojLjudi
                              select new RezervacijeItem() {IdRez=rezervacija.Id_rezervacija,Ime=rezervacija.ime,Mail=rezervacija.e_mail, Datum=rezervacija.datum,Poruka=rezervacija.poruka,IdTerm=rezervacija.id_termin,idBrojLJudi=rezervacija.IdBrojLjudi,BrojLjudi=br.brojLjudi1, Termin=termin.vreme };
            }
            else
            {
                rezervacije = from rezervacija in restoran.Rezervacijes
                              join termin in restoran.Terminis on rezervacija.id_termin equals termin.Id_termin
                              join br in restoran.brojLjudis on rezervacija.IdBrojLjudi equals br.IdBrojLjudi
                              where rezervacija.Id_rezervacija==this.Id
                              select new RezervacijeItem() { IdRez = rezervacija.Id_rezervacija, Ime = rezervacija.ime, Mail = rezervacija.e_mail, Datum = rezervacija.datum, Poruka = rezervacija.poruka, IdTerm = rezervacija.id_termin, idBrojLJudi = rezervacija.IdBrojLjudi, BrojLjudi = br.brojLjudi1, Termin = termin.vreme };
            }
            RezervacijaTerminResult rez = new RezervacijaTerminResult();
            rez.Rezervacije = rezervacije.ToList();
            rez.Success = true;
            return rez;
        }
    }
}

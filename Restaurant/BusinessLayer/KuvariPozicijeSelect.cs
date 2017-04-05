using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariPozicijeSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<KuvariPozicijaItem> kuvariPozicije = null;

            if (this.Id == 0)
            {
                kuvariPozicije = from kuvariP in restoran.Kuvaris
                               join pozicije in restoran.Pozicijes on kuvariP.id_pozicija equals pozicije.Id_pozicija
                               select new KuvariPozicijaItem{IdKuvar= kuvariP.Id_kuvara,Ime=kuvariP.ime,Slika=kuvariP.slika,idPozicije=kuvariP.id_pozicija,NazivPozicije=pozicije.naziv};
            }
            else
            {
                kuvariPozicije = from kuvariP in restoran.Kuvaris
                                 join pozicije in restoran.Pozicijes on kuvariP.id_pozicija equals pozicije.Id_pozicija
                                 where kuvariP.Id_kuvara==this.id
                                 select new KuvariPozicijaItem { IdKuvar = kuvariP.Id_kuvara, Ime = kuvariP.ime, Slika = kuvariP.slika, idPozicije = kuvariP.id_pozicija, NazivPozicije = pozicije.naziv };
            }
            KuvariPozicijeResult rez = new KuvariPozicijeResult();
            rez.kuvariPoz=kuvariPozicije.ToList();
            rez.Success = true;
            return rez;

        }
    }
}
using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariPozicijaItem
    {
        public int IdKuvar { get; set; }
        public string Ime { get; set; }
        public string Slika { get; set; }
        public int idPozicije { get; set; }
       
        public string NazivPozicije { get; set; }
    }
    public class KuvariPozicijaInsert : Operation
    {
        public string Ime { get; set; }
        public string slika { get; set; }
        public string slikaMala { get; set; }
        public int IdPozicija { get; set; }


        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijaInsert(this.Ime, this.slika, this.slikaMala, this.IdPozicija);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
    public class KuvariPozicijaUpdate : Operation
    {
        public string ime { get; set; }
        public int id { get; set; }
        public string slika { get; set; }
        public string slikaMala { get; set; }
        public int idPozicije { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijeUpdate(this.id, this.ime, this.slika, this.slikaMala, this.idPozicije);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
    public class KuvariPozicijeResult : OperationResult
    {
        public List<KuvariPozicijaItem> kuvariPoz { get; set; }
    }
    public class KuvariPozicijeSelect : Operation
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
                                 select new KuvariPozicijaItem { IdKuvar = kuvariP.Id_kuvara, Ime = kuvariP.ime, Slika = kuvariP.slika, idPozicije = kuvariP.id_pozicija, NazivPozicije = pozicije.naziv };
            }
            else
            {
                kuvariPozicije = from kuvariP in restoran.Kuvaris
                                 join pozicije in restoran.Pozicijes on kuvariP.id_pozicija equals pozicije.Id_pozicija
                                 where kuvariP.Id_kuvara == this.id
                                 select new KuvariPozicijaItem { IdKuvar = kuvariP.Id_kuvara, Ime = kuvariP.ime, Slika = kuvariP.slika, idPozicije = kuvariP.id_pozicija, NazivPozicije = pozicije.naziv };
            }
            KuvariPozicijeResult rez = new KuvariPozicijeResult();
            rez.kuvariPoz = kuvariPozicije.ToList();
            rez.Success = true;
            return rez;

        }
    }
    public class KuvarPozicijaDelete : Operation
    {
        public int id { get; set; }
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.KuvariDelete(this.id);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;
        }
    }
}
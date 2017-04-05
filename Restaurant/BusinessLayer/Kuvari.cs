using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariItem: RestoranItem
    {
        public int IdKuvar { get; set; }
        public string Ime { get; set; }
        public string Slika { get; set; }
        public int idPozicije { get; set; }
    }
    public class KuvariPozicijaItem
    {
        public int IdKuvar { get; set; }
        public string Ime { get; set; }
        public string Slika { get; set; }

        public string SlikaMala { get; set; }
        public int idPozicije { get; set; }

        public string NazivPozicije { get; set; }
    }
    public class KuvariPozicijaInsert : Operation
    {
       public KuvariPozicijaItem kuvarPozicija=new KuvariPozicijaItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijaInsert(this.kuvarPozicija.Ime, this.kuvarPozicija.Slika, this.kuvarPozicija.SlikaMala, this.kuvarPozicija.idPozicije);
            return new OperationResult { Success = true };
        }
    }
    public class KuvariPozicijaUpdate : Operation
    {
        public KuvariPozicijaItem kuvarPozicija = new KuvariPozicijaItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijeUpdate(this.kuvarPozicija.IdKuvar, this.kuvarPozicija.Ime, this.kuvarPozicija.Slika, this.kuvarPozicija.SlikaMala, this.kuvarPozicija.idPozicije);
            return new OperationResult { Success = true };
        }
    }
    public class KuvariPozicijeResult : OperationResult
    {
        public List<KuvariPozicijaItem> kuvariPoz { get; set; }
    }
    public class KuvariPozicijeSelect : Operation
    {
        public KuvariPozicijaItem kuvarPozicija = new KuvariPozicijaItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<KuvariPozicijaItem> kuvariPozicije = null;

            if (this.kuvarPozicija.IdKuvar == 0)
            {
                kuvariPozicije = from kuvariP in restoran.Kuvaris
                                 join pozicije in restoran.Pozicijes on kuvariP.id_pozicija equals pozicije.Id_pozicija
                                 select new KuvariPozicijaItem { IdKuvar = kuvariP.Id_kuvara, Ime = kuvariP.ime, Slika = kuvariP.slika, SlikaMala=kuvariP.slika_mala, idPozicije = kuvariP.id_pozicija, NazivPozicije = pozicije.naziv };
            }
            else
            {
                kuvariPozicije = from kuvariP in restoran.Kuvaris
                                 join pozicije in restoran.Pozicijes on kuvariP.id_pozicija equals pozicije.Id_pozicija
                                 where kuvariP.Id_kuvara == this.kuvarPozicija.IdKuvar
                                 select new KuvariPozicijaItem { IdKuvar = kuvariP.Id_kuvara, Ime = kuvariP.ime, Slika = kuvariP.slika, SlikaMala = kuvariP.slika_mala, idPozicije = kuvariP.id_pozicija, NazivPozicije = pozicije.naziv };
            }
            return new KuvariPozicijeResult { Success = true, kuvariPoz = kuvariPozicije.ToList() };           
         }
    }
    public class KuvarPozicijaDelete : Operation
    {
        public KuvariPozicijaItem kuvarPozicija = new KuvariPozicijaItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.KuvariDelete(this.kuvarPozicija.IdKuvar);
            return new OperationResult { Success = true };
        }
    }
}
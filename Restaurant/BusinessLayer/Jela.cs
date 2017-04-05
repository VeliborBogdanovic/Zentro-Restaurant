using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaItem : RestoranItem
    {
        public int IdJela { get; set; }
        public string NazivJela { get; set; }
        public string Slika { get; set; }
        public double Cena { get; set; }
        public bool? Akcija { get; set; }


    }
    public class JelaSastojciItem : RestoranItem
    {
        public int IdJela { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public double Cena { get; set; }
        public bool? akcija { get; set; }
        public int IdSastojka { get; set; }
        public string NazivSastojka { get; set; }



    }
    public class JelaSastojciDelete : Operation
    {
        public JelaItem jelo = new JelaItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.JelaDelete(this.jelo.IdJela);
            return new OperationResult { Success = true };
        }
    }
    public class Jela_SastojciInsert : Operation
    {

        public JelaSastojciItem jelosastojak = new JelaSastojciItem();
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.Jela_SastojciInsert(this.jelosastojak.IdJela, this.jelosastojak.IdSastojka);
            return new OperationResult { Success = true };

        }
    }

    public class JelaSastojciResult : OperationResult
    {
        public List<JelaSastojciItem> JelaSastojci { get; set; }

    }
    public class JelaSastojciSelect : Operation
    {
        public JelaSastojciItem jelosastojak = new JelaSastojciItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<JelaSastojciItem> jelaSastojci = null;

            if (this.jelosastojak.IdJela == 0)
            {
                jelaSastojci = from jelasastojci1 in restoran.Jela_Sastojci
                               join jela in restoran.Jelas on jelasastojci1.Id_jela equals jela.Id_jela
                               join sastojci in restoran.Sastojcis on jelasastojci1.Id_sastojka equals sastojci.Id_sastojka
                               select new JelaSastojciItem { IdJela = jela.Id_jela, Naziv = jela.naziv, Slika = jela.slika, Cena = jela.cena, akcija = jela.akcija, IdSastojka = sastojci.Id_sastojka, NazivSastojka = sastojci.naziv };
            }
            if (this.jelosastojak.IdJela != 0)
            {
                jelaSastojci = from jelasastojci1 in restoran.Jela_Sastojci
                               join jela in restoran.Jelas on jelasastojci1.Id_jela equals jela.Id_jela
                               join sastojci in restoran.Sastojcis on jelasastojci1.Id_sastojka equals sastojci.Id_sastojka
                               where jela.Id_jela == this.jelosastojak.IdJela
                               select new JelaSastojciItem { IdJela = jela.Id_jela, Naziv = jela.naziv, Slika = jela.slika, Cena = jela.cena, akcija = jela.akcija, IdSastojka = sastojci.Id_sastojka, NazivSastojka = sastojci.naziv };
            }
            return new JelaSastojciResult { Success = true, JelaSastojci = jelaSastojci.ToList() };        

        }
    }
    public class JelaUpdate : Operation
    {
        public JelaItem jelo = new JelaItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.JelaUpdate(jelo.IdJela, jelo.NazivJela, jelo.Slika, jelo.Cena, jelo.Akcija);
            return new OperationResult { Success = true };

        }
    }
    public class JelaInsert : Operation
    {
        public JelaItem jelo = new JelaItem();
        //System.Data.Objects.ObjectParameter idJelaParametar = new System.Data.Objects.ObjectParameter("idJela", System.Type.GetType("System.Int32"));
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.JelaInsert(this.jelo.NazivJela, this.jelo.Slika, this.jelo.Cena, this.jelo.Akcija);
            return new OperationResult { Success = true };

        }
    }
}
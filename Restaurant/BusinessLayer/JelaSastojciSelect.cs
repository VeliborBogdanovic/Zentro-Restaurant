using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaSastojciSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<JelaSastojciItem> jelaSastojci = null;
            
            if (this.Id == 0)
            {
                jelaSastojci = from jelasastojci1 in restoran.Jela_Sastojci
                    join jela in restoran.Jelas on jelasastojci1.Id_jela equals jela.Id_jela
                    join sastojci in restoran.Sastojcis on jelasastojci1.Id_sastojka equals sastojci.Id_sastojka
                     select new JelaSastojciItem{IdJela=jela.Id_jela, Naziv=jela.naziv,Slika=jela.slika,Cena=jela.cena,akcija=jela.akcija,IdSastojka=sastojci.Id_sastojka,NazivSastojka=sastojci.naziv};
             }
            if (this.id != 0)
            {
                jelaSastojci = from jelasastojci1 in restoran.Jela_Sastojci
                               join jela in restoran.Jelas on jelasastojci1.Id_jela equals jela.Id_jela
                               join sastojci in restoran.Sastojcis on jelasastojci1.Id_sastojka equals sastojci.Id_sastojka
                               where jela.Id_jela==this.Id
                               select new JelaSastojciItem { IdJela = jela.Id_jela, Naziv = jela.naziv, Slika = jela.slika, Cena = jela.cena, akcija = jela.akcija, IdSastojka = sastojci.Id_sastojka, NazivSastojka = sastojci.naziv };
            }
            
            JelaSastojciResult  rez = new JelaSastojciResult();
            rez.JelaSastojci = jelaSastojci.ToList();
            rez.Success = true;
            return rez;

        }
    }
}
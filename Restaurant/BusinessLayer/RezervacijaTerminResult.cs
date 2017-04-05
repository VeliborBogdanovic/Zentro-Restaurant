using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class RezervacijaTerminResult:OperationResult
    {
        public List<RezervacijeItem> Rezervacije{ get; set; }
    }
}
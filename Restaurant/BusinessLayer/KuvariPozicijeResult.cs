using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariPozicijeResult:OperationResult
    {
        public List<KuvariPozicijaItem> kuvariPoz { get; set; }
    }
}
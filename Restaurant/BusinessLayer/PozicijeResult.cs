using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class PozicijeResult:OperationResult
    {
        public List<PozicijeItem> pozicije { get; set; }
    }
}
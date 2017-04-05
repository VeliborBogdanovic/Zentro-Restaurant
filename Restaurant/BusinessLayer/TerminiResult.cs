using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class TerminiResult:OperationResult
    {
        public List<TerminItem> termini { get; set; }
    }
}
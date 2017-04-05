using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class SastojciResult:OperationResult
    {
        public List<SastojciItem> sastojci { get; set; }
    }
}
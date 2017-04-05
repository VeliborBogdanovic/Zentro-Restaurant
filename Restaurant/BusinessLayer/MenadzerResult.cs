using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class MenadzerResult:OperationResult
    {
        public List<MenadzerItem> menadzeri { get; set; }
    }
}
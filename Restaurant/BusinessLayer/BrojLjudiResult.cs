using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class BrojLjudiResult:OperationResult
    {
        public List<BrojLjudiItem> brojLjudi { get; set; }
    }
}
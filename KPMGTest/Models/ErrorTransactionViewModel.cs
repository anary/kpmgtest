using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPMG.Core;
using KPMG.DataProcess;

namespace KPMGTest.Models
{
    public class ErrorTransactionViewModel
    {
        public IEnumerable<DataDTO> Errors { get; set; }

    }
}
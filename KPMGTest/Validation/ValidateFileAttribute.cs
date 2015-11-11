using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPMGTest.Validation
{
    public class ValidateFileAttribute:RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var allowedExtensions = new[] { ".xlsx",".csv"};
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
           
            return true;

        }
    }
}
using KPMG.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.DataProcess
{
    public class Validate : IValidate
    {
        private bool tryGetCurrencySymbol(string ISOCurrencySymbol, out string symbol)
        {
            symbol = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.LCID);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(ri => ri != null && ri.ISOCurrencySymbol == ISOCurrencySymbol)
                .Select(ri => ri.CurrencySymbol)
                .FirstOrDefault();
            return symbol != null;
        }
        public bool Valiate(DataDTO data)
        {
            decimal number;
            string currSymbol;
            var result = false;
            if (data != null)
            {
                var canConvert = decimal.TryParse(data.Amount.ToString(), out number);
                var isCurrSymbol = tryGetCurrencySymbol(data.CurrencyCode, out currSymbol);
                //var val = (string.IsNullOrEmpty(data.Account)) ||
                //    (string.IsNullOrEmpty(data.Description)) ||
                //    (!string.IsNullOrEmpty(data.CurrencyCode)) || !canConvert;
                //result = !val;
                result = (!string.IsNullOrEmpty(data.Account)) &&
                    (!string.IsNullOrEmpty(data.Description)) &&
                    (!string.IsNullOrEmpty(data.CurrencyCode)) && canConvert && isCurrSymbol;
            }
            return result;
        }     
    }
}

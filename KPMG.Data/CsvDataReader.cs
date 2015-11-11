using KPMG.Core;
using KPMG.Core.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Data
{
    public class CsvDataReader : ICsvDataReader
    {
        private string[] lines;
        public CsvDataReader(string fold)
        {
            lines = File.ReadAllLines(fold);
        }
        public bool IsFirstRowAsColumnNames
        {
            get;
            set;
        }


        public IEnumerable<DataDTO> AsDataList()
        {
            
            IEnumerable<string> content= lines.Skip(0);
            
            if (IsFirstRowAsColumnNames)
            {
                content = lines.Skip(1);
            }
            return content.Select(line => line.Split(','))
                          .Select(l =>
                          {
                             return new DataDTO
                             {
                                Account = l[0],
                                Description = l[1],
                                CurrencyCode = l[2],
                                Amount = l[3]
                             };
                          });
            
        }
    }
}

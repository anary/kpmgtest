using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Core.Contract
{
    public interface ICsvDataReader
    {
        bool IsFirstRowAsColumnNames { get; set; }       
       
        IEnumerable<DataDTO> AsDataList();
    }
}

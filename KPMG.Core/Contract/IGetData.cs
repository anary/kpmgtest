using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Core.Contract
{
    public interface IGetData
    {
        IEnumerable<DataDTO> GetData(string path,
            bool isFirstRowAsColumnNames = true);
    }
}

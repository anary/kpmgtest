using KPMG.Core;
using KPMG.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.DataProcess
{
    public interface IValidateData
    {
        ValidatedTransactions ValidatedData(IEnumerable<DataDTO> data);
    }
}

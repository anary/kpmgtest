using KPMG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.DataProcess
{
    public interface IValidate
    {
        bool Valiate(DataDTO data);
    }
}

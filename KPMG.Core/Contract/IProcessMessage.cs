using KPMG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Core.Contract
{
    public interface IProcessMessage
    {
        void AddMessage(Transaction transaction);
        void AddData(DataDTO data);
        void Start();
        void Stop();
        
    }
}

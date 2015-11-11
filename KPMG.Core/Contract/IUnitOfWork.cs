using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Core.Contract
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}

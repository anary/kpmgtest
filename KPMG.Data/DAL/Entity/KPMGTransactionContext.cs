using KPMG.Core.Contract;
using KPMG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Data.DAL.Entity
{
    public class KPMGTransactionContext : DbContext, IDbContext
    {
        public KPMGTransactionContext() :base("TransactionContext")
        {
            Database.SetInitializer<KPMGTransactionContext>(null);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}

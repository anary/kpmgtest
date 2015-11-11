using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.Core.Contract;
using KPMG.Core.Entities;
using KPMG.Data.DAL.Entity;
using KPMG.Data.DAL.Repository;

namespace KPMG.DataProcess
{
    public class DataPersistance
    {
        IUnitOfWork unitOfWork;
        IRepository<Transaction> transactionRepository;
        
        public DataPersistance()
        {
            var dbContext = new KPMGTransactionContext();
            unitOfWork = new UnitOfWork(dbContext);
            transactionRepository = unitOfWork.Repository<Transaction>();
               
        }

        public void CleanTable()
        {
            var dbContext = new KPMGTransactionContext();
            dbContext.Database.ExecuteSqlCommand("delete from Transactions"); 
            dbContext.Dispose();
        }

        public void SaveToDb(Transaction transaction)
        {
            transactionRepository.Add(transaction);
        }

        public void Saved()
        {
            unitOfWork.Save();
            unitOfWork.Dispose();
        }
    }
}

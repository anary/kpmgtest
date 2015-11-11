using KPMG.Core.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Data.DAL.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDbContext context;

        private bool disposed;
        private Hashtable repositories;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var name = typeof(TEntity).Name;

            if (!repositories.ContainsKey(name))
            {
                // check is it same?? instance == repositoryInstance
                // var instance = new Repository<TEntity>(context);
                var repositoryType = typeof(Repository<>);
                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), context);
                repositories.Add(name, repositoryInstance);
            }

            return (IRepository<TEntity>)repositories[name];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();
            disposed = true;
        }
    }
}

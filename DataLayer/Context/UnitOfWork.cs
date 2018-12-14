using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
using DataLayer.Services;

namespace DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        JelvehabKhoramshahrEntities db=new JelvehabKhoramshahrEntities();
        private IMaterialRepositories _materialRepositories;
        
        public IMaterialRepositories MaterialRepositories
        {
            get
            {
                if (_materialRepositories == null)
                {
                    return _materialRepositories = new MaterialRepositories(db);
                }

                return _materialRepositories;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();

        }
    }
}

using Kobe.Data.Context;
using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kobe.Data.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T:class, BaseEntity
    {
        private readonly KobeContext _dataContext;

        public EntityBaseRepository(KobeContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().Where(x => x.IsDeleted == false);
        }
    }
}

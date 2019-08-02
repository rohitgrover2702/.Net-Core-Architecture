using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kobe.Data.Repository
{
    public interface IEntityBaseRepository<T> where T : class, BaseEntity
    {
        IQueryable<T> GetAll();
    }
}

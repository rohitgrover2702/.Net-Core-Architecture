using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kobe.Data.Repository
{
    public interface IEntityBaseRepository<T> where T : class, BaseEntity
    {
        IQueryable<T> GetAll();
        void Add(T entity);

        T GetById(int? id);
        void SoftDelete(T entity);
        T Edit(T oldEntity, T newEntity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}

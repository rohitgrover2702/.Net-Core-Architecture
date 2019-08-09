using Kobe.Data.Context;
using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kobe.Data.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, BaseEntity
    {
        private readonly KobeContext _dataContext;

        public EntityBaseRepository(KobeContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().Where(x => x.IsDeleted == false);
        }
        public virtual void Add(T entity)
        {
            try
            {
                entity.IsDeleted = false;
                entity.KeyId = Guid.NewGuid();
                entity.CreatedDate = System.DateTime.UtcNow;
                entity.ModifiedDate = System.DateTime.UtcNow;
                EntityEntry dbEntityEntry = _dataContext.Entry<T>(entity);
                _dataContext.Set<T>().Add(entity);
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public T GetById(int? id)
        {
            var result = _dataContext.Set<T>().Where(x => (x.Id == id) && (x.IsDeleted == false)).FirstOrDefault();
            return result;
        }

        public void SoftDelete(T entity)
        {
            var result = _dataContext.Set<T>().Where(x => (x.Id == entity.Id) && (x.IsDeleted == false)).FirstOrDefault();
            if (result != null)
            {
                result.IsDeleted = true;
                result.ModifiedDate = System.DateTime.UtcNow;
                EntityEntry dbEntityEntry = _dataContext.Entry<T>(result);
                dbEntityEntry.State = EntityState.Modified;
                _dataContext.SaveChanges();
            }

        }

        public T Edit(T oldEntity, T newEntity)
        {
            newEntity.IsDeleted = false;
            newEntity.KeyId = oldEntity.KeyId;
            newEntity.CreatedDate = oldEntity.CreatedDate;
            newEntity.ModifiedDate = System.DateTime.UtcNow;
            _dataContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            _dataContext.SaveChanges();
            return _dataContext.Set<T>().Where(x => (x.Id == oldEntity.Id) && (x.IsDeleted == false)).FirstOrDefault();

        }

        public T Select(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.Set<T>().Where(predicate).Where(x => x.IsDeleted == false);
        }
    }
}

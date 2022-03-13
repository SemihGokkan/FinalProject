using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new() //Kuralları yazıyoruz. TEntitiy bu bir veri tabanı tablosu olacak vb. 
        where TContext : DbContext, new() //
    {
        public void Add(TEntity entity)
        {
            //using C# özel bir yapı-IDisposable pattern impementation of C# - belleği kolayca ve hızlı temizle
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // tek data getirir. SingleOrDefault Linq kodu
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList() //arka planda SELECT *  FROM PRODUCT çalıştırıyor. Filtre null mı? evetse tümünü getir. ToList Linq kodu, yukarıdaki, using'e eklememiz gerekiyor.
                     : context.Set<TEntity>().Where(filter).ToList(); //değilse filtreleyip ver.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //NuGet 
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using C# özel bir yapı-IDisposable pattern impementation of C# - belleği kolayca ve hızlı temile
            using (NortwindContext context = new NortwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext context=new NortwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // tek data getirir. SingleOrDefault Linq kodu
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NortwindContext context=new NortwindContext())
            {
               return filter == null
                    ? context.Set<Product>().ToList() //arka planda SELECT *  FROM PRODUCT çalıştırıyor. Filtre null mı? evetse tümünü getir. ToList Linq kodu, yukarıdaki, using'e eklememiz gerekiyor.
                    : context.Set<Product>().Where(filter).ToList(); //değilse filtreleyip ver.
            }
        }

        public void Update(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

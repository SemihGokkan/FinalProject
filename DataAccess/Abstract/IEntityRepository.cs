using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{

    //Generic constraint - generic kısıt demek.
    //where T:class - sadece calss'ları getir demek, int , string vb yazılamaz sadece Product, Customer vb yazılır.
    //where T:class,IEntity - Ientity olabilir veya IEntity implamente eden bir class olabilir.
    //new() - new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()  //Generic interface, hangi tabloyu istiyorsak onu getirir. ICategoryDal, IProductDal vb ayrı ayrı yazmamak için ortak interface oluşturuyoruz. 
    {
        List<T> GetAll(Expression<Func<T, bool>>filter=null); //Bu yapı ile filtrelemeleri ayı ayrı metodlarda yazmıyoruz.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); Expression yapısı kullandığımızda bu satıra gerek kalmıyor.
    }
}

using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> //Veri erişim interface, product tablosunun veri erişim kodları
    {
         

    }
}


//Code Refactoring - Kodun iyileştirilmesi için Core katmnı oluşturuyoruz.
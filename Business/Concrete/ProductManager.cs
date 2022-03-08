using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _producDal;

        public ProductManager(IProductDal producDal)
        {
            _producDal = producDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları buraya yazılır, şu an simülasyon yapıyoruz. (if else vb. kodlar). Kuralları yazdığımız yer. 
            return _producDal.GetAll();

        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Global değişken olduğu için _ ile kullanılır ingilizcesi naming convention
        public InMemoryProductDal() //Constructor void döndürmüyor direk class'ın adı ile olunca constructor oluyor
        {
            _products = new List<Product> { //içinde ürünleri bulunduran liste. Veri tabanından geliyormuş gibi kurgu yaptık.
            new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
            new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
            new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
            new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
            new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var p in _products)  //LINQ bilmediğimizi varsayarak klasik döngü ile bütün listeyi tek tek dolaşıp eşitliği bulunca siler. Bu yöntem kötü bir yöntem belleği yorar.
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelet = p;
            //    }
            //}
            //LINQ froeach, bu bir metod/p=>takma ad/kural
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //LINQ Kodu foreach görevi yapar. SingOrDefault tek bir Id ararken kullanılır. 
            _products.Remove(productToDelete);                                                          //p=> takma ad, o an dolaştığım ürünün Id'si parametre ile gönderdiğimiz Id uyuşuyorsa operasyonu gerçekleştir.

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Güncellenecek referansı bulmam lazım. Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList(); //SQL'deki Where şartı gibi, şarta uyanları yeni tablo yapıp gösterir.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

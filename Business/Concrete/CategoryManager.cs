using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; //Bağımlılığmızı minimize ediyoruz. ICategorDal lazım bana. Bağımlılığı contructor injection ile yapıyoruz. _categoryDal tıklıyoruz ampulden Genrate Construtor seçiyoruz.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //İş kodları yazılır, eğer varsa..
            return _categoryDal.GetAll();
        }
        //Select * from Categories where CategoryId=3..
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}

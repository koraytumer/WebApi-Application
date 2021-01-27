using SampleApplication.Business.Abstract;
using SampleApplication.DataAccess.Abstract;
using SampleApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SampleApplication.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.Get(filter);
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetList();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

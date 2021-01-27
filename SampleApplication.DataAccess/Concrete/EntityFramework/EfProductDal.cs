using SampleApplication.DataAccess.Abstract;
using SampleApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SampleApplication.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepository<Product, NorthwindContext>, IProductDal
    {

    }
}

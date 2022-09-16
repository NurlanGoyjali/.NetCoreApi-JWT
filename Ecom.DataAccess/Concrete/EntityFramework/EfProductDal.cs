using Ecom.Core.DataAccess.EntityFramework;
using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
     public class EfProductDal: EfEntityRepositoryBase<Product,DataContext> , IProductDal
    {

    }
}

using Ecom.Core.DataAccess.EntityFramework;
using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
  public class EFBuyDal : EfEntityRepositoryBase<Buy, DataContext>, IBuyDal
  {

  }
}

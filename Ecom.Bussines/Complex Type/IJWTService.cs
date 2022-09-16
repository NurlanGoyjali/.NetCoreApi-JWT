using Ecom.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Bussines.Complex_Type
{
  public interface IJWTService
  {
    string Auth(string username , string password);
    User takeUser(string mail);
  }
}

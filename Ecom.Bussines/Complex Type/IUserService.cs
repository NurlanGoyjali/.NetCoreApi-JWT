using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Bussines.Complex_Type
{
  public interface IUserService
  {
    User ReturnUser();
    User GetUser(string username, string pass);
    void AddUser(User user);
    void DeleteUser(User user);
    void UpdateUser(User user);

    List<User> GetAll();

  }
}

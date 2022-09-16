using Ecom.Bussines.Complex_Type;
using Ecom.Bussines.Conrete;
using System;

namespace Ecom.Api.Attributes
{

  public class userRoleAttribute : Attribute
  {

    private IUserService _userService= new UserManager();
    private string role;

    public userRoleAttribute(string role)
    {
      this.role = role;
    }

    public bool takeRole()
    {

      if (_userService.ReturnUser().Roleid != 1)
      {
        Console.WriteLine("salamlar");
        return false;
      }
      else
      {

        return true;
      }

    }


  }
}

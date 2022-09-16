using Ecom.Bussines.Complex_Type;
using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;
using System.Collections.Generic;

namespace Ecom.Bussines.Conrete
{
  public class UserManager :   IUserService
  {
    private IUserDal _userDal;
    private static User MyUser;
    

    public UserManager(IUserDal userDal)
    {
      _userDal = userDal;
      
      
    }

    public UserManager()
    {

    }

    public  User ReturnUser()
    {
      return MyUser;
    }
    public void TakeUser(User user)
    {

      MyUser = user;

    }
    public void AddUser(User user)
    {
      
      if (MyUser.Roleid == 1 || MyUser.Roleid == 2)
      {
        try
        {
          user.ManagerId = MyUser.Id;
          _userDal.Add(user);
        }
        catch (System.Exception)
        {

          throw;
        }
      }


        
      }

    public void DeleteUser(User user)
    {
      if (MyUser.Roleid == 1 || MyUser.Roleid == 2)
      {
        try
        {
          _userDal.Delete(user);
        }
        catch (System.Exception)
        {

          throw;
        }
      }
    }

    public User GetUser(string username, string password)
    {

      return MyUser;
    }

    public void UpdateUser(User user)
    {

      if (MyUser.Roleid == 1 || MyUser.Roleid == 2 || MyUser.Roleid == 3)
      {
        _userDal.Update(user);
      }
      
    }

    public List<User> GetAll()
    {

      if (MyUser.Roleid == 1 )
      {
        return _userDal.GetList();
      }else 
      {
        return _userDal.GetList(x => x.ManagerId == MyUser.Id);
      }
     
    }
  }
}

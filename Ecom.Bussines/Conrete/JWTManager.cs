using Ecom.Bussines.Complex_Type;
using System;
using System.Linq;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Ecom.DataAccess.Concrete;
using Ecom.Entities.Concrete;

namespace Ecom.Bussines.Conrete
{
  public class JWTManager : IJWTService
  {
    private readonly string _key;
    public User MyUser;


    public JWTManager(string key)
    {
      _key = key;
    }
 
    public string Auth(string username, string password)
    {
      using (DataContext context= new DataContext())
      {
        try{ MyUser = context.Users.Where(u => u.Name == username && u.Password == password).First(); }
        catch (Exception){    return null;   }         
        new ProductManager().TakeUser(MyUser);
        new UserManager().TakeUser(MyUser);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_key);
        var tokenDescription = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]
          {      new Claim(ClaimTypes.Name, username)     }),
          Expires = DateTime.Now.AddHours(1),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                                  , SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
      }
  }


   public User takeUser(string email)
    {
      using (DataContext context = new DataContext())
      {
        MyUser = context.Users.Where(x => x.Email == email).First();
      }
        return MyUser;
    }
   
  }
}

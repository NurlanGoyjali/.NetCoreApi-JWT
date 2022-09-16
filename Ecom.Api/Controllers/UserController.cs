using Ecom.Bussines.Complex_Type;
using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ecom.Api.Controllers
{
  [Authorize]
  [Route("user")]
  public class UserController : Controller
  {
    private IJWTService _IJWTService;    private IUserService _userService;
    private static int number=-5;        private static int num = 115;
    public UserController(IJWTService JwtService, IUserService userService)
    {
      _IJWTService = JwtService;   _userService = userService;
    }
    [HttpPost("add")]
    public IActionResult addUser(User user)
    {
      if (user!=null) { _userService.AddUser(user); return Ok("Kullanıcı Eklendi"); }
      else return BadRequest("kullanıcı bilgileri yanlış");
    }
    [HttpPost("getall")]
    public IActionResult GetAll()
    {
      return Ok(_userService.GetAll());
    }


    [HttpPost("delete")]
    public IActionResult deleteUser(User user)
    {
      if (user != null) {  _userService.DeleteUser(user);  return Ok("Kullanıcı silindi ");    }
      else  return BadRequest("kullanıcı bilgileri yanlış");
    }
    [HttpPost("update")]
    public IActionResult UpdateUser(User user)
    {
      if (user != null)
      {  _userService.UpdateUser(user);  return Ok("Kullanıcı günclelendi ");   }
      else  return BadRequest("kullanıcı bilgileri yanlış");
    }



    [AllowAnonymous]
    [HttpPost("singin")]
    public async Task<string> SingIn(string username, string password)
    {
      var token = _IJWTService.Auth(username, password);
      if (token == null) { Unauthorized(); return"Böyle bir kullanıcı yoX"; }
      else {    Response.Headers.Add("Authorization", "Bearer" + " " + token);    return token;   }
    }


    [AllowAnonymous]
    [HttpGet("sendmail")]
      public async Task<string> send(string UserMail, int value)
      {
      if (value == number)
      {
        var user = _IJWTService.takeUser(UserMail);
        var response = await SingIn(user.Name, user.Password);
        return response.ToString();
      }
      else
      {
        if (value==115)
        {
          num++;
          number = new Random().Next(1, 100);
          mailside(UserMail);
        }
        using (HttpClient client =new HttpClient())
        {
          Thread.Sleep(200);
          return await client.GetStringAsync("https://localhost:5001/user/sendmail?usermail="+UserMail+"&value="+num);
        }
        return "deneme";
      }
     

      
      
      }




    [AllowAnonymous]
    [HttpGet("cred")]
    public async void usercred(int value)
    {
      if(number == value)
      {
        num = value;
      }

     
    }
    [HttpOptions]
    public bool mailside(string UserMail)
    {

      string FilePath = Directory.GetCurrentDirectory() + "\\ecom.html";
      StreamReader str = new StreamReader(FilePath);
      string MailText = str.ReadToEnd();
      str.Close();
      //denetle
      string strnumber = number.ToString();
      MailText = MailText.Replace("[number]", strnumber);

      var email = new MimeMessage();
      MailboxAddress mailbox = new MailboxAddress("Ecom.Com", "smerch-nurlan@mail.ru");
      email.From.Add(mailbox);
      MailboxAddress to = new MailboxAddress("sayın", UserMail);
      email.To.Add(to);
      email.Subject = $"Welcome {"salamlar"}";
      var builder = new BodyBuilder();
      builder.HtmlBody = MailText;
      email.Body = builder.ToMessageBody();
      var smtp = new SmtpClient();

      smtp.Connect("smtp.mail.ru", 465, true);
      smtp.Authenticate("smerch-nurlan@mail.ru", "nrln6126");
      smtp.Send(email);
      smtp.Dispose();

      return true;

    }



  }
}

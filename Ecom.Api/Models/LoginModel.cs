using Ecom.Core.Entities;

namespace Ecom.Api.Models
{
    public class LoginModel: IEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public int license { get; set; }
    }
}
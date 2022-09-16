using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entities.Concrete
{
 public class Sell :IEntity
  {
    //kullanıcı ve manager satabilir. manager kullanıcıya satar kullanıcı da boşluğa
    [Key]
    public int Id { get; set; }
    //satıcı
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
  }
}

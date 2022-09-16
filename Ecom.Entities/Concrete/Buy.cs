using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entities.Concrete
{
  public class Buy :IEntity
  {
    //kullanıcı alabilir. kullanıcı manager den alır. manager aldığını ürün olarak ekler
    [Key]
    public int Id { get; set; }
    //satıcı
    public int ManagerId  { get; set; }
    //alıcı
    public int UserId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }


  }
}

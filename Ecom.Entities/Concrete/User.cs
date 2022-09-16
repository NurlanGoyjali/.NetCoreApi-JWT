using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entities.Concrete
{
  public class User : IEntity
  {
    [Key]
    public int Id { get; set; }
    public int ManagerId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime AddTime { get; set; }
    public bool Active { get; set; }
    public int Roleid { get; set; }


  }
}

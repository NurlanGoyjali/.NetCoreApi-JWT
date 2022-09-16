using Ecom.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Entities.Concrete
{
  public class Role : IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }


  }
}

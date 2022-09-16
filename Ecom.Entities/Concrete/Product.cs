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
    public class Product : IEntity
  {

         [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public int UserID { get; set; }
        public int ManagerID { get; set; }

 
  }
}

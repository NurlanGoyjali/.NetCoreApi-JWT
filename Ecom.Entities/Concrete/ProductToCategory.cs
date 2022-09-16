using System.ComponentModel.DataAnnotations;
using Ecom.Core.Entities;

namespace Ecom.Entities.Concrete
{
    public class ProductToCategory:IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string CategoryName { get; set; }
        
    }
}
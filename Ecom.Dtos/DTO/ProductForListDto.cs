namespace Ecom.Dtos.DTO
{
    public class ProductForListDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string CategoryName { get; set; }
    }
}
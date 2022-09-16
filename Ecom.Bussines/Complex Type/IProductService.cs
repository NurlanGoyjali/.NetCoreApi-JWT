using Ecom.Entities.Concrete;
using System.Collections.Generic;

namespace Ecom.Bussines.Complex_Type
{
  public interface IProductService
  {
    List<Product> getAll();
    Product Get(int productid);
    List<Product> GetAll(int categoryid);
    void Delete(Product product);
    void Add(Product product);
    void Update(Product product);
    bool BuyProduct(Product product);
    bool SellProduct(Product product);

    List<Product> SellList();
    List<Product> BuyList();




}
}

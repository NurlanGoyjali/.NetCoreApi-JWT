using Ecom.Bussines.Complex_Type;
using Ecom.DataAccess.ComplexType;
using Ecom.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Ecom.Bussines.Conrete
{
  public class ProductManager : IProductService
  {
    private IProductDal _productDal;    private ISellDal _selldal;
    private IBuyDal _buyDal;            private static User MyUser;
    public ProductManager() {   }
    public ProductManager(IProductDal productDal, ISellDal sellDal, IBuyDal buyDal)
    {
      _productDal = productDal;   _selldal = sellDal;  _buyDal = buyDal;
    }


    public void TakeUser(User user)   {     MyUser = user;    }
    public List<Product> GetAll(int categoryid)  {   return _productDal.GetList(null);    }
    public List<Product> getAll()
    {
      if (MyUser.Roleid != 1)  return _productDal.GetList(x => x.ManagerID == MyUser.ManagerId);   
      if (MyUser.Roleid == 1)   return _productDal.GetList();   
      else return null;
    }
    public void Add(Product product)
    {
      if (MyUser.Roleid == 2 || MyUser.Roleid == 1)
      {
        product.ManagerID = MyUser.Id;  product.UserID = MyUser.Id; _productDal.Add(product);
      }
    }
    public Product Get(int id)
    {
      
      return MyUser.Roleid != 1
          ? _productDal.Get(Product => Product.Id == id && Product.ManagerID == MyUser.ManagerId)
          : _productDal.Get(Product => Product.Id == id);
    }

    public void Delete(Product product)
    { if (MyUser.Roleid == 2 || MyUser.Roleid == 1) { _productDal.Delete(product);       }    }

    public void Update(Product product)
    { if (MyUser.Roleid == 2 || MyUser.Roleid == 1) { _productDal.Update(product); } }

    public bool BuyProduct( Product product)
     {
      var data = new Buy();
      var realProduct = Get(product.Id);
      if (MyUser.Roleid == 1) 
      {
        if (product.Quantity > realProduct.Stock)
        {
          return false;
        }
        else
        {
          data.ManagerId = product.ManagerID;
          data.ProductId = product.Id;
          data.UserId = product.UserID;
          data.Quantity = product.Quantity;
          _buyDal.Add(data);
          realProduct.Stock -= product.Quantity;
          Update(realProduct);
          return true;
        }
      }
     
     
      return false;
    }

    //sell side
    public bool SellProduct( Product product)
    {
      var data = new Sell();      var realProduct = Get(product.Id);

      if (MyUser.Roleid == 3 || MyUser.Roleid == 2)
      {
        if (product.Quantity> realProduct.Stock) return false;
        else
        {
          data.ProductId = product.Id;
          data.UserId = product.UserID;
          data.Quantity = product.Quantity;
          _selldal.Add(data);
           realProduct.Stock -= product.Quantity;
          Update(product);
          return true;
        }
      }
      return false;
    }
    public List<Product> SellList()
    {
      var newlist = new List<Product>();
      foreach (var item in _selldal.GetList())
      {
        var product = _productDal.Get(x => x.Id == item.ProductId);
        product.Quantity = item.Quantity;
        newlist.Add(product);
      }
      return newlist;
    }

    public List<Product> BuyList()
    {
      var newlist = new List<Product>();
      foreach (var item in _buyDal.GetList())
      {
        var product = _productDal.Get(x => x.Id == item.ProductId);
        product.Quantity = item.Quantity;
        newlist.Add(product);
       // newlist.Add(Get(item.ProductId));
      }
      return newlist;
    }
  }
}

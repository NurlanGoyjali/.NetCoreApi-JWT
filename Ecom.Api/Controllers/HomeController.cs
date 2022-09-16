using Ecom.Bussines.Complex_Type;
using Ecom.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ecom.Api.Controllers  
{
  [Authorize]
  [Route("home")]
  public class ProductController : Controller
  {
    private IProductService _ProductService;
    public ProductController(IProductService productService)
    {   _ProductService = productService;   }
    [HttpGet("getproduct")]
    public IActionResult GetProduct(int id)
    {  var getall = _ProductService.Get(id);   return Ok(getall);   }

    [HttpGet("getlist")]
    public IActionResult getList()
    { var newlist = _ProductService.getAll();   return Json(newlist);  }

    [HttpPost("addproduct")]
    public IActionResult addProduct(Product product)
    {
      try { _ProductService.Add(product);   return Ok("eklendi");  }
      catch{ return BadRequest("Eklenmedi");  }
    }


    [HttpPost("delete")]
    public IActionResult Delete(Product product)
    {   try {  _ProductService.Delete(product);  return Ok("silindi"); }
        catch {  return BadRequest("Silinmedi :( ");  }
    }
    [HttpPost("Sell")]
    public IActionResult Sell(Product product)
    {  return Ok(_ProductService.SellProduct(product) ); }

    [HttpGet("Selllist")]
    public IActionResult SellList()
    { return Ok(_ProductService.SellList()); }

    [HttpPost("Buy")]
    public IActionResult Buy( Product product)
    { return Ok(_ProductService.BuyProduct(product)); }
    [HttpGet("BuyList")]
    public IActionResult BuyList()
    {      return Ok(_ProductService.BuyList());   }

  }
}
  

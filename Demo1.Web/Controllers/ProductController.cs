using Demo1.Web.Models;
using Demo1.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo1.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDetailedDto> products = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
                products = JsonConvert.DeserializeObject<List<ProductDetailedDto>>(Convert.ToString(response.Result));
            return View(products);
        }
    }
}

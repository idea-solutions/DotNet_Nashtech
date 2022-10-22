using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
using Assignment02.Models;

namespace Assignment02.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public AddProductResponse? Add([FromBody] AddProductRequest addRequest)
    {
        return _productService.Create(addRequest);
    }
}
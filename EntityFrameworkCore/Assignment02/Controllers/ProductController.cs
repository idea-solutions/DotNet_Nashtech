using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
using Assignment02.Models;

namespace Assignment02.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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

    [HttpGet]
    public IEnumerable<GetProductResponse>? GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id}", Name = "GetByProductId")]
    public GetProductResponse? GetById(int id)
    {
        return _productService.GetById(id);
    }

    [HttpPut("{id}", Name = "UpdateProduct")]
    public UpdateProductResponse? Update(int id, [FromBody] UpdateProductRequest updateModel)
    {
        return _productService.Update(id, updateModel);
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    public bool Delete(int id)
    {
        return _productService.Delete(id);
    }
}
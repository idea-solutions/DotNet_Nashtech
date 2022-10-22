using Assignment02.Models;

namespace Assignment02.Services;

public interface IProductService
{
    AddProductResponse? Create(AddProductRequest createModel);
    IEnumerable<GetProductResponse> GetAll();
    GetProductResponse? GetById(int id);
    UpdateProductResponse? Update(int id, UpdateProductRequest updateModel);
    bool Delete(int id);
}
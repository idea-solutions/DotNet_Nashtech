using Assignment02.Models;

namespace Assignment02.Services;

public interface IProductService
{
    AddProductResponse? Create(AddProductRequest createModel);
    // IEnumerable<GetStudentResponse> GetAll();
    // GetStudentResponse? GetOne(int id);
    // UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel);
    // bool Delete(int id);
}
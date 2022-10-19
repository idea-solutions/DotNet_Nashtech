using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Services;

public interface IStudentService
{
    AddStudentResponse Create(AddStudentRequest createModel);
    public IEnumerable<GetStudentResponse> GetAll();
    GetStudentResponse? GetOne(int id);
    UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel);
    bool Delete(int id);
}
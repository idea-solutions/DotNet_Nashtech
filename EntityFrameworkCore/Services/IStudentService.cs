using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Services;

public interface IStudentService
{
    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<Student> GetAll();
    Student? GetOne(int id);
}
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentManagementContext context) : base(context)
    {

    }
}
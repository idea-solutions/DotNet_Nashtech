using EntityFrameworkCore.Models;
using EntityFrameworkCore.Repositories;

namespace EntityFrameworkCore.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public AddStudentResponse Create(AddStudentRequest createModel)
    {
        var createStudent = new Student
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            City = createModel.City,
            State = createModel.State
        };

        var student = _studentRepository.Create(createStudent);

        _studentRepository.SaveChanges();

        return new AddStudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName
        };
    }

    public IEnumerable<Student> GetAll()
    {
        var getList = _studentRepository.GetAll(x => true);
        _studentRepository.SaveChanges();

        return getList;
    }

    public Student? GetOne(int id)
    {

        var student = _studentRepository.GetOne(x => x.Id == id);

        if (student != null)
        {
            return student;
        };

        return null;
    }
}
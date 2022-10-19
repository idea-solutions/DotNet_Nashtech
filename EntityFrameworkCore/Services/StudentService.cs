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

    public bool Delete(int id)
    {
        var student = _studentRepository.GetOne(s => s.Id == id);

        if (student != null)
        {
            bool result = _studentRepository.Delete(student);

            _studentRepository.SaveChanges();

            return result;
        }

        return false;
    }

    public IEnumerable<GetStudentResponse> GetAll()
    {
        var listStudent = _studentRepository.GetAll(x => true).Select(student => new GetStudentResponse
        {
            StudentId = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            City = student.City,
            State = student.State
        });

        _studentRepository.SaveChanges();

        return listStudent;
    }

    public GetStudentResponse? GetOne(int id)
    {

        var student = _studentRepository.GetOne(x => x.Id == id);

        if (student != null)
        {
            return new GetStudentResponse
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            };
        };

        return null;
    }

    public UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel)
    {
        var student = _studentRepository.GetOne(s => s.Id == id);

        if (student != null)
        {
            student.FirstName = updateModel.FirstName;
            student.LastName = updateModel.LastName;
            student.City = updateModel.City;
            student.State = updateModel.State;

            var updateStudent = _studentRepository.Update(student);

            _studentRepository.SaveChanges();

            return new UpdateStudentResponse
            {
                FirstName = updateStudent.FirstName,
                LastName = updateStudent.LastName,
                City = updateStudent.City,
                State = updateStudent.State
            };
        }

        return null;
    }
}
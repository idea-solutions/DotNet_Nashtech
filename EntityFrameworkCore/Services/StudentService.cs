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

    // public GetAllStudentsResponse GetAll()
    // {
    //     var getList = _studentRepository.GetAll();
    //     _studentRepository.SaveChanges();
    //     return getList
    // }

    // public int? Create(StudentCreateModel createModel)
    // {
    //     var createStudent = new Student
    //     {
    //         FirstName = createModel.FirstName,
    //         LastName = createModel.LastName,
    //         City = createModel.City,
    //         State = createModel.State
    //     };

    //     createStudent = _studentRepository.Create(createStudent);

    //     return createStudent?.Id;
    // }

    // public bool Delete(int id)
    // {
    //     return _studentRepository.Delete(id);
    // }

    // public IEnumerable<StudentViewModel> GetAll()
    // {
    //     var viewModels = _studentRepository
    //         .GetAll()
    //         .Select(student => new StudentViewModel
    //         {
    //             FirstName = student.FirstName,
    //             LastName = student.LastName,
    //             City = student.City,
    //             State = student.State
    //         });

    //     return viewModels;
    // }

    // public StudentViewModel? GetById(int id)
    // {
    //     var student = _studentRepository.GetById(id);

    //     if (student == null) return null;

    //     var viewModel = new StudentViewModel
    //     {
    //         FirstName = student.FirstName,
    //         LastName = student.LastName,
    //         City = student.City,
    //         State = student.State
    //     };

    //     return viewModel;
    // }

    // public StudentViewModel? Update(int id, StudentUpdateModel updateModel)
    // {
    //     var student = _studentRepository.GetById(id);

    //     if (student == null) return null;

    //     student.FirstName = updateModel.FirstName;
    //     student.LastName = updateModel.LastName;
    //     student.City = updateModel.City;
    //     student.State = updateModel.State;

    //     student = _studentRepository.Update(student);

    //     if (student == null) return null;

    //     var viewModel = new StudentViewModel
    //     {
    //         FirstName = student.FirstName,
    //         LastName = student.LastName,
    //         City = student.City,
    //         State = student.State
    //     };

    //     return viewModel;
    // }
}
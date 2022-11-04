using Moq;
using Microsoft.AspNetCore.Mvc;
using Assignment03.Services;
using Assignment03.Controllers;
using Assignment03.Models;

namespace ControllerUnitTest;

public class ControllerUnitTest
{

    private MemberController _memberController;
    private Mock<IServices> _memberService = new Mock<IServices>();


    [SetUp]
    public void Setup()
    {
        _memberController = new MemberController(_memberService.Object);
    }

    [Test]
    public void GetAllMembers()
    {
        // Arrange
        List<MemberViewModel> _member = new()
        {
            new MemberViewModel()
            {
                FullName = "Van Hoan",
                Gender = "Male",
                BirthPlace = "ThaiBinh",
            },
             new MemberViewModel()
            {
                FullName = "Nguyen Hong",
                Gender = "Female",
                BirthPlace = "HaNoi",
            }
        };

        _memberService.Setup(s => s.GetListMember())
                        .Returns(_member);

        // Act  
        var result = _memberController.Index();
        var view = (ViewResult)result;
        var list = view.ViewData.Model as List<MemberViewModel>;

        // Assert
        Assert.AreEqual(2, list?.Count());
    }

    [Test]
    public void Create_Valid_ReturnIndex()
    {
        // Arrange
        var mockModel = new CreateMemberRequest
        {
            FirstName = "Hoan",
            LastName = "Van Hoan",
            Gender = 1,
            DateOfBirth = new DateTime(2002, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi"
        };

        // Act
        var result = _memberController.Create(mockModel);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo((result as RedirectToActionResult)?.ActionName));
    }

    [Test]
    public void Create_Invalid_ReturnsToView()
    {
        // Arrange
        var key = "ERROR";
        var message = "Model is invalid";

        _memberController.ModelState.AddModelError(key, message);

        // Act
        var result = _memberController.Create();
        var view = (ViewResult)result;
        var modelState = view.ViewData.ModelState;
        modelState.TryGetValue(key, out var value);
        var error = value?.Errors.First().ErrorMessage;

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsFalse(modelState.IsValid);
        Assert.AreEqual(1, modelState.ErrorCount);
        Assert.AreEqual(message, error);
    }

    [Test]
    public void Details_Valid_ReturnsToView()
    {
        /// Arrange
        int index = 0;
        var response = new Member()
        {
            FirstName = "test 1",
            LastName = "test 2",
        };

        _memberService.Setup(s => s.GetOneMember((index)))
                .Returns(response);

        // Act
        var result = _memberController.Details(index);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Details_InValid_ReturnsToNotFound()
    {
        // Arrange
        int index = -1;

        _memberService.Setup(s => s.GetOneMember(It.IsAny<int>()))
                .Returns(null as Member);

        // Act
        var result = _memberController.Details(index);

        // Assert
        Assert.IsInstanceOf<ContentResult>(result);
        var contentResult = (ContentResult)result;
        Assert.AreEqual("NotFound", contentResult.Content);
    }

    [Test]
    public void Edit_InValid_ReturnView()
    {
        // Arrange
        int index = -1;

        _memberService.Setup(s => s.GetOneMember(It.IsAny<int>()))
                .Returns(null as Member);

        // Act
        var result = _memberController.Edit(index);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result);
    }

    [Test]
    public void Delete_Valid_ReturnToIndex()
    {
        // Arrange
        int index = 1;
        var response = new Member()
        {
            FirstName = "test 1",
            LastName = "test 2",
        };

        _memberService.Setup(s => s.DeleteMember(It.IsAny<int>()))
                .Returns(response);

        // Act
        var result = (RedirectToActionResult)_memberController.Delete(index);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ActionName);
    }

}
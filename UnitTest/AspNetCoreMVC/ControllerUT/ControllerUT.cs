using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Assignment03.Controllers;
using Assignment03.Services;
using Assignment03.Models;

namespace ControllerUT;

public class ControllerUT
{
    private MemberController _memberController;
    private Mock<IServices> _memberService;

    private static List<Member> _members = new List<Member>()
        {
             new Member{
                    FirstName = "Hoan",
                    LastName = "Nguyen Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(2000,11,09),
                    PhoneNumber = "0123456789",
                    BirthPlace = "Thai Binh",
                    IsGraduated = true
                },
                new Member{
                    FirstName = "Huy",
                    LastName = "Nguyen Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(2001,01,01),
                    PhoneNumber = "9876543210",
                    BirthPlace = "Bac Ninh",
                    IsGraduated = false
                },
                new Member{
                    FirstName = "Trang",
                    LastName = "Pham Thuy",
                    Gender = 2,
                    DateOfBirth = new DateTime(1998,05,07),
                    PhoneNumber = "01213141516",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true
                }
        };


    [SetUp]
    public void Setup()
    {
        _memberService = new Mock<IServices>();
        _memberController = new MemberController(_memberService.Object);
    }

    [Test]
    public void Create_Valid_ReturnsRedirectToActionIndex()
    {
        var mockModel = new CreateMemberRequest
        {
            FirstName = "Hoan",
            LastName = "Nguyen Van",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 11, 09),
            PhoneNumber = "0123456789",
            BirthPlace = "Thai Binh",
        };

        var result = _memberController.Create(mockModel);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo((result as RedirectToActionResult).ActionName));
    }

    [Test]
    public void Create_Invalid_ReturnsToViewModel()
    {
        var key = "ERROR";
        var message = "Model is invalid";

        _memberController.ModelState.AddModelError(key, message);
        var model = new CreateMemberRequest();

        var result = _memberController.Create();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        var modelState = view.ViewData.ModelState;

        Assert.IsFalse(modelState.IsValid);
        Assert.AreEqual(1, modelState.ErrorCount);
        modelState.TryGetValue(key, out var value);
        var error = value?.Errors.First().ErrorMessage;
        Assert.AreEqual(message, error);
    }

}
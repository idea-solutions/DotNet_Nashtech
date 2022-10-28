using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC.Controllers;
using AspNetCoreMVC.Services;

namespace RookiesControllerUT;

public class RookiesControllerTests
{
    private MemberController _memberController;
    private Mock<IServices> _memberService;

    [SetUp]
    public void Setup()
    {
        _memberService = new Mock<IServices>();
        _memberController = new MemberController(_memberService.Object);
    }

    [Test]
    public void Index_ReturnsAllMembers()
    {
        var expectedList = new List<MemberViewModel>
        {
            new MemberViewModel(),
            new MemberViewModel()
        };

        _memberService
            .Setup(ps => ps.GetListMember())
            .Returns(expectedList);

        var result = _memberController.Index();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var model = ((ViewResult)result).Model;

            Assert.That(model, Is.AssignableTo<IEnumerable<MemberViewModel>>());

            Assert.That(model as List<MemberViewModel>, Has.Count.EqualTo(expectedList.Count));
        });
    }

}
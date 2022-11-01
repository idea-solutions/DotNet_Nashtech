using Assignment02.Models;

namespace Assignment02.Services
{
    public interface IMemberService
    {
        List<MemberRequestModel> GetAll();
        MemberRequestModel? GetOne(Guid id);
        MemberRequestModel Create(MemberRequestModel model);
        MemberRequestModel? Update(Guid id, MemberRequestModel model);
        bool Delete(Guid id);
        IEnumerable<MemberRequestModel> GetPagnition(Pagnition pagnition);
        List<MemberRequestModel> FilterList(string? firstName, string? lastName, string? gender, string? birthPlace);
    }
}
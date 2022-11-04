using Assignment03.Models;
namespace Assignment03.Services
{
    public interface IServices
    {
        List<MemberViewModel> GetListMember();
        Member GetOneMember(int index);
        void AddMember(CreateMemberRequest request);
        List<EditMemberViewModel> GetListEdit();
        void UpdateMember(int index, EditMemberViewModel model);
        Member? DeleteMember(int index);
    }
}
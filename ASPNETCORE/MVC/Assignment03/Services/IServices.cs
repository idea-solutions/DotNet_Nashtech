namespace Assignment03.Services
{
    public interface IServices
    {
        List<MemberViewModel> GetListMember();
        void AddMember(CreateMemberRequest request);
        List<EditMemberViewModel> GetListEdit();
        void UpdateMember(int index, EditMemberViewModel model);
        void DeleteMember(int index);
    }
}
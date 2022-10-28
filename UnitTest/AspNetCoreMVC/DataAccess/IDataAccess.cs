namespace AspNetCoreMVC.DataAccess
{
    public interface IDataAccess
    {
        List<Member> GetAllMember();
        void AddMember(Member member);
        void UpdateMember(int index, Member member);
        void DeleteMember(int index);
    }
}
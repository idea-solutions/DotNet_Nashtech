namespace Assignment01.DataAccess
{
    public class StaticMemberDataAccess : IDataAccess
    {
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

        public List<Member> Members
        {
            get => _members;
            set
            {
                _members = value;
            }
        }

        public List<Member> GetAllMember()
        {
            return Members;
        }

        public StaticMemberDataAccess()
        {

        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void UpdateMember(int index, Member member)
        {
            Members[index] = member;
        }

        public void DeleteMember(int index)
        {
            Members.RemoveAt(index);
        }
    }
}
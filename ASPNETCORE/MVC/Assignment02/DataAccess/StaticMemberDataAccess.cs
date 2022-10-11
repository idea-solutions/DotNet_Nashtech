
namespace Assignment02.DataAccess
{
    public class StaticMemberDataAccess
    {
        private static List<Member> Member = new List<Member>()
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

        public StaticMemberDataAccess()
        {

        }

        public List<Member> GetListMember()
        {
            return Member;
        }

        public void AddMember(Member member)
        {
            Member.Add(member);
        }
    }
}
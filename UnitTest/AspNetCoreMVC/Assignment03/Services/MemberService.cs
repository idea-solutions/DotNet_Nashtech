using Assignment03.Models;

namespace Assignment03.Services
{
    public class MemberService : IServices
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

        public List<MemberViewModel> GetListMember()
        {
            var listViewModels = new List<MemberViewModel>();

            foreach (var item in _members)
            {
                listViewModels.Add(new MemberViewModel
                {
                    FullName = item.FullName,
                    DateOfBirth = item.DateOfBirth.ToString("dd/MM/yyyy"),
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                    Gender = item.Gender == 1 ? "Male" : item.Gender == 2 ? "Female" : "Other",
                    Age = item.Age,
                });
            }

            return listViewModels;
        }

        public Member GetOneMember(int index)
        {

            return _members[index];
        }

        public void AddMember(CreateMemberRequest request)
        {
            Member member = new Member
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                BirthPlace = request.BirthPlace,
                IsGraduated = false
            };

            _members.Add(member);
        }

        public List<EditMemberViewModel> GetListEdit()
        {
            var listViewModels = new List<EditMemberViewModel>();

            foreach (var item in _members)
            {
                listViewModels.Add(new EditMemberViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                });
            }

            return listViewModels;
        }

        public void UpdateMember(int index, EditMemberViewModel model)
        {
            var member = _members[index];

            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.PhoneNumber = model.PhoneNumber;
            member.BirthPlace = model.BirthPlace;

            _members[index] = member;
        }

        public void DeleteMember(int index)
        {
            _members.RemoveAt(index);
        }

    }
}
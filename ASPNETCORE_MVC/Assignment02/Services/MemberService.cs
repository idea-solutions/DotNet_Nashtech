using Assignment02.DataAccess;

namespace Assignment02.Services
{
    public class MemberService
    {
        private readonly StaticMemberDataAccess _dataAccess;
        public MemberService()
        {
            _dataAccess = new StaticMemberDataAccess();
        }

        public List<MemberViewModel> GetListMember()
        {
            var listApplicationModels = _dataAccess.Members;
            var listViewModels = new List<MemberViewModel>();

            foreach (var item in listApplicationModels)
            {
                listViewModels.Add(new MemberViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateOfBirth = item.DateOfBirth.ToString("dd/MM/yyyy"),
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                    Gender = item.Gender == 1 ? "Male" : item.Gender == 2 ? "Female" : "Other",
                    Age = item.Age,
                });
            }

            return listViewModels;
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

            _dataAccess.AddMember(member);
        }

        public List<EditMemberViewModel> GetListEdit()
        {
            var listApplicationModels = _dataAccess.Members;
            var listViewModels = new List<EditMemberViewModel>();

            foreach (var item in listApplicationModels)
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
            var member = _dataAccess.Members[index];

            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.PhoneNumber = model.PhoneNumber;
            member.BirthPlace = model.BirthPlace;

            _dataAccess.UpdateMember(index, member);
        }

        public void DeleteMember(int index)
        {
            _dataAccess.DeleteMember(index);
        }

    }
}
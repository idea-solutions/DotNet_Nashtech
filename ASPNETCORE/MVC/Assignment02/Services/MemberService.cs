using Assignment02.DataAccess;

namespace Assignment02.Services
{
    public class MemberService
    {
        public readonly StaticMemberDataAccess _dataAccess;
        public MemberService()
        {
            _dataAccess = new StaticMemberDataAccess();
        }

        public List<MemberViewModel> GetListMember()
        {
            var listApplicationModels = _dataAccess.GetListMember();

            var listViewModels = new List<MemberViewModel>();
            foreach (var item in listApplicationModels)
            {
                listViewModels.Add(new MemberViewModel
                {
                    FullName = item.FullName,
                    DateOfBirth = item.DateOfBirth.ToString("dd/MM/yyyy"),
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                    //Gender = 1 => Male; Gender = 2 => Female; Gender = .... => Other
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
    }
}
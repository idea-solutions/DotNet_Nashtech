using Assignment02.Models;

namespace Assignment02.Services
{
    public class MemberService : IMemberService
    {
        private static List<MemberRequestModel> _members = new List<MemberRequestModel>
        {
            new MemberRequestModel()
            {
                FirstName = "Hoan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 09),
                BirthPlace = "Thai Binh"
            },
            new MemberRequestModel()
            {
                FirstName = "Hung",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 01, 30),
                BirthPlace = "Ha Noi"
            },
            new MemberRequestModel()
            {
                FirstName = "Linh",
                LastName = "pham",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 07, 15),
                BirthPlace = "Hai Duong"
            }
        };


        public MemberRequestModel Create(MemberRequestModel model)
        {
            MemberRequestModel member = new MemberRequestModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                BirthPlace = model.BirthPlace,
            };

            _members.Add(member);

            return model;
        }

        public bool Delete(Guid id)
        {
            var data = _members.FindIndex(p => p.UniqueId.Equals(id));

            if (data < 0)
            {
                return false;
            }
            _members.RemoveAt(data);

            return true;
        }

        public List<MemberRequestModel> FilterList(string? firstName, string? lastName, string? gender, string? birthPlace)
        {
            var filter = _members
            .Where(f => f.FirstName == firstName)
            .Where(l => l.LastName == lastName)
            .Where(g => g.Gender.ToLower().Trim() == gender.ToLower().Trim())
            .Where(b => b.BirthPlace.ToLower().Trim() == birthPlace.ToLower().Trim());

            return filter.ToList();
        }

        public List<MemberRequestModel> GetAll()
        {
            return _members;
        }

        public MemberRequestModel? GetOne(Guid id)
        {
            return _members.FirstOrDefault(p => p.UniqueId.Equals(id));
        }

        public IEnumerable<MemberRequestModel> GetPagnition(Pagnition pagnition)
        {
            return GetAll()
                .OrderBy(on => on.FirstName)
                .Skip((pagnition.PageNumber - 1) * pagnition.PageSize)
                .Take(pagnition.PageSize)
                .ToList();
        }

        public MemberRequestModel? Update(Guid id, MemberRequestModel model)
        {
            var data = _members.FindIndex(p => p.UniqueId.Equals(id));
            if (data < 0)
            {
                return null;
            }
            _members[data] = model;

            return _members[data];
        }
    }
}
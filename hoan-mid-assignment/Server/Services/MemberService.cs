using AspNetCoreAPI.Models;

namespace AspNetCoreAPI.Services
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

        public IEnumerable<MemberRequestModel> GetAll(string? name = null, string? gender = null, string? birthPlace = null)
        {
            var entities = _members.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                entities = entities.Where(member => member.FullName == name.Trim());
            }

            if (!string.IsNullOrEmpty(gender))
            {
                var queryGender = "";

                if (string.Equals("Male", gender.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    queryGender = "Male";
                }
                else if (string.Equals("Female", gender.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    queryGender = "Female";
                }

                entities = entities.Where(member => member.Gender == queryGender);
            }

            if (!string.IsNullOrEmpty(birthPlace))
            {
                entities = entities.Where(person => person.BirthPlace == birthPlace.Trim());
            }

            return entities;
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
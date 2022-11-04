namespace AspNetCoreAPI.Models
{
    public class MemberRequestModel
    {
        private Guid _uniqueid;
        public Guid UniqueId
        {
            get
            {
                if (_uniqueid == Guid.Empty) _uniqueid = Guid.NewGuid();
                return _uniqueid;
            }
            set
            {
                _uniqueid = value;
            }
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; } = null!;

        public string FullName => $"{FirstName} {LastName}";
    }
}
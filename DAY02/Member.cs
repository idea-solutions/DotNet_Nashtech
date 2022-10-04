namespace Day02
{
    public class Member
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string InfoMember
        {
            get
            {
                string gradute = IsGraduated ? "Yes" : "No";

                return string.Format($"First Name: {FirstName}" + Environment.NewLine +
                $"Last Name: {LastName}" + Environment.NewLine +
                $"Gender: {Gender}" + Environment.NewLine +
                $"Date Of Birth: {DateOfBirth.ToString("dd/MM/yyyy")}" + Environment.NewLine +
                $"Phone Number: {PhoneNumber}" + Environment.NewLine +
                $"Birth Place: {BirthPlace}" + Environment.NewLine +
                $"Age: {Age}" + Environment.NewLine +
                $"Is Graduated: {gradute}");
            }
        }
    }
}
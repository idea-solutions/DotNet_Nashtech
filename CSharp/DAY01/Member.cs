namespace Day01
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

                return string.Format($"First Name: {FirstName}\n\r" +
                $"Last Name: {LastName}\n\r" +
                $"Gender: {Gender}\n\r" +
                $"Date Of Birth: {DateOfBirth.ToString("dd/MM/yyyy")}\n\r" +
                $"Phone Number: {PhoneNumber}\n\r" +
                $"Birth Place: {BirthPlace}\n\r" +
                $"Age: {Age}\n\r" +
                $"Is Graduated: {gradute}\n\r");
            }
        }
    }
}
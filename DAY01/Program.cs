namespace Day01
{
    class Program
    {
        static void Main(string[] agrs)
        {
            List<Member> members = new List<Member> {
                new Member{
                    FirstName = "Hoan",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000,11,09),
                    PhoneNumber = "0123456789",
                    BirthPlace = "Thai Binh",
                    IsGraduated = true
                },
                new Member{
                    FirstName = "Huy",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2001,01,01),
                    PhoneNumber = "9876543210",
                    BirthPlace = "Ninh Binh",
                    IsGraduated = false
                },
                new Member{
                    FirstName = "Trang",
                    LastName = "Pham Thuy",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998,05,07),
                    PhoneNumber = "01213141516",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true
                }
            };

            Console.WriteLine("Cau 1:" + Environment.NewLine + "----------------------------------");
            List<Member> ListMale = new List<Member>();
            foreach (var member in members)
            {
                if (member.Gender == "Male")
                {
                    ListMale.Add(member);
                }
            }
            foreach (var member in ListMale)
            {
                Console.WriteLine($"list Male: {Environment.NewLine}{member.InfoMember}" + Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine + "Cau 2:" + Environment.NewLine + "----------------------------------");
            int max = 0;
            foreach (var member in members)
            {
                if (max < member.Age)
                {
                    max = member.Age;
                }
            }
            foreach (var member in members)
            {
                if (member.Age == max)
                {
                    Console.WriteLine($"Info member with oldest age is: {Environment.NewLine}{member.InfoMember}");
                }
            }

            Console.WriteLine(Environment.NewLine + "Cau 3:" + Environment.NewLine + "----------------------------------");
            foreach (var member in members)
            {
                Console.WriteLine($"Full Name of members: {member.FirstName} {member.LastName}");
            }

            Console.WriteLine(Environment.NewLine + "Cau 4:" + Environment.NewLine + "----------------------------------");
            List<Member> ListYear2000 = new List<Member>();
            List<Member> ListYearGreaterThan2000 = new List<Member>();
            List<Member> ListYearLess2000 = new List<Member>();
            foreach (var member in members)
            {
                switch (member.DateOfBirth.Year)
                {
                    case int x when x == 2000:
                        ListYear2000.Add(member);
                        break;
                    case int x when x is < 2000:
                        ListYearGreaterThan2000.Add(member);
                        break;
                    default:
                        ListYearLess2000.Add(member);
                        break;
                }
            }

            Console.WriteLine("List member birth year is 2000 :");
            foreach (var member in ListYear2000)
            {
                Console.WriteLine(member.InfoMember);
            }

            Console.WriteLine(Environment.NewLine + "List member birth year greater than 2000 :");
            foreach (var member in ListYearGreaterThan2000)
            {
                Console.WriteLine(member.InfoMember);
            }

            Console.WriteLine(Environment.NewLine + "List member birth year less 2000 :");
            foreach (var member in ListYearLess2000)
            {
                Console.WriteLine(member.InfoMember);
            }

            Console.WriteLine(Environment.NewLine + "Cau 5:" + Environment.NewLine + "----------------------------------");
            int index = 0;
            while (index < members.Count)
            {
                if (members[index].BirthPlace == "Ha Noi")
                {
                    Console.WriteLine(members[index].InfoMember);
                    break;
                }
                index++;
            }
        }
    }
}
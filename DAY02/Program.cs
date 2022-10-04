namespace Day02
{
    class Program
    {
        static void Main(string[] agrs)
        {
            // List members
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
                    BirthPlace = "Bac Ninh",
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

            var option = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. List of member who is male: ");
                Console.WriteLine("2. Oldest member is: ");
                Console.WriteLine("3. Full name of members: ");
                Console.WriteLine("4. List members by birth year: ");
                Console.WriteLine("5. First person who was born in Ha Noi is: ");
                Console.WriteLine();
                Console.Write("Enter key: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ListMale(members);
                        break;
                    case 2:
                        OldestMember(members);
                        break;
                    case 3:
                        ListFullNameMember(members);
                        break;
                    case 4:
                        ListMembersByBirthYear(members);
                        break;
                    case 5:
                        BornInHaNoi(members);
                        break;
                    default:
                        break;
                }
            } while (option > 0 && option < 6);
        }

        public static void ListMale(List<Member> members)
        {
            Console.WriteLine("List of member who is male is: ");
            Console.WriteLine();

            members.Where(member => member.Gender == "Male")
                   .ToList()
                   .ForEach(m => Console.WriteLine(m.InfoMember));
        }

        public static void OldestMember(List<Member> members)
        {
            Console.WriteLine($"Info member with oldest age is: ");
            Console.WriteLine();

            var maxAge = members.Max(member => member.Age);
            Member oldestMember = members.First(m => m.Age == maxAge);

            Console.WriteLine(oldestMember.InfoMember);
            Console.WriteLine();

        }

        public static void ListFullNameMember(List<Member> members)
        {
            Console.WriteLine("Full Name of members: ");
            Console.WriteLine();

            var fullName = members.Select(member => member.FullName).ToList();
            fullName.ForEach(mem => Console.WriteLine(mem));
        }

        public static void ListMembersByBirthYear(List<Member> members)
        {
            var listYear2000 = members.FindAll(member => member.DateOfBirth.Year == 2000);
            var listYearGreaterThan2000 = members.FindAll(member => member.DateOfBirth.Year < 2000);
            var listYearLess2000 = members.FindAll(member => member.DateOfBirth.Year > 2000);
            var option = 0;

            Console.WriteLine("List members by birth year: ");
            Console.WriteLine();

            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1: List of members who has birth year is 2000: ");
                Console.WriteLine("2: List of members who has birth year greater than 2000: ");
                Console.WriteLine("3: List of members who has birth year less than 2000: ");
                Console.WriteLine("4: Exit");
                Console.WriteLine();
                Console.WriteLine("Enter key: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nList member birth year is 2000: ");
                        PrintMembers(listYear2000);
                        break;
                    case 2:
                        Console.WriteLine("\nList member birth year less 2000: ");
                        PrintMembers(listYearLess2000);
                        break;
                    case 3:
                        Console.WriteLine("\nList member birth year more 2000: ");
                        PrintMembers(listYearGreaterThan2000);
                        break;
                    default:
                        break;
                }
            } while (option > 0 && option < 4);

        }
        public static void BornInHaNoi(List<Member> members)
        {
            Console.WriteLine("The first person who was born in Ha Noi is: ");
            var member = members.FindAll(m => m.BirthPlace == "Ha Noi");

            if (member.Count > 0)
            {
                Console.WriteLine(member.First().InfoMember);
            }
        }

        public static void PrintMembers(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine(member.InfoMember);
                Console.WriteLine();
            }
        }
    }
}
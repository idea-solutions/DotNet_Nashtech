namespace Day01
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

            var option = "";
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. List of member who is male: ");
                Console.WriteLine("2. Oldest member is: ");
                Console.WriteLine("3. Full name of members: ");
                Console.WriteLine("4. List members by birth year: ");
                Console.WriteLine("5. First person who was born in Ha Noi is: ");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.Write("Enter key: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ListMale(members);
                        break;
                    case "2":
                        OldestMember(members);
                        break;
                    case "3":
                        ListFullNameMember(members);
                        break;
                    case "4":
                        ListMembersByBirthYear(members);
                        break;
                    case "5":
                        BornInHaNoi(members);
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Wrong choice, please choose again!!");
                        Console.WriteLine();
                        break;
                }
            } while (option != "6");
        }

        public static void ListMale(List<Member> members)
        {
            List<Member> ListMale = new List<Member>();
            Console.WriteLine("List of member who is male is: " + Environment.NewLine);

            foreach (Member member in members)
            {
                if (member.Gender == "Male")
                {
                    ListMale.Add(member);
                }
            }

            PrintMembers(ListMale);
        }

        public static void OldestMember(List<Member> members)
        {
            int maxAge = 0;
            Console.WriteLine();

            foreach (Member member in members)
            {
                if (maxAge < member.Age)
                {
                    maxAge = member.Age;
                }
            }

            foreach (Member member in members)
            {
                if (member.Age == maxAge)
                {
                    Console.WriteLine($"Info member with oldest age is: " + Environment.NewLine);
                    Console.WriteLine(member.InfoMember + Environment.NewLine);
                    break;
                }
            }
        }

        public static void ListFullNameMember(List<Member> members)
        {
            Console.WriteLine("Full Name of members: " + Environment.NewLine);

            foreach (Member member in members)
            {
                Console.WriteLine(member.FullName);
            }
        }

        public static void ListMembersByBirthYear(List<Member> members)
        {
            List<Member> listYear2000 = new List<Member>();
            List<Member> listYearGreaterThan2000 = new List<Member>();
            List<Member> listYearLess2000 = new List<Member>();

            Console.WriteLine("List members by birth year: " + Environment.NewLine);
            foreach (Member member in members)
            {
                switch (member.DateOfBirth.Year)
                {
                    case int x when x == 2000:
                        listYear2000.Add(member);
                        break;
                    case int x when x is < 2000:
                        listYearGreaterThan2000.Add(member);
                        break;
                    default:
                        listYearLess2000.Add(member);
                        break;
                }
            }

            var option = "";
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1: List of members who has birth year is 2000: ");
                Console.WriteLine("2: List of members who has birth year greater than 2000: ");
                Console.WriteLine("3: List of members who has birth year less than 2000: ");
                Console.WriteLine("4: Exit");
                Console.WriteLine();
                Console.WriteLine("Enter key: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("\nList member birth year is 2000 : ");
                        PrintMembers(listYear2000);
                        break;
                    case "2":
                        Console.WriteLine("\nList member birth year less 2000 :");
                        PrintMembers(listYearLess2000);
                        break;
                    case "3":
                        Console.WriteLine("\nList member birth year more 2000 :");
                        PrintMembers(listYearGreaterThan2000);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Wrong choice, please choose again!!");
                        Console.WriteLine();
                        break;
                }
            } while (option != "4");

        }
        public static void BornInHaNoi(List<Member> members)
        {
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

        public static void PrintMembers(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine(member.InfoMember + Environment.NewLine);
            }
        }
    }
}
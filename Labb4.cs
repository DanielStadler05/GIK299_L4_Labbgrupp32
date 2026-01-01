using System;
using System.Collections.Generic;


namespace Sprint2
{
    public enum Gender
    {
        
        Female = 1,
        Male = 2,
        Nonbinare = 3,
        Other = 4
    }

    public struct Hair
    {
        public string Color { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Hairlength: {Length}, Haircolor:{Color}";
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Hair Hair { get; set; }

        public string EyeColor { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()

        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Gender: {Gender}\n" +
                   $"Hair: {Hair.Color}, {Hair.Length} cm\n" +
                   $"Birthday: {Birthday:yyyy-MM-dd}";
        }
    }

    internal class Labb4
    {
        static List<Person> persons = new List<Person>();

        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine(("1. Add a person"));
                Console.WriteLine(("2. List of persons"));
                Console.WriteLine(("3. End"));
                Console.WriteLine(("Choice: "));

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        ListPersons();
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Choice.\n" + "Try Again. :)");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddPerson()
        {
            Person person = new Person();

            Console.WriteLine("FirstName:");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("LastName:");
            person.LastName = Console.ReadLine();

            bool validGender = false;
            while (!validGender)
            {
                Console.WriteLine("Choose Gender:");
                Console.WriteLine("1. Female");
                Console.WriteLine("2. Male");
                Console.WriteLine("3. Nonbinare");
                Console.WriteLine("4. Other");

                if (int.TryParse(Console.ReadLine(), out int g) &&
                    Enum.IsDefined(typeof(Gender), g))

                {
                    person.Gender = (Gender)g;
                    validGender = true;
                }
                else
                {
                    Console.WriteLine("Answer not valid, try again.");
                }
            }

            bool validDate = false;
            while (!validDate)
            {
                Console.WriteLine("Birthday date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    person.Birthday = date;
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Answer not valid, try again.");
                }

            }

            Console.Write("Eye Color: ");
            person.EyeColor = Console.ReadLine();

            Hair hair = new Hair();
            bool validLength = false;

            Console.Write("HairColor: ");
            hair.Color = Console.ReadLine();

            while (!validLength)
            {
                Console.Write("Hair Lenght (cm): ");
                if (int.TryParse(Console.ReadLine(), out int length))
                {
                    hair.Length = length;
                    validLength = true;

                }
                else
                {
                    Console.WriteLine("Answer not valid, try again.");
                }
            }


            person.Hair = hair;

            persons.Add(person);
            Console.WriteLine("Person has been added.");
        }

        static void ListPersons()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("No person added yet.");
                return; 
            }

            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());
            }

   
                    

        }
    }
}

    
    
    
    
    
namespace _09.ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Citizen citizen = new(citizenInfo[0], citizenInfo[1], int.Parse(citizenInfo[2]));
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

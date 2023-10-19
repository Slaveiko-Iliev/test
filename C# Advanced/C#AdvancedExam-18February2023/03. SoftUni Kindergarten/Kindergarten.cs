using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public List<Child> Registry { get; private set; }
        public int ChildrenCount => Registry.Count;


        public bool AddChild(Child child)
        {
            bool isThereRoom = true;

            if(Registry.Count == Capacity)
            {
                isThereRoom = false;
            }
            else
            {
                Registry.Add(child);
            }

            return isThereRoom;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] fullName = childFullName
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            return Registry.Remove(Registry.FirstOrDefault(x => x.FirstName == fullName[0] && x.LastName == fullName[1]));
        }

        public Child GetChild(string childFullName)
        {
            string[] fullName = childFullName
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            return Registry.FirstOrDefault(x => x.FirstName == fullName[0] && x.LastName == fullName[1]);
        }

        public string RegistryReport()
        {
            string temp = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                stringBuilder.AppendLine(child.ToString());
            }

            temp = stringBuilder.ToString().Trim();

            return temp;
        }
    }
}

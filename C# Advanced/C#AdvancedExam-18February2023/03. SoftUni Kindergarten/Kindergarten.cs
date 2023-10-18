using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            KindergartenName = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string KindergartenName { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount
        {
            get { return Registry.Count; }
        }


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

            Child child = Registry.Find(x => x.FirstName == fullName[0] && x.LastName == fullName[1]);

            return Registry.Remove(child);
        }

        public Child GetChild(string childFullName)
        {
            string[] fullName = childFullName
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            if (Registry.Find(x => x.FirstName == fullName[0] && x.LastName == fullName[1]) != null)
            {
                return Registry.Find(x => x.FirstName == fullName[0] && x.LastName == fullName[1]);
            }
            else
            {
                return null;
            }
        }

        public string RegistryReport()
        {
            string temp = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Registered children in {KindergartenName}:");
            foreach (var child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                stringBuilder.AppendLine(child.ToString());
            }

            temp = stringBuilder.ToString().Trim();

            return temp;
        }
    }
}

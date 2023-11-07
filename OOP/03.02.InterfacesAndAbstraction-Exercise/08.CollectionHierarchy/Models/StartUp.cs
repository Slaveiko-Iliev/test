using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class StartUp
    {
        public static void Main()
        {
            IAddable addCollection = new AddCollection();
            IAddRemovable addRemoveCollection = new AddRemoveCollection();
            IAddRemoveWithUsed myList = new MyList();

            List<int> addResultInAddColection = new ();
            List<int> addResultInAddRemoveColection = new ();
            List<int> addResultInMyList = new ();
            List<string> removeResultInAddRemoveColection = new ();
            List<string> removeResultInMyList = new ();

            string[] inputToAdd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in inputToAdd)
            {
                addResultInAddColection.Add(addCollection.Add(str));
                addResultInAddRemoveColection.Add(addRemoveCollection.Add(str));
                addResultInMyList.Add(myList.Add(str));
            }

            int countToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < countToRemove; i++)
            {
                removeResultInAddRemoveColection.Add(addRemoveCollection.Remove());
                removeResultInMyList.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addResultInAddColection));
            Console.WriteLine(string.Join(" ", addResultInAddRemoveColection));
            Console.WriteLine(string.Join(" ", addResultInMyList));
            Console.WriteLine(string.Join(" ", removeResultInAddRemoveColection));
            Console.WriteLine(string.Join(" ", removeResultInMyList));
        }
    }
}

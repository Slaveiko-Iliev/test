using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IAddRemoveWithUsed
    {
        private List<string> _collectionName;

        public MyList()
        {
            _collectionName = new List<string>();
        }

        public int Used { get => _collectionName.Count; }

        public int Add(string str)
        {
            _collectionName.Insert(0, str);

            return 0;
        }
        public string Remove()
        {
            string result = _collectionName[0];
            _collectionName.RemoveAt(0);
            return result;
        }
    }
}

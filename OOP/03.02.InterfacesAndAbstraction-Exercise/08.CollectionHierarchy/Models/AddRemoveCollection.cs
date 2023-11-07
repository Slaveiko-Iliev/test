using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemovable
    {
        private List<string> _collectionName;

        public AddRemoveCollection()
        {
            _collectionName = new List<string>();
        }

        public int Add(string str)
        {
            _collectionName.Insert(0, str);

            return 0;
        }
        public string Remove()
        {
            string result = _collectionName[_collectionName.Count - 1];
            _collectionName.RemoveAt(_collectionName.Count - 1);
            return result;
        }
    }
}

using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private List<string> _collectionName;

        public AddCollection()
        {
            _collectionName = new List<string>();
        }

        public int Add(string str)
        {
            _collectionName.Add(str);

            return _collectionName.Count -1;
        }
    }
}

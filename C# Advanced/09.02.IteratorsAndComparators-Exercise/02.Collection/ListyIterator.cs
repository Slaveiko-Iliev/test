using System.Collections;

namespace Collection;

public class ListyIterator<T> : IEnumerable<T>
{
    private int _index;

    public ListyIterator(List<T> collection)
    {
        Collection = collection;
    }

    public List<T> Collection { get; private set; }


    public bool Move()
    {
        if (_index < Collection.Count - 1)
        {
            _index++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HasNext()
    {
        return _index + 1 < Collection.Count;
    }

    public void Print()
    {
        if (Collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(Collection[_index]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in Collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
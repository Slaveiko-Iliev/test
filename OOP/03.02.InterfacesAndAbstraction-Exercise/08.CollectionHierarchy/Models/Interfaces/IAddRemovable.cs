using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy.Models.Interfaces
{
    public interface IAddRemovable : IAddable
    {
        public string Remove();
    }
}

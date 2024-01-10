using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> _peaks;

        public PeakRepository()
        {
            _peaks = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => _peaks;

        public void Add(IPeak model) => _peaks.Add(model);

        public IPeak Get(string name) => _peaks.FirstOrDefault(x => x.Name == name);
    }
}

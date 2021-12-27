using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perplexity
{
    public class LevelData : IEnumerable<List<int>>
    {
        private List<List<int>> _grid = new List<List<int>>();

        public void Add(List<int> row)
        {
            _grid.Add(row);
        }

        public void AddRange(IEnumerable<List<int>> rows)
        {
            _grid.AddRange(rows);
        }

        public IEnumerator<List<int>> GetEnumerator()
        {
            return _grid.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_grid).GetEnumerator();
        }

        public int Count()
        {
            return _grid.Count();
        }

        public List<int> this[int index]
        {
            get { return _grid[index]; }
        }
    }
}

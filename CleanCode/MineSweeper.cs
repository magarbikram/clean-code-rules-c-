using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class MineSweeper
    {
        private IList<int[]> theList = new List<int[]>();

        public IList<int[]> GetThem()
        {
            IList<int[]> list1 = new List<int[]>();
            foreach (int[] x in theList)
            {
                if (x[0] == 4)
                {
                    list1.Add(x);
                }
            }
            return list1;
        }
    }
}

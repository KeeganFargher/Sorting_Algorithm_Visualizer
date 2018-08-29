using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingLibrary.Algorithms
{
    public class GnomeSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            int pos = 0;
            while (pos < color.Length)
            {
                if (pos == 0 || color[pos].GetHue() >= color[pos - 1].GetHue())
                {
                    pos++;
                }
                else
                {
                    Swap(color, pos, pos - 1);
                    pos--;
                }
                ReportProgress();
                Thread.Sleep(1);
            }
        }

        private static void Swap<T>(IList<T> array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

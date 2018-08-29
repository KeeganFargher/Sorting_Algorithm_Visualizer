using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class CombSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            int gap = color.Length;
            const double shrink = 1.3;
            bool sorted = false;

            while (!sorted)
            {
                gap = (int) Math.Floor(gap / shrink);
                if (gap > 1)
                {
                    sorted = false;
                }
                else
                {
                    gap = 1;
                    sorted = true;
                }

                int i = 0;
                while (i + gap < color.Length)
                {
                    if (color[i].GetHue() > color[i + gap].GetHue())
                    {
                        Swap(color, i, i + gap);
                        sorted = false;
                    }

                    i++;
                    ReportProgress();
                    Thread.Sleep(1);
                }
            }
        }

        private static void Swap<T>(IList<T> array, int left, int right)
        {
            T temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

    }
}


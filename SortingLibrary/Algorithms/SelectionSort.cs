using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingLibrary.Algorithms
{
    public class SelectionSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            for (int k = 0; k < color.Length; k++)
            {
                int smallest = k;
                for (int index = k + 1; index < color.Length; index++)
                {
                    int A_Hue  = (int) Math.Round(color[index].GetHue());
                    int A1_Hue = (int) Math.Round(color[smallest].GetHue());
                    if (A_Hue < A1_Hue)
                    {
                        smallest = index;
                    }

                    ReportProgress();
                }
                Swap(color, k, smallest);
                Thread.Sleep((int) Utility.SleepTime);
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

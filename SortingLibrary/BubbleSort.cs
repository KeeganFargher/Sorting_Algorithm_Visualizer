using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingLibrary
{
    public class BubbleSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            for(int i = 0; i < color.Length; i++)
            {
                for (int j = 0; j < color.Length - i - 1; j++)
                {
                    int A_Hue  = (int) Math.Round(color[j].GetHue());
                    int A1_Hue = (int) Math.Round(color[j + 1].GetHue());
                    if (A_Hue > A1_Hue)
                    {
                        Swap(color, j, j + 1);
                    }
                    ReportProgress();
                }
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

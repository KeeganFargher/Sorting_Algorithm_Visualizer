using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingLibrary.Algorithms
{
    public class CocktailSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            bool swapped = false;
            do
            {
                swapped = false;
                for (int j = 0; j < color.Length - 2; j++)
                {
                    int A_Hue  = (int) Math.Round(color[j].GetHue());
                    int A1_Hue = (int) Math.Round(color[j + 1].GetHue());
                    if (A_Hue > A1_Hue)
                    {
                        Swap(color, j, j + 1);
                        swapped = true;
                    }
                    ReportProgress();
                }
                Thread.Sleep((int) Utility.SleepTime);
                if (!swapped)
                {
                    break;
                }
                swapped = false;

                for (int j = color.Length - 2; j > 0; j--)
                {
                    int A_Hue = (int)Math.Round(color[j].GetHue());
                    int A1_Hue = (int)Math.Round(color[j + 1].GetHue());
                    if (A_Hue > A1_Hue)
                    {
                        Swap(color, j, j + 1);
                        swapped = true;
                    }
                    ReportProgress();
                }
                Thread.Sleep((int) Utility.SleepTime);
            } while (swapped);
        }

        private static void Swap<T>(IList<T> array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class QuickSort :ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            Quick_Sort(color, 0, color.Length - 1);
        }

        private void Quick_Sort(Color[] color, int left, int right)
        {
            while (true)
            {
                if (left < right)
                {
                    int pivot = Partition(color, left, right);

                    if (pivot > 1)
                    {
                        Quick_Sort(color, left, pivot - 1);
                    }

                    if (pivot + 1 < right)
                    {
                        left = pivot + 1;
                        continue;
                    }
                }

                break;
            }
        }

        private int Partition(Color[] color, int left, int right)
        {
            double pivot = color[left].GetHue();
            while (true)
            {
                while (color[left].GetHue() < pivot)
                {
                    left++;
                }

                while (color[right].GetHue() > pivot)
                {
                    right--;
                }
                    
                if (left < right)
                {
                    Swap(color, left, right);

                    if (Math.Abs(color[left].GetHue() - color[right].GetHue()) < 0.00001)
                    {
                        left++;
                    }

                    ReportProgress();
                    Thread.Sleep(2);
                }
                else
                {
                    return right;
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

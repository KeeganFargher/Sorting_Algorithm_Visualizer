using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingLibrary.Algorithms
{
    public class HeapSort : ISorting
    {
        public event EventDelegate ReportProgress;

        public void Sort(ref Color[] color)
        {
            int heapSize = color.Length;

            BuildMaxHeap(color);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                Swap(color, i, 0);
                heapSize--;
                Sink(color, heapSize, 0);
            }
        }

        private void BuildMaxHeap(Color[] color)
        {
            int heapSize = color.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                Sink(color, heapSize, i);
            }
        }

        private void Sink(Color[] color, int heapSize, int toSinkPosition)
        {
            if (GetLeftChildPosition(toSinkPosition) >= heapSize)
            {
                //  If there's no left child then there's no child at all
                return;
            }

            int largestChildPosition;
            bool leftIsLargest;

            int rightIndex = GetRightChildPosition(toSinkPosition);
            int leftIndex = GetLeftChildPosition(toSinkPosition);

            if (GetRightChildPosition(toSinkPosition) >= heapSize ||
                color[rightIndex].GetHue() < color[leftIndex].GetHue())
            {
                largestChildPosition = GetLeftChildPosition(toSinkPosition);
                leftIsLargest = true;
            }
            else
            {
                largestChildPosition = GetRightChildPosition(toSinkPosition);
                leftIsLargest = false;
            }

            if (color[largestChildPosition].GetHue() > color[toSinkPosition].GetHue())
            {
                Swap(color, toSinkPosition, largestChildPosition);

                Sink(color, heapSize,
                    leftIsLargest ? GetLeftChildPosition(toSinkPosition) : GetRightChildPosition(toSinkPosition));
            }

            ReportProgress();
            Thread.Sleep(1);
        }

        private static void Swap<T>(IList<T> array, int left, int right)
        {
            T temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

        private static int GetLeftChildPosition(int parentPosition)
        {
            return (2 * (parentPosition + 1)) - 1;
        }

        private static int GetRightChildPosition(int parentPosition)
        {
            return 2 * (parentPosition + 1);
        }
    }
}

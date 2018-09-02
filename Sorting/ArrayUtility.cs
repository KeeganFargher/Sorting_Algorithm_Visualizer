using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class ArrayUtility
    {
        public static void PopulateArray(ref Color[] color, int Width)
        {
            color = new Color[Width];

            Random random = new Random();
            for (int j = 0; j < color.Length; j++)
            {
                color[j] = GetRandomColor(random);
            }
        }

        private static Color GetRandomColor(Random random)
        {
            int[] rgb = new int[3];
            rgb[0] = random.Next(256);
            rgb[1] = random.Next(256);
            rgb[2] = random.Next(256);

            //  Find max and min indexes
            int min, max;

            if (rgb[0] > rgb[1])
            {
                max = (rgb[0] > rgb[2]) ? 0 : 2;
                min = (rgb[1] < rgb[2]) ? 1 : 2;
            }
            else
            {
                max = (rgb[1] > rgb[2]) ? 1 : 2;
                int notmax = 1 + max % 2;
                min = (rgb[0] < rgb[notmax]) ? 0 : notmax;
            }
            rgb[max] = 255;
            rgb[min] = 0;

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

    }
}

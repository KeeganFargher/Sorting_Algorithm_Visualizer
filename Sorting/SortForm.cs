using SortingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class SortForm : Form
    {
        private Color[] color;

        public SortForm()
        {
            InitializeComponent();

            ArrayUtility.PopulateArray(ref color, Width, panelSidebar.Width);
            labelArraySize.Text = color.Length.ToString();
            Invalidate();

            comboBoxSortMethod.DataSource = Enum.GetValues(typeof(SortEnums));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (color == null) return;

            for (int j = 0; j < color.Length; j++)
            {
                //  Set the height of the line to the hue of the color
                int colorHue = (int)Math.Round(color[j].GetHue());

                Brush brushColor = new SolidBrush(color[j]);
                Pen pen = new Pen(brushColor, 1);
                Point p1 = new Point(j, Height - 1);
                Point p2 = new Point(j, colorHue);
                e.Graphics.DrawLine(pen, p1, p2);
            }
        }

        private void SortHandler()
        {
            Invalidate();
        }

        private void SortForm_Resize(object sender, EventArgs e)
        {
            ArrayUtility.PopulateArray(ref color, Width, panelSidebar.Width);
            labelArraySize.Text = color.Length.ToString();
            Invalidate();
        }

        private void ButtonRandomize_Click(object sender, EventArgs e)
        {
            ArrayUtility.PopulateArray(ref color, Width, panelSidebar.Width);
            Invalidate();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            Enum.TryParse(comboBoxSortMethod.SelectedValue.ToString(), out SortEnums sort);
            switch (sort)
            {
                case SortEnums.SelectionSort:
                    StartSort(new SelectionSort());
                    break;
                case SortEnums.BubbleSort:
                    StartSort(new BubbleSort());
                    break;
                case SortEnums.CocktailSort:
                    StartSort(new CocktailSort());
                    break;
                case SortEnums.GnomeSort:
                    StartSort(new GnomeSort());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartSort(ISorting test)
        {
            test.ReportProgress += SortHandler;
            Task.Run(() => test.Sort(ref color))
                .ContinueWith(t => buttonStart.Enabled = true);
        }

    }
}

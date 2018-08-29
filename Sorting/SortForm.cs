﻿using SortingLibrary;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class SortForm : Form
    {
        private Color[] _color;

        public SortForm()
        {
            InitializeComponent();

            ArrayUtility.PopulateArray(ref _color, Width, panelSidebar.Width);
            labelArraySize.Text = _color.Length.ToString();
            Invalidate();

            comboBoxSortMethod.DataSource = Enum.GetValues(typeof(SortEnums));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (_color == null) return;

            for (int j = 0; j < _color.Length; j++)
            {
                Brush brushColor = new SolidBrush(_color[j]);
                Pen pen = new Pen(brushColor, 1);

                //  Set the height of the line to the hue of the color
                int colorHue = (int) Math.Round(_color[j].GetHue());

                //  Visualizes the array using the hue as the height of each element
                //  in the array
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
            ArrayUtility.PopulateArray(ref _color, Width, panelSidebar.Width);
            labelArraySize.Text = _color.Length.ToString();
            Invalidate();
        }

        private void ButtonRandomize_Click(object sender, EventArgs e)
        {
            ArrayUtility.PopulateArray(ref _color, Width, panelSidebar.Width);
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
                case SortEnums.QuickSort:
                    StartSort(new QuickSort());
                    break;
                case SortEnums.CombSort:
                    StartSort(new CombSort());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartSort(ISorting test)
        {
            test.ReportProgress += SortHandler;
            Task.Run(() => test.Sort(ref _color))
                .ContinueWith(t => buttonStart
                    .Invoke(new Action(() => buttonStart.Enabled = true)));
        }
    }
}

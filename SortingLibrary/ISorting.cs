using System.Drawing;

namespace SortingLibrary
{
    public delegate void EventDelegate();

    public interface ISorting
    {
        /// <summary>
        /// The sort method that needs to be implented
        /// </summary>
        /// <param name="color">The array of colors</param>
        void Sort(ref Color[] color);
        
        /// <summary>
        /// This event can be called whenever you need to update the form.
        /// The sorting algorithms have many nested for loops, so put this in
        /// when you want to update the display.
        /// </summary>
        event EventDelegate ReportProgress;
    }
}

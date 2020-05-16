using System.Drawing;
using System.Windows.Forms;

namespace SUT.Helpers
{
    public static class FormPositioning
    {
        public static void ScreenCenterAtTheBottom(Form form)
        {
            Rectangle primaryScreenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            form.Location = new Point((primaryScreenWorkingArea.Right / 2) - (form.Size.Width / 2),
                                      primaryScreenWorkingArea.Bottom - form.Size.Height);
        }

        public static void ScreenRightAtTheBottom(Form form)
        {
            Rectangle primaryScreenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            form.Location = new Point(primaryScreenWorkingArea.Right - form.Size.Width,
                                      primaryScreenWorkingArea.Bottom - (form.Size.Height - 10));
        }
    }
}

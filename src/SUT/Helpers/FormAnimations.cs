using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SUT.Helpers
{
    public static class FormAnimations
    {
        public const int AW_ACTIVATE = 0x20000;
        public const int AW_HIDE = 0x10000;
        public const int AW_BLEND = 0x80000;
        public const int AW_CENTER = 0x00000010;
        public const int AW_SLIDE = 0X40000;
        public const int AW_VER_POSITIVE = 0x00000004;
        public const int AW_VER_NEGATIVE = 0x00000008;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlags);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public static void SlideUpTopMostWithoutStealingFocus(Form form)
        {
            AnimateWindow(form.Handle, 300,
                AW_SLIDE
                | AW_VER_NEGATIVE);

            IntPtr HWND_TOPMOST = new IntPtr(-1);
            uint SWP_NOACTIVATE = 0x0010;
            SetWindowPos(form.Handle, HWND_TOPMOST, form.Location.X, form.Location.Y, form.Width, form.Height, SWP_NOACTIVATE);
        }

        public static void SlideDown(Form form)
        {
            AnimateWindow(form.Handle, 200,
            AW_SLIDE
            | AW_VER_POSITIVE
            | AW_HIDE);
        }
    }
}

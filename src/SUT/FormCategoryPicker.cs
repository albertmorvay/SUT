using SUT.Helpers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SUT
{
    public partial class FormCategoryPicker : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            FormPositioning.ScreenCenterAtTheBottom(this);
            FormAnimations.SlideUpTopMostWithoutStealingFocus(this);
            base.OnLoad(e);
        }

        public FormCategoryPicker()
        {
            InitializeComponent();
        }
    }
}

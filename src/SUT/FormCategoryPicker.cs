using System;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;
using LiteDB;
using Serilog;
using SUT.Helpers;

namespace SUT
{
    public partial class FormCategoryPicker : Form
    {
        private FormMain formMain = null;
        private static System.Timers.Timer aTimer;

        public FormCategoryPicker()
        {
            InitializeComponent();
        }

        public FormCategoryPicker(Form callingForm)
        {
            formMain = callingForm as FormMain;
            formMain.WindowState = FormWindowState.Minimized;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            FormPositioning.ScreenCenterAtTheBottom(this);
            FormAnimations.SlideUpTopMostWithoutStealingFocus(this);
            base.OnLoad(e);
            SetTimer();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FormAnimations.SlideDown(this);
            base.OnFormClosing(e);
        }

        private void ButtonWorkCategory01_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("ADMIN");
        }

        private void ButtonWorkCategory02_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("SUPPORT");
        }

        private void buttonWorkCategory03_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("TESTING");
        }

        private void buttonWorkCategory04_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("DOCS");
        }

        private void buttonWorkCategory05_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("PROJECT");
        }

        private void buttonWorkCategory06_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("MEETING");
        }

        private void buttonWorkCategory07_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("ITOM");
        }

        private void buttonWorkCategory08_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("GRC");
        }

        private void buttonWorkCategory09_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("FIREFIGHTING");
        }

        private void SetWorkCategoryToBeTrackedAgainst(string categoryName)
        {
            formMain.SetCurrentWorkCategory(GetTodaysWorkCategory(categoryName));
            formMain.SetLabelCurrentWorkCategory(categoryName);
            this.Close();
        }

        private WorkCategory GetTodaysWorkCategory(string categoryName)
        {
            WorkCategory result = null;
            try
            {

#if DEBUG
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(@"C:\temp\sut-test.db"))
#else
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase (string.Format (@"{0}\sut.db", Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments))))
#endif
                {
                    // Get a collection (or create, if doesn't exist)
                    var databaseCollection = db.GetCollection<WorkCategory>("WorkCategories");
                    // Use Linq to query documents
                    var persistedWorkCategory = databaseCollection.FindOne(x => x.Id == GetCleanedStringForId(DateTime.Now, categoryName));
                    if (persistedWorkCategory != null)
                    {
                        result = persistedWorkCategory;
                    }
                    else
                    {
                        // Create your new customer instance
                        result = new WorkCategory(categoryName);
                        databaseCollection.Insert(result);
                    }
                }
                
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Timed event failed.");
                Application.Exit ();
#endif
            }
            return result;
        }

        private string GetCleanedStringForId(DateTime dateTime, string name)
        {
            return string.Format("{0}-{1}", dateTime.ToString("yyyyMMdd"), name.ToUpper().Replace(" ", "-"));
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(7000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CloseCategoryPicker(this);
        }

        delegate void CloseCategoryPickerCallback(FormCategoryPicker callingForm);

        private void CloseCategoryPicker(FormCategoryPicker callingForm)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CloseCategoryPickerCallback d = new CloseCategoryPickerCallback(CloseCategoryPicker);
                    this.Invoke(d, new object[] { callingForm });
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Setting total service unit count failed.");
                Application.Exit();
#endif
            }
        }
    }
}
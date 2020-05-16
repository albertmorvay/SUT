using System;
using System.Windows.Forms;
using LiteDB;
using SUT.Helpers;

namespace SUT
{
    public partial class FormCategoryPicker : Form
    {
        private FormMain formMain = null;

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
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FormAnimations.SlideDown(this);
            base.OnFormClosing(e);
        }

        private void ButtonWorkCategory01_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("Admin");
        }

        private void ButtonWorkCategory02_Click(object sender, EventArgs e)
        {
            SetWorkCategoryToBeTrackedAgainst("Firefighting");
        }

        private void SetWorkCategoryToBeTrackedAgainst(string categoryName)
        {
            formMain.SetCurrentWorkCategory(GetTodaysWorkCategory(categoryName));
            this.Close();
        }

        private WorkCategory GetTodaysWorkCategory(string categoryName)
        {
            try
            {
                WorkCategory result = null;

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
                return result;
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
    }
}
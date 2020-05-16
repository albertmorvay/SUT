using LiteDB;
using Serilog;
using SUT.Helpers;
using System;
using System.Timers;
using System.Windows.Forms;

namespace SUT
{
    public partial class FormMain : Form
    {
        private System.Timers.Timer timer;
        private WorkingDay currentWorkingDay = null;
        private WorkCategory currentWorkCategory = new WorkCategory("Admin");

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                FormPositioning.ScreenCenterAtTheBottom(this);
                var formCategoryPicker = new FormCategoryPicker(this);
                formCategoryPicker.Show();
                labelSoftwareVersion.Text = string.Format("{0}-alpha", Application.ProductVersion);
                SetTimer();
                Log.Debug("Timer configured.");
                timer.Start();
                Log.Debug("Timer started.");
                numericUpDownWeeklyReportWeekNumber.Value = ReportingExcel.GetIso8601WeekOfYear(DateTime.Now);
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Form load failed.");
                Application.Exit();
#endif
            }
        }

        private void SetTimer()
        {
            
#if DEBUG
            timer = new System.Timers.Timer(2000);
#else
            // Create a timer with a sixty second interval.
            timer = new System.Timers.Timer(60000);
#endif
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();

#if DEBUG
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(@"C:\temp\sut-test.db"))
#else
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(string.Format(@"{0}\sut.db", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))))
#endif
                {
                    // Get a collection (or create, if doesn't exist)
                    var databaseCollectionWorkingDay = db.GetCollection<WorkingDay>("WorkingDays");
                    // Use Linq to query documents
                    var persistedWorkingDay = databaseCollectionWorkingDay.FindOne(x => x.Id == DateTime.Now.ToString("yyyyMMdd"));
                    if (persistedWorkingDay != null)
                    {
                        currentWorkingDay = persistedWorkingDay;
                        var bar = currentWorkingDay.TotalTime();
                        currentWorkingDay.AddServiceUnit();
                        SetLabelTotalServiceUnitCountText(currentWorkingDay.TotalServiceUnits().ToString("D2"));
                        
                        // Update a document inside a collection
                        databaseCollectionWorkingDay.Update(currentWorkingDay);
                    }
                    else
                    {
                        // Create your new customer instance
                        currentWorkingDay = new WorkingDay();
                        SetLabelTotalServiceUnitCountText(currentWorkingDay.TotalServiceUnits().ToString("D2"));
                        databaseCollectionWorkingDay.Insert(currentWorkingDay);
                    }

                    databaseCollectionWorkingDay.Update(currentWorkingDay);

                    // Get a collection (or create, if doesn't exist)
                    var databaseCollectionWorkCategory = db.GetCollection<WorkCategory>("WorkCategories");
                    
                    var persistedWorkCategory = databaseCollectionWorkCategory.FindOne(x => x.Id == currentWorkCategory.Id);   
                    if (persistedWorkCategory != null)
                    {
                        currentWorkCategory = persistedWorkCategory;
                    }
                    else
                    {
                        // Create your new customer instance
                        currentWorkCategory = new WorkCategory("ADMIN");
                        databaseCollectionWorkCategory.Insert(currentWorkCategory);
                    }
                    currentWorkCategory.AddServiceUnit();
                    databaseCollectionWorkCategory.Update(currentWorkCategory);
                }
                timer.Start();
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Timed event failed.");
                Application.Exit();
#endif
            }
        }

        delegate void SetLabelTotalServiceUnitCountTextCallback(string text);

        private void SetLabelTotalServiceUnitCountText(string text)
        {
            try
            {
                if (this.labelTotalServiceUnitCount.InvokeRequired)
                {
                    SetLabelTotalServiceUnitCountTextCallback d = new SetLabelTotalServiceUnitCountTextCallback(SetLabelTotalServiceUnitCountText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.labelTotalServiceUnitCount.Text = text;
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

        private void FormMain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            try
            {
                timer.Dispose();
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Disposing of timer failed.");
                Application.Exit();
#endif
            }
        }

        private void buttonGenerateWeeklyReport_Click(object sender, EventArgs e)
        {
            ReportingExcel.CreateWeeklyReport(Convert.ToInt32(numericUpDownWeeklyReportYear.Value), Convert.ToInt32(numericUpDownWeeklyReportWeekNumber.Value));
        }

        public void SetCurrentWorkCategory(WorkCategory workCategory)
        {
            currentWorkCategory = workCategory;
        }
    }
}

using LiteDB;
using Microsoft.Win32;
using Serilog;
using System;
using System.Timers;
using System.Windows.Forms;

namespace SUT
{
    public partial class FormMain : Form
    {
        private String stringApplicationName = "SUTServiceUnitTracker";
        private System.Timers.Timer timer;
        private WorkingDay workingDay = null;
        RegistryKey registryKeyRunOnStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                labelSoftwareVersion.Text = string.Format("{0}-alpha", Application.ProductVersion);
                SetTimer();
                Log.Debug("Timer configured.");
                timer.Start();
                Log.Debug("Timer started.");
                numericUpDownWeeklyReportWeekNumber.Value = ReportingExcel.GetIso8601WeekOfYear(DateTime.Now);
                // Check to see the current state (running at startup or not)
                if (registryKeyRunOnStartup.GetValue(stringApplicationName) == null)
                {
                    // The value doesn't exist, the application is not set to run at startup
                    checkBoxRunOnStartup.Checked = false;
                }
                else
                {
                    // The value exists, the application is set to run at startup
                    checkBoxRunOnStartup.Checked = true;
                }
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
                    var databaseCollection = db.GetCollection<WorkingDay>("WorkingDays");
                    // Use Linq to query documents
                    var persistedWorkingDay = databaseCollection.FindOne(x => x.Id == DateTime.Now.ToString("yyyyMMdd"));
                    if (persistedWorkingDay != null)
                    {
                        workingDay = persistedWorkingDay;
                        var bar = workingDay.TotalTime();
                        workingDay.AddServiceUnit();
                        SetLabelTotalServiceUnitCountText(workingDay.TotalServiceUnits().ToString("D2"));
                        
                        // Update a document inside a collection
                        databaseCollection.Update(workingDay);
                    }
                    else
                    {
                        // Create your new customer instance
                        workingDay = new WorkingDay();
                        SetLabelTotalServiceUnitCountText(workingDay.TotalServiceUnits().ToString("D2"));
                        databaseCollection.Insert(workingDay);
                    }

                    databaseCollection.Update(workingDay);
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

        private void checkBoxRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegisterOnStartup(checkBoxRunOnStartup.Checked);
        }

        private void RegisterOnStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue(stringApplicationName, Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue(stringApplicationName, false);
            }
        }
    }
}

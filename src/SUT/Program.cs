using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Sentry;
using Serilog;
using Serilog.Events;

namespace SUT
{
    static class Program
    {
        [DllImport("user32.dll")]
        [
            return: MarshalAs(UnmanagedType.Bool)
        ]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Sentry(o => {
                    o.MinimumBreadcrumbLevel = LogEventLevel.Debug; // Debug and higher are stored as breadcrumbs (default os Information)
                    o.MinimumEventLevel = LogEventLevel.Error; // Error and higher is sent as event (default is Error)
                    o.Dsn = new Dsn("https://REPLACE@sentry.io/REPLACE");
                    o.AttachStacktrace = true;
                    o.SendDefaultPii = false; // send PII like the username of the user logged in to the device
                    // Other configuration
                })
                .CreateLogger();

            try
            {
                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "SUT-9193643f-77c3-4ac5-b95a-f28f02f471f9", out createdNew))
                {
                    if (createdNew)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new FormMain());
                    }
                    else
                    {
                        Process current = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Multi-Instance check failed.");
                Application.Exit();
#endif
            }
        }
    }
}
using System.Diagnostics;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace ApplicationTrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Thread tracker = new Thread(StartDataTracking);
            tracker.IsBackground = true;
            tracker.Start();
            Application.Run(new StatisticForm());
        }

        public static void StartDataTracking()
        {
            while (true)
            {
                IntPtr foregroundWindowHandle = ApplicationTracker.GetForegroundWindow();
                // get current foreground process
                Process foregroundProcess = Process.GetProcessById(ApplicationTracker.GetProcessId(foregroundWindowHandle));
                string foregroundWindowName = foregroundProcess.ProcessName;
                Console.WriteLine(foregroundWindowName);

                // Get application data
                List<ApplicationDataModel> ln = GlobalConfig.SqliteConnection.GetApplicationData_ByName(ApplicationTracker.GetWindowTitle(foregroundWindowHandle));
                if (ln.Any())
                {
                    Console.WriteLine(ln.First().TimeSpent);
                    ln.First().TimeSpent++;
                    ln.First().LastUsed = DateTime.Now.ToString();
                    GlobalConfig.SqliteConnection.UpdateApplicationData_Time(ln.First());
                    GlobalConfig.SqliteConnection.UpdateApplicationData_LastUsed(ln.First());
                }
                else
                {
                    ApplicationDataModel m = new ApplicationDataModel();
                    m.ApplicationType = foregroundWindowName;
                    m.ApplicationName = ApplicationTracker.GetWindowTitle(foregroundWindowHandle);
                    m.TimeSpent = 0;
                    GlobalConfig.SqliteConnection.CreateApplicationData(m);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
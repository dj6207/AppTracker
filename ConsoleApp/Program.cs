using System.Diagnostics;
using TrackerLibrary;
using TrackerLibrary.Models;

internal static class Program
{
    static void Main()
    {
        Boolean Debug = false;
        if (Debug)
        {
            Console.WriteLine("In Debug Mode");
            Console.WriteLine("(D)elte DataBase");
            Console.WriteLine("(P)rint DataBase");
            Console.WriteLine("(A)dd test Data");
            Console.WriteLine("(G)enerate Statisitcs");
            Console.WriteLine("Type in command: ");
            String cmd = Console.ReadLine();
            if (cmd.ToLower() == "d")
            {
                GlobalConfig.Connection.ClearApplicationDataBase();
            }
            else if (cmd == "p")
            {
                List<ApplicationDataModel> l = GlobalConfig.Connection.GetApplicationData_All();
                foreach (ApplicationDataModel model in l)
                {
                    Console.WriteLine(model.ApplicationName);
                }
            } 
            else if (cmd == "a")
            {   
                ApplicationDataModel a = new ApplicationDataModel();
                a.ApplicationName = "TestName";
                a.ApplicationType = "TestType";
                a.TimeSpent = 0;
                GlobalConfig.Connection.CreateApplicationData(a);
            }
            else if (cmd == "g")
            {
                GenerateStatistics.GenerateAllStatistics();
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }

        }
        else
        {
            while (true)
            {
                IntPtr foregroundWindowHandle = ApplicationTracker.GetForegroundWindow();
                // get curretn foreground process
                Process foregroundProcess = Process.GetProcessById(ApplicationTracker.GetProcessId(foregroundWindowHandle));
                string foregroundWindowName = foregroundProcess.ProcessName;
                Console.WriteLine(foregroundWindowName);


                // Get application data
                List<ApplicationDataModel> l = GlobalConfig.Connection.GetApplicationData_ByName(foregroundWindowName);
                // If applicaiton exist increment time by 1 sec else make new application data
                if (l.Any())
                {
                    Console.WriteLine(l.First().TimeSpent);
                    l.First().TimeSpent++;
                    GlobalConfig.Connection.UpdateApplicationData_Time(l.First());
                }
                else
                {
                    ApplicationDataModel m = new ApplicationDataModel();
                    m.ApplicationName = foregroundWindowName;
                    // need testing
                    m.ApplicationType = ApplicationTracker.GetWindowTitle(foregroundWindowHandle);
                    //m.ApplicationType = "Productivity";
                    m.TimeSpent = 0;
                    GlobalConfig.Connection.CreateApplicationData(m);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
using System.Diagnostics;
using TrackerLibrary;
using TrackerLibrary.Models;

internal static class Program
{
    static void Main()
    {

        Boolean Debug = true;
        if (Debug)
        {
            Console.WriteLine("In Debug Mode");
            Console.WriteLine("(D)elte DataBase");
            Console.WriteLine("(P)rint DataBase");
            Console.WriteLine("(A)dd test Data");
            Console.WriteLine("(G)enerate Statisitcs");
            Console.WriteLine("Search by (T)ype");
            Console.WriteLine("Search by (N)ame");
            Console.WriteLine("Type in command: ");
            switch (Console.ReadLine().ToLower())
            {
                case "d":
                    GlobalConfig.SqliteConnection.ClearApplicationDataBase();
                    break;
                case "p":
                    List<ApplicationDataModel> l = GlobalConfig.SqliteConnection.GetApplicationData_All();
                    foreach (ApplicationDataModel model in l)
                    {
                        Console.WriteLine(model.ApplicationName);
                    }
                    break;
                case "a":
                    ApplicationDataModel a = new ApplicationDataModel();
                    a.ApplicationName = "TestName";
                    a.ApplicationType = "TestType";
                    a.TimeSpent = 0;
                    a.LastUsed = DateTime.Now.ToString();
                    GlobalConfig.SqliteConnection.CreateApplicationData(a);
                    break;
                case "g":
                    GenerateStatistics.GenerateAllStatistics();
                    //GenerateStatistics.GenerateStatisticByType();
                    break;
                case "t":
                    Console.WriteLine("Type:");
                    List<ApplicationDataModel> t = GlobalConfig.SqliteConnection.GetApplicationData_ByType(Console.ReadLine());
                    foreach (ApplicationDataModel model in t)
                    {
                        Console.WriteLine();
                        Console.WriteLine(model.ApplicationName);
                        Console.WriteLine(model.ApplicationType);
                        Console.WriteLine(model.TimeSpent);
                    }
                    break;
                case "n":
                    Console.WriteLine("Name:");
                    List<ApplicationDataModel> n = GlobalConfig.SqliteConnection.GetApplicationData_ByName(Console.ReadLine());
                    foreach (ApplicationDataModel model in n)
                    {
                        Console.WriteLine();
                        Console.WriteLine(model.ApplicationName);
                        Console.WriteLine(model.ApplicationType);
                        Console.WriteLine(model.TimeSpent);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
        else
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
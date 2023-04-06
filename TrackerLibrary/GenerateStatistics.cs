using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class GenerateStatistics
    {
        // TODO: Add more statistics when last used date is added and make printing prettier
        // NOTE: Maybe shorten the name of the application name
        public static void GenerateAllStatistics()
        {
            List<ApplicationDataModel> allApplication = GlobalConfig.SqliteConnection.GetApplicationData_All();
            int totalTime = 0;
            foreach (ApplicationDataModel application in allApplication)
            {
                Console.WriteLine($"Application: {application.ApplicationName} ApplicationTitle: {application.ApplicationType} Total Time: {application.TimeSpent / 60} min");
                totalTime = totalTime + application.TimeSpent;
            }
            Console.WriteLine($"Total Time Spent: {totalTime / 60} min");

        }

        public static void GenerateStatisticByType()
        {
            Dictionary<string, int> typeTimeDictionary = new Dictionary<string, int>();
            List<ApplicationDataModel> allApplication = GlobalConfig.SqliteConnection.GetApplicationData_All();
            int totalTime = 0;
            foreach (ApplicationDataModel application in allApplication)
            {
                if (typeTimeDictionary.ContainsKey(application.ApplicationType))
                {
                    typeTimeDictionary[application.ApplicationType] = typeTimeDictionary[application.ApplicationType] + application.TimeSpent;
                }
                else
                {
                    typeTimeDictionary.Add(application.ApplicationType, application.TimeSpent);
                }
            }
            foreach (string s in typeTimeDictionary.Keys)
            {
                Console.WriteLine($"Type:{s} Time:{typeTimeDictionary[s] / 60}");
                totalTime = totalTime + typeTimeDictionary[s];
            }
            Console.WriteLine($"Total Time Spent: {totalTime / 60} min");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class GenerateStatistics
    {
        public static void GenerateAllStatistics()
        {
            List<ApplicationDataModel> allApplication = new List<ApplicationDataModel>();
            int totalTime = 0;
            allApplication = GlobalConfig.Connection.GetApplicationData_All();
            foreach (ApplicationDataModel application in allApplication)
            {
                Console.WriteLine($"Application: {application.ApplicationName} ApplicationTitle: {application.ApplicationType} Total Time: {application.TimeSpent/60} min");
                totalTime = totalTime + application.TimeSpent;
            }
            Console.WriteLine($"Total Time Spent: {totalTime/60} min");

        }
    }
}

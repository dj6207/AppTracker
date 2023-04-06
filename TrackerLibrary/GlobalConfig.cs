using System.Configuration;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        //public static IDataConnection Connection { get; private set; } = new SqlConnector();
        public static IDataConnection SqliteConnection { get; private set; } = new SqliteConnector();
        public static String CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

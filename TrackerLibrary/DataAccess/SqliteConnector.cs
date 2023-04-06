using Dapper;
using System.Data;
using System.Data.SQLite;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqliteConnector : IDataConnection
    {
        private const string db = "SqliteApplications";

        public void CreateApplicationData(ApplicationDataModel model)
        {
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                var a = new DynamicParameters();
                a.Add("@ApplicationName", model.ApplicationName);
                a.Add("@ApplicationType", model.ApplicationType);
                a.Add("@TimeSpent", model.TimeSpent);
                a.Add("@LastUsed", model.LastUsed);
                sqliteConnection.Execute("insert into ApplicationData (ApplicationName, ApplicationType, TimeSpent, LastUsed) values (@ApplicationName, @ApplicationType, @TimeSpent, @LastUsed)", a);
            }
        }

        public List<ApplicationDataModel> GetApplicationData_All()
        {
            List<ApplicationDataModel> output;
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                output = sqliteConnection.Query<ApplicationDataModel>("select * from ApplicationData").ToList();
            }
            return output;
        }

        public List<ApplicationDataModel> GetApplicationData_ByName(string name)
        {
            List<ApplicationDataModel> output;
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@ApplicationName", name);
                output = sqliteConnection.Query<ApplicationDataModel>("select * from ApplicationData where ApplicationName = @ApplicationName", m).ToList();
            }
            return output;
        }

        public void UpdateApplicationData_Time(ApplicationDataModel model)
        {
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@id", model.Id);
                m.Add("@TimeSpent", model.TimeSpent);
                sqliteConnection.Execute("update ApplicationData set TimeSpent = @TimeSpent where id = @id", m);
            }
        }
        public void ClearApplicationDataBase()
        {
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                sqliteConnection.Execute("delete from ApplicationData");
                sqliteConnection.Execute("delete from sqlite_sequence where name = 'ApplicationData'");
            }
        }

        public List<ApplicationDataModel> GetApplicationData_ByType(string type)
        {
            List<ApplicationDataModel> output;
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@ApplicationType", type);
                output = sqliteConnection.Query<ApplicationDataModel>("select * from ApplicationData where ApplicationType = @ApplicationType", m).ToList();
            }
            return output;
        }

        public void UpdateApplicationData_LastUsed(ApplicationDataModel model)
        {
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@id", model.Id);
                m.Add("@LastUsed", model.LastUsed);
                sqliteConnection.Execute("update ApplicationData set LastUsed = @LastUsed where id = @id", m);
            }
        }

        public List<ApplicationDataModel> GetApplicationData_ByTimeSpent()
        {
            List<ApplicationDataModel> output;
            using (IDbConnection sqliteConnection = new SQLiteConnection(GlobalConfig.CnnString(db)))
            {
                output = sqliteConnection.Query<ApplicationDataModel>("select * from ApplicationData order by TimeSpent desc").ToList();
            }
            return output;
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Applications";

        public ApplicationDataModel CreateApplicationData(ApplicationDataModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var a = new DynamicParameters();
                a.Add("@ApplicationName", model.ApplicationName);
                a.Add("@ApplicationType", model.ApplicationType);
                a.Add("@TimeSpent", model.TimeSpent);
                a.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spApplicationData_Insert", a, commandType: CommandType.StoredProcedure);
                model.Id = a.Get<int>("@id");
                return model;
            }
        }

        public List<ApplicationDataModel> GetApplicationData_All()
        {
            List<ApplicationDataModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<ApplicationDataModel>("spApplication_GetAll").ToList();
            }
            return output;
        }

        public List<ApplicationDataModel> GetApplicationData_ByName(string name)
        {
            List<ApplicationDataModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@ApplicationName", name);
                output = connection.Query<ApplicationDataModel>("spApplication_GetByApplicationName", m, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        public void UpdateApplicationData_Time(ApplicationDataModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var m = new DynamicParameters();
                m.Add("@id", model.Id);
                m.Add("@TimeSpent", model.TimeSpent);
                connection.Execute("dbo.spApplicationData_Update", m, commandType: CommandType.StoredProcedure);
            }
        }
        public void ClearApplicationDataBase()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                // Need to be tested 
                connection.Execute("spApplication_Delete");
            }
        }
    }
}

using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        void CreateApplicationData(ApplicationDataModel model);
        List<ApplicationDataModel> GetApplicationData_All();
        List<ApplicationDataModel> GetApplicationData_ByName(string name);
        List<ApplicationDataModel> GetApplicationData_ByType(string type);
        void UpdateApplicationData_Time(ApplicationDataModel model);
        void ClearApplicationDataBase();
        void UpdateApplicationData_LastUsed(ApplicationDataModel model);
        List<ApplicationDataModel> GetApplicationData_ByTimeSpent();
    }
}

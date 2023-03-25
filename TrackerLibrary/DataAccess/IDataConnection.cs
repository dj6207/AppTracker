using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        ApplicationDataModel CreateApplicationData(ApplicationDataModel model);
        List<ApplicationDataModel> GetApplicationData_All();
        List<ApplicationDataModel> GetApplicationData_ByName(string name);
        void UpdateApplicationData_Time(ApplicationDataModel model);
        void ClearApplicationDataBase();
    }
}

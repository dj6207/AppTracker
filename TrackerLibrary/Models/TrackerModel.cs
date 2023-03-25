using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TrackerModel
    {
        /// <summary>
        /// List of Current Applicaitons being tracked
        /// </summary>
        public List<ApplicationDataModel> Applications { get; set; } = new List<ApplicationDataModel>();
        /// <summary>
        /// Total time spend in all applications
        /// </summary>
        public int TotalTimeSpent { get; set; }
    }
}

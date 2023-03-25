using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class ApplicationDataModel
    {
        /// <summary>
        /// Unique Id of Application
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the Application
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// The Type of the Application
        /// Ex. Entertainment, Productivity, Game, etx
        /// </summary>
        public string ApplicationType { get; set; }
        /// <summary>
        /// Current Time Spent on Application
        /// </summary>
        public int TimeSpent { get; set; }
    }
}

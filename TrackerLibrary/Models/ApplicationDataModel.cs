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
        /// <summary>
        /// Last Used Date
        /// </summary>
        public string LastUsed { get; set; }
    }
}

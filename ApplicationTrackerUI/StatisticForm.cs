using TrackerLibrary;
using TrackerLibrary.Models;

namespace ApplicationTrackerUI
{
    public partial class StatisticForm : Form
    {
        readonly static int PieSize = 20;
        readonly ScottPlot.Plottable.PiePlot Plot;
        readonly double[] values = new double[PieSize];
        readonly string[] labels = new string[PieSize];
        public StatisticForm()
        {
            InitializeComponent();
            UpdateData();
            Plot = PieChart.Plot.AddPie(values);
            Plot.SliceLabels = labels;
            //Plot.ShowLabels = true;
            Plot.ShowValues = true;
            PieChart.Plot.Legend();
            //PiePlot.ShowPercentages = true;
        }

        private List<ApplicationDataModel> GetApplicationData(string type)
        {
            List<ApplicationDataModel> output;
            output = GlobalConfig.SqliteConnection.GetApplicationData_ByTimeSpent();
            return output;
        }

        private void ClearDataBase_Click(object sender, EventArgs e)
        {
            GlobalConfig.SqliteConnection.ClearApplicationDataBase();
            for (int i = 0; i < PieSize; i++)
            {
                values[i] = 0;
                labels[i] = string.Empty;
            }
        }

        public void UpdateData()
        {
            List<ApplicationDataModel> data = GetApplicationData("");
            int l = PieSize;
            if (l > data.Count)
            {
                l = data.Count;
            }

            for (int i = 0; i < l; i++)
            {
                values[i] = data.Select(c => (double)c.TimeSpent).ToArray()[i];
                labels[i] = data.Select(c => c.ApplicationName).ToArray()[i];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
            PieChart.Render();
        }
    }
}
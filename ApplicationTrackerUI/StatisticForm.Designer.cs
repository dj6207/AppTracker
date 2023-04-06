namespace ApplicationTrackerUI
{
    partial class StatisticForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PieChart = new ScottPlot.FormsPlot();
            ClearDataBase = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // PieChart
            // 
            PieChart.Location = new Point(13, 12);
            PieChart.Margin = new Padding(4, 3, 4, 3);
            PieChart.Name = "PieChart";
            PieChart.Size = new Size(747, 546);
            PieChart.TabIndex = 0;
            // 
            // ClearDataBase
            // 
            ClearDataBase.Location = new Point(767, 12);
            ClearDataBase.Name = "ClearDataBase";
            ClearDataBase.Size = new Size(75, 23);
            ClearDataBase.TabIndex = 1;
            ClearDataBase.Text = "ClearDB";
            ClearDataBase.UseVisualStyleBackColor = true;
            ClearDataBase.Click += ClearDataBase_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // StatisticForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 570);
            Controls.Add(ClearDataBase);
            Controls.Add(PieChart);
            Name = "StatisticForm";
            Text = "Statistics";
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot PieChart;
        private Button ClearDataBase;
        private System.Windows.Forms.Timer timer1;
    }
}
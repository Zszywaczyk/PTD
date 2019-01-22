using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTD_Lab3
{
	public partial class Program : Form
	{

		public static int iii;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

		static void Main(string[] args)
		{

			double Tb = 2; //nadać recznie pod wzgledem poprzedniego zadania

			PTD ptd = new PTD(Tb);
			Application.Run(new Program(ptd.get_t,ptd.get_zA, "1.ASK zA"));
			Application.Run(new Program(ptd.get_t, ptd.get_xt_ask, "2.ASK xt"));
			Application.Run(new Program(ptd.get_t, ptd.get_pt_ask, "3.ASK pt"));
			Application.Run(new Program(ptd.get_t, ptd.get_mt_ask, "4.ASK mt"));
			Application.Run(new Program(ptd.get_t, ptd.get_zP, "5.PSK zP"));
			Application.Run(new Program(ptd.get_t, ptd.get_xt_psk, "6.PSK xt"));
			Application.Run(new Program(ptd.get_t, ptd.get_pt_psk, "7.PSK pt"));
			Application.Run(new Program(ptd.get_t, ptd.get_mt_psk, "8.PSK mt"));
			Application.Run(new Program(ptd.get_t, ptd.get_zF, "9.FSK zF"));
			Application.Run(new Program(ptd.get_t, ptd.get_x1t_fsk, "10.FSK x1t"));
			Application.Run(new Program(ptd.get_t, ptd.get_x2t_fsk, "11.FSK x2t"));
			Application.Run(new Program(ptd.get_t, ptd.get_pt_fsk, "12.FSK pt"));
			Application.Run(new Program(ptd.get_t, ptd.get_mt_fsk, "13.FSK mt"));

			Console.ReadKey();
		}
		public Program(double[] x, double[] y, string name)
		{
					InitializeComponent(x, y, name);
		}
		private void InitializeComponent(double[] x, double[] y, string name)
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(12, 12);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1205, 563);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			this.chart1.Series[0].BorderWidth = 3;
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			//this.chart1.ChartAreas[0].AxisX.Minimum = 5;
			//this.chart1.ChartAreas[0].AxisX.Maximum = 7;
			//this.chart1.ChartAreas[0].AxisY.Minimum = 1535;
			//this.chart1.ChartAreas[0].AxisY.Maximum = 1536;

			for (int j = 0; j < x.Length; j++)
			{
					this.chart1.Series[0].Points.AddXY(x[j], y[j]);
			}
			this.chart1.Series[0].LegendText = name;

			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";

			this.chart1.SaveImage("../../../" + name + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta

			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}


	}
	

}

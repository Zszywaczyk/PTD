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
			/*double fn = 10000; //znacznie wieksze od fm
			double fs = 32768; // fs >= 2*fn
			double fm = 6; //znacznie mniejsze od fn
			double T = 0.5;
			double Am = 2;
			double kA;
			double kP;*/
			string bits = "11001010";
			int Tb = 5;
			double A1 = 2;
			double A2 = 6;
			double fs = 200;

			PTD ptd1 = new PTD(bits, Tb, A1, A2, fs);
			Application.Run(new Program(ptd1));

			Console.ReadKey();
		}
		public Program(PTD ptd)
		{
					InitializeComponent(ptd);
		}
		private void InitializeComponent(PTD ptd)
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

			int i;
			for (int j = 0; j < ptd.getMt.Length; j++)
			{
				this.chart1.Series[0].Points.AddXY(ptd.get_t[j], ptd.getMt[j]);
				/*i = (int)(j / ptd.getTb);
				//Console.WriteLine(j+". "+i+" = "+ ptd.getBits[i]);
				if (ptd.getBits[i] == '1')
				{
					this.chart1.Series[0].Points.AddXY(j, 1);
				}
				else if (ptd.getBits[i] == '0')
				{
					this.chart1.Series[0].Points.AddXY(j, 0);
				}*/
			}

			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";

			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}


	}
	

}

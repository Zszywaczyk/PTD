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
		enum Mod : int { ASK = 1, FSK = 2, PSK = 3, WidmoASK = 4, WidmoFSK = 5, WidmoPSK = 6 };
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
			double Tb = 2;
			double A1 = 2;
			double A2 = 6;
			double fs = 128;
			double NN = 2;

			PTD ptd1 = new PTD(bits, Tb, A1, A2, fs, NN);
			Application.Run(new Program(ptd1, (int)Mod.ASK));
			Application.Run(new Program(ptd1, (int)Mod.FSK));
			Application.Run(new Program(ptd1, (int)Mod.PSK));
			Application.Run(new Program(ptd1, (int)Mod.WidmoASK));
			Application.Run(new Program(ptd1, (int)Mod.WidmoFSK));
			Application.Run(new Program(ptd1, (int)Mod.WidmoPSK));

			Console.ReadKey();
		}
		public Program(PTD ptd, int choice)
		{
			switch (choice)
			{
				case 1:
					InitializeComponent(ptd, (int)Mod.ASK);
					break;
				case 2:
					InitializeComponent(ptd, (int)Mod.FSK);
					break;
				case 3:
					InitializeComponent(ptd, (int)Mod.PSK);
					break;
				case 4:
					InitializeComponent(ptd, (int)Mod.WidmoASK);
					break;
				case 5:
					InitializeComponent(ptd, (int)Mod.WidmoFSK);
					break;
				case 6:
					InitializeComponent(ptd, (int)Mod.WidmoPSK);
					break;
			}
					
		}
		private void InitializeComponent(PTD ptd, int choice)
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
			this.chart1.Series[0].BorderWidth = 2;
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;

			int localLength; //zaleznie czy to ask, fsk czy ich widma, jest rowna liczbie probek (stosowane w petli)
			if (choice == (int)Mod.WidmoASK || choice == (int)Mod.WidmoFSK || choice == (int)Mod.WidmoPSK)
				localLength = ptd.get_widmo_fK.Length;
			else
				localLength = ptd.get_t.Length;

			int i;
			for (int j = 0; j < localLength; j++)
			{
				if (choice == (int)Mod.ASK)
					this.chart1.Series[0].Points.AddXY(ptd.get_t[j], ptd.get_zA[j]);
				else if(choice == (int)Mod.FSK)
					this.chart1.Series[0].Points.AddXY(ptd.get_t[j], ptd.get_zF[j]);
				else if (choice == (int)Mod.PSK)
					this.chart1.Series[0].Points.AddXY(ptd.get_t[j], ptd.get_zP[j]);

				else if (choice == (int)Mod.WidmoASK)
					this.chart1.Series[0].Points.AddXY(ptd.get_widmo_fK[j], ptd.get_widmo_zA[j]);
				else if (choice == (int)Mod.WidmoFSK)
					this.chart1.Series[0].Points.AddXY(ptd.get_widmo_fK[j], ptd.get_widmo_zF[j]);
				else if (choice == (int)Mod.WidmoPSK)
					this.chart1.Series[0].Points.AddXY(ptd.get_widmo_fK[j], ptd.get_widmo_zP[j]);
			}

			string name="";
			if (choice == (int)Mod.WidmoASK)
			{
				ptd.findMaxDb(ptd.get_widmo_zA_log);
				name = Mod.ASK.ToString();
				this.chart1.Series[0].LegendText = "zA widmo\n AxisX: F\n AxisY: A";
				this.chart1.SaveImage("../../../" + (int)Mod.WidmoASK + " - zA_widmo.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			}
			else if (choice == (int)Mod.WidmoFSK)
			{
				ptd.findMaxDb(ptd.get_widmo_zF_log);
				name = Mod.FSK.ToString();
				this.chart1.Series[0].LegendText = "zF widmo\n AxisX: F\n AxisY: A";
				this.chart1.SaveImage("../../../" + (int)Mod.WidmoFSK + " - zF_widmo.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			}
			else if (choice == (int)Mod.WidmoPSK)
			{
				ptd.findMaxDb(ptd.get_widmo_zP_log);
				name = Mod.PSK.ToString();
				this.chart1.Series[0].LegendText = "zP widmo\n AxisX: F\n AxisY: A";
				this.chart1.SaveImage("../../../" + (int)Mod.WidmoPSK + " - zP_widmo.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			}
			else if (choice == (int)Mod.ASK)
			{
				this.chart1.Series[0].LegendText = "zA \n AxisX: T\n AxisY: F";
				this.chart1.SaveImage("../../../" + (int)Mod.ASK + " - zA.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
				ptd.saveXNToFile(ptd.get_zA, ptd.get_t, "zA"); //zapisuje dane wyjsciowe dla Lab5 (Pamietaj raz "z" raz "t" (modulo 2)(parzyste/nieparzyste))
			}
			else if (choice == (int)Mod.FSK)
			{
				this.chart1.Series[0].LegendText = "zF \n AxisX: T\n AxisY: F";
				this.chart1.SaveImage("../../../" + (int)Mod.FSK + " - zF.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
				ptd.saveXNToFile(ptd.get_zF, ptd.get_t, "zF"); //zapisuje dane wyjsciowe dla Lab5 (Pamietaj raz "z" raz "t" (modulo 2)(parzyste/nieparzyste))
			}
			else if (choice == (int)Mod.PSK)
			{
				this.chart1.Series[0].LegendText = "zP \n AxisX: T\n AxisY: F";
				this.chart1.SaveImage("../../../" + (int)Mod.PSK + " - zP.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
				ptd.saveXNToFile(ptd.get_zP, ptd.get_t, "zP"); //zapisuje dane wyjsciowe dla Lab5 (Pamietaj raz "z" raz "t" (modulo 2)(parzyste/nieparzyste))
			}
			

			if (choice == (int)Mod.WidmoASK || choice == (int)Mod.WidmoFSK || choice == (int)Mod.WidmoPSK)
				Console.WriteLine("Szerokość pasma "+name+": " + (ptd.get_widmo_fK[(int)ptd.getMax_pos[2]] - ptd.get_widmo_fK[(int)ptd.getMax_pos[0]]) + " Hz");


			// Set ToolTips for Data Point Series
			/*chart1.Series[0].ToolTip = "x: #VALX \n y: #VAL";

			// Set ToolTips for legend items
			chart1.Series[0].LegendToolTip = "Income in #LABEL  is #VAL million";

			// Set ToolTips for the Data Point labels
			chart1.Series[0].LabelToolTip = "#PERCENT";

			// Set ToolTips for second Data Point
			chart1.Series[0].Points[1].ToolTip = "Unknown";*/

			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";

			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}


	}
	

}

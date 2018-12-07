using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTD_Lab2
{
	public partial class Program : Form
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

		static void Main(string[] args)
		{
			int choice = 0;
			PTD ptd1 = new PTD(choice = 1);
			Console.WriteLine("1. X(n): \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd1, 1, choice));
			Application.Run(new Program(ptd1, 2, choice));

			PTD ptd2 = new PTD(choice = 3);
			Console.WriteLine("2. Z(n): \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd2, 1, choice));
			Application.Run(new Program(ptd2, 2, choice));

			PTD ptd3 = new PTD(choice = 5);
			Console.WriteLine("3. V(n): \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd3, 1, choice));
			Application.Run(new Program(ptd3, 2, choice));

			PTD ptd4 = new PTD(choice = 7);
			Console.WriteLine("4. U(n): \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd4, 1, choice));
			Application.Run(new Program(ptd4, 2, choice));

			PTD ptd5 = new PTD(choice = 9);
			Console.WriteLine("5. Ga H=2: \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd5, 1, choice));
			Application.Run(new Program(ptd5, 2, choice));

			PTD ptd6 = new PTD(choice = 11);
			Console.WriteLine("6. Gb H=5: \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd6, 1, choice));
			Application.Run(new Program(ptd6, 2, choice));

			PTD ptd7 = new PTD(choice = 13);
			Console.WriteLine("7. Gc H=50: \t dft {0} \t fft {1}", PTD.measurement[choice - 1], PTD.measurement[choice]);
			Application.Run(new Program(ptd7, 1, choice));
			Application.Run(new Program(ptd7, 2, choice));
			Console.WriteLine();

			Console.WriteLine("Sum: \t dft {0} \t fft {1}", PTD.totalMsDft, PTD.totalMsFft);

			Console.ReadKey();
			Console.ReadKey();
		}
		public Program(PTD ptd, int sw, int choice)
		{
			switch (sw)
			{
				case 1:
					InitializeComponent(ptd, choice);
					break;
				case 2:
					InitializeComponent2(ptd, choice);
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
			//this.chart1.ChartAreas[0].AxisX.Maximum = 100;
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < ptd.MLength(); i++)
			{
				this.chart1.Series[0].Points.AddXY(ptd.getFK(i), ptd.getMprim(i)); //skala decybelowa
				//this.chart1.Series[0].Points.AddXY(ptd.getFK(i), ptd.getM(i));
				//this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			//
			//Save image:
			switch (choice)
			{
				case 1:
					series1.Name = "1. X(N)_Line";
					this.Text = "X(N)_Line";
					this.chart1.SaveImage("../../../1 - xn_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 2:
					series1.Name = "3. Z(N)_Line";
					this.Text = "Z(N)_Line";
					this.chart1.SaveImage("../../../3 - zn_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 3:
					series1.Name = "5. V(N)_Line";
					this.Text = "V(N)_Line";
					this.chart1.SaveImage("../../../5 - vn_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 4:
					series1.Name = "7. U(N)_Line";
					this.Text = "U(N)_Line";
					this.chart1.SaveImage("../../../7 - un_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 5:
					series1.Name = "9. Ga(N)_Line";
					this.Text = "Ga(N)_Line";
					this.chart1.SaveImage("../../../9 - ga_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 6:
					series1.Name = "11. Gb(N)_Line";
					this.Text = "Gb(N)_Line";
					this.chart1.SaveImage("../../../11 - gb_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 7:
					series1.Name = "13. Gc(N)_Line";
					this.Text = "Gc(N)_Line";
					this.chart1.SaveImage("../../../13 - gc_line.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
			}

			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		private void InitializeComponent2(PTD ptd, int choice)
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
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1205, 563);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			//this.chart1.ChartAreas[0].AxisX.Maximum = 100;
			this.chart1.ChartAreas[0].AxisX.Minimum = 0.01;
			this.chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
			chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
			chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < ptd.MLength(); i++)
			{
				//this.chart1.Series[0].Points.AddXY(ptd.getFK(i), ptd.getMprim(i)); //skala decybelowa
				if (i < 1)
				{
					this.chart1.Series[0].Points.AddXY(ptd.getFK(i)+0.000001, ptd.getM(i));
				}
				else
				{
					this.chart1.Series[0].Points.AddXY(ptd.getFK(i), ptd.getM(i));
				}
				//this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			//
			//Save image:
			switch (choice)
			{
				case 1:
					series1.Name = "2. X(N)_Log";
					this.Text = "X(N)_Log";
					this.chart1.SaveImage("../../../2 - xn_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 2:
					series1.Name = "4. Z(N)_Log";
					this.Text = "Z(N)_Log";
					this.chart1.SaveImage("../../../4 - zn_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 3:
					series1.Name = "6. V(N)_Log";
					this.Text = "V(N)_Log";
					this.chart1.SaveImage("../../../6 - vn_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 4:
					series1.Name = "8. U(N)_Log";
					this.Text = "U(N)_Log";
					this.chart1.SaveImage("../../../8 - un_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 5:
					series1.Name = "10. Ga(N)_Log";
					this.Text = "Ga(N)_Log";
					this.chart1.SaveImage("../../../10 - ga_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 6:
					series1.Name = "12. Gb(N)_Log";
					this.Text = "Gb(N)_Log";
					this.chart1.SaveImage("../../../12 - gb_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case 7:
					series1.Name = "14. Gc(N)_Log";
					this.Text = "Gc(N)_Log";
					this.chart1.SaveImage("../../../14 - gc_log.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
			}

			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

	}
	

}

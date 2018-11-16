using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PTD_Lab1
{

	

	public partial class Program : Form
	{

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

		static void Main(string[] args)
		{
			//Console operations
			float f = 4;	//czestotliwosc Hz
			float phi = (float)((7 * Math.PI)/9);
			float fs = 100;	//czestotliwosc probkowania
			float T = 1;    //czas trwania sygnalu
			int N = (int)(fs * T);	
			PTD zad1 = new PTD(f, phi, fs, T, N);
			zad1.printXN();
			//========

			//Run Graphic
			Application.Run(new Program(zad1, "1"));
			Application.Run(new Program(zad1, "2a"));
			Application.Run(new Program(zad1, "2b"));
			

			T = 3;    //czas trwania sygnalu
			fs = 1200; //czestotliwosc probkowania
			N = (int)(fs * T);

			PTD zad3 = new PTD(T, fs, N);
			Application.Run(new Program(zad3, "3"));

			T = 4;
			fs = 10000;
			N = (int)(fs * T);
			int[] H = { 10, 20, 30 };

			PTD zad4 = new PTD(T, fs, N, H);
			Application.Run(new Program(zad4, "4a"));
			Application.Run(new Program(zad4, "4b"));
			Application.Run(new Program(zad4, "4c"));
		}

		public Program(PTD zad1, string block)
		{
			switch (block)
			{
				case "1":
					InitializeComponent(zad1);
					break;
				case "2a":
					InitializeComponent2a(zad1);
					break;
				case "2b":
					InitializeComponent2b(zad1);
					break;
				case "3":
					InitializeComponent3(zad1);
					break;
				case "4a":
					InitializeComponent4a(zad1);
					break;
				case "4b":
					InitializeComponent4b(zad1);
					break;
				case "4c":
					InitializeComponent4c(zad1);
					break;
			}
				
		}

		private void InitializeComponent(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "X(n)";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getN();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(i, zad1.getXN(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad1.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}

		private void InitializeComponent2a(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Z(n)";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getN();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(i, zad1.getZN(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad2a.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}
		private void InitializeComponent2b(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "V(n)";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getN();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(i, zad1.getVN(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad2b.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}
		private void InitializeComponent3(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "U(n)";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getN();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(i, zad1.getUN(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad3.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}
		private void InitializeComponent4a(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "g(t)  H=2";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getBig_T();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(zad1.getSmall_t(i), zad1.getGA(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad4a.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}
		private void InitializeComponent4b(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "g(t)  H=5";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getBig_T();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(zad1.getSmall_t(i), zad1.getGB(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad4b.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}
		private void InitializeComponent4c(PTD zad1)
		{

			this.SuspendLayout();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "g(t)  H=50";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1277, 526);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.ChartAreas[0].AxisX.Maximum = zad1.getBig_T();
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			// 
			// Program
			this.chart1.Series[0].BorderWidth = 3;
			for (int i = 0; i < zad1.getN(); i++)
			{
				this.chart1.Series[0].Points.AddXY(zad1.getSmall_t(i), zad1.getGC(i));
				this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			}
			// 
			this.chart1.SaveImage("../../../zad4c.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResumeLayout(false);
		}

	}
}

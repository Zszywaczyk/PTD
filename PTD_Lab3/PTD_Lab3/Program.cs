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
			iii = 1;
			{/*
			double fn=10000;//znacznie wieksze od fm
			double fs = 512;
			double fm = 1;
			double T = 1;
			double Am = 1;
			double kA = 0.8;
			double kP = 0.5; //wspolczynnik glebokosci modulacji (w %)
			//PTD ptd1 = new PTD(fs, fm, fn, kA, kP, T, Am, 4);
			//Application.Run(new Program(ptd1));
			PTD ptd1 = new PTD(fs, fm, fn, kA, kP, T, Am, 2);
			Application.Run(new Program(ptd1));
			Application.Run(new Program(ptd1)); // tu choice = 6
			*/
			}
			/*	double fn = 250;//znacznie wieksze od fm
			double fs = 512; // fs >= 2*fn
			double fm = 2;
			double T = 1;
			double Am = 1;
			double kA;
			double kP;*/
			double fn = 10000; //znacznie wieksze od fm
			double fs = 32768; // fs >= 2*fn
			double fm = 6; //znacznie mniejsze od fn
			double T = 0.5;
			double Am = 2;
			double kA;
			double kP;

			kA = 0.8;
			kP = 0.5;
			PTD ptd1 = new PTD(fs, fm, fn, kA, kP, T, Am, 111);
			Application.Run(new Program(ptd1));
			Application.Run(new Program(ptd1));
			Application.Run(new Program(ptd1));
			Application.Run(new Program(ptd1));

			kA = 10;
			kP = 2.14;
			PTD ptd2 = new PTD(fs, fm, fn, kA, kP, T, Am, 333);
			Application.Run(new Program(ptd2));
			Application.Run(new Program(ptd2));
			Application.Run(new Program(ptd2));
			Application.Run(new Program(ptd2));

			kA = 34;
			kP = 66;
			PTD ptd3 = new PTD(fs, fm, fn, kA, kP, T, Am, 555);
			Application.Run(new Program(ptd3));
			Application.Run(new Program(ptd3));
			Application.Run(new Program(ptd3));
			Application.Run(new Program(ptd3));

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
			
			
			/*this.chart1.ChartAreas[0].AxisX.Minimum = 230;
			this.chart1.ChartAreas[0].AxisX.Maximum = 250;
			this.chart1.ChartAreas[0].AxisY.Minimum = -11;
			this.chart1.ChartAreas[0].AxisY.Maximum = -6.5;*/
			// 
			// Program
			switch (ptd.getsetChoice)
			{
				default:
					break;
				/*
				case 1:
					this.chart1.ChartAreas[0].AxisX.Maximum = ptd.get_T;
					this.chart1.Series[0].LegendText = "m(t)";
					for (int i = 0; i < ptd.getN; i++)	{	this.chart1.Series[0].Points.AddXY(ptd.get_t[i], ptd.get_m[i]); }
					break;
				case 2:
					this.chart1.ChartAreas[0].AxisX.Maximum = ptd.get_T;
					System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
					this.chart1.Series.Add(series2);
					this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
					this.chart1.Series[0].LegendText = "m(t)";
					this.chart1.Series[1].LegendText = "zA(t)";
					for (int i = 0; i < ptd.getN; i++) { this.chart1.Series[0].Points.AddXY(ptd.get_t[i], ptd.get_m[i]); this.chart1.Series[1].Points.AddXY(ptd.get_t[i], ptd.get_zA[i]);  }
					break;
				case 3:
					this.chart1.ChartAreas[0].AxisX.Maximum = ptd.get_T;
					System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
					this.chart1.Series.Add(series3);
					this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
					this.chart1.Series[0].LegendText = "m(t)";
					this.chart1.Series[1].LegendText = "zP(t)";
					for (int i = 0; i < ptd.getN; i++) { this.chart1.Series[0].Points.AddXY(ptd.get_t[i], ptd.get_m[i]); this.chart1.Series[1].Points.AddXY(ptd.get_t[i], ptd.get_zP[i]); }
					break;
				case 4:
					this.chart1.ChartAreas[0].AxisX.Maximum = ptd.get_T;
					System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
					System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
					this.chart1.Series.Add(series4);
					this.chart1.Series.Add(series5);
					this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
					this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
					this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
					this.chart1.Series[2].Color = System.Drawing.Color.Violet;
					this.chart1.Series[0].LegendText = "m(t)";
					this.chart1.Series[1].LegendText = "zA(t)";
					this.chart1.Series[2].LegendText = "zP(t)";
					this.chart1.Series[2].BorderWidth = 2;
					for (int i = 0; i < ptd.getN; i++) { this.chart1.Series[0].Points.AddXY(ptd.get_t[i], ptd.get_m[i]); this.chart1.Series[1].Points.AddXY(ptd.get_t[i], ptd.get_zA[i]); this.chart1.Series[2].Points.AddXY(ptd.get_t[i], ptd.get_zP[i]); }
					break;
				case 5:
					this.chart1.Series[0].BorderWidth = 3;
					for (int i = 0; i < ptd.getN / 2; i++)
					{
						this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.Widmo_zA_log[i]);
						//Console.WriteLine(ptd.Widmo_zA[i].im);
					}
					ptd.getsetChoice = 6;
					break;
				case 6:
					this.chart1.Series[0].BorderWidth = 3;
					for (int i = 0; i < ptd.getN / 2; i++)
					{
						this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.Widmo_zP_log[i]);
						//Console.WriteLine(ptd.Widmo_zA[i].im);
					}
					
					break;
				//===================================
				//Testing testing...
				case 55:
					this.chart1.Series[0].BorderWidth = 3;
					for (int i = 0; i < ptd.getN / 2; i++)
					{
						this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA[1][i], ptd.Widmo_zA[0][i]);
						//Console.WriteLine(ptd.Widmo_zA[i].im);
					}
					ptd.getsetChoice = 66;
					break;
				case 66:
					this.chart1.Series[0].BorderWidth = 3;
					for (int i = 0; i < ptd.getN / 2; i++)
					{
						this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP[1][i], ptd.Widmo_zP[0][i]);
						//Console.WriteLine(ptd.Widmo_zA[i].im);
					}
					ptd.getsetChoice = 6;
					break;
				//===================================
				*/
			}
			//this.chart1.ChartAreas[0].AxisX.Minimum = 247;
			//this.chart1.ChartAreas[0].AxisX.Maximum = 255;

			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1.Series.Add(series2);
			this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			this.chart1.Series[1].Color = System.Drawing.Color.Red;
			this.chart1.Series[0].BorderWidth = 1;
			this.chart1.ChartAreas[0].AxisX.Minimum = 0;
			//this.chart1.ChartAreas[0].AxisX.Maximum = (ptd.getN/2)-1;

			switch (ptd.getsetChoice)
			{
				case 111:
					
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA[1][i], ptd.Widmo_zA[0][i]);
						ptd.getsetChoice = 222;
					}
					break;
				case 222:
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP[1][i], ptd.Widmo_zP[0][i]);
					}
					ptd.getsetChoice = -111;
					break;
				case 333:
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA[1][i], ptd.Widmo_zA[0][i]);
					}
					ptd.getsetChoice = 444;
					break;
				case 444:
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP[1][i], ptd.Widmo_zP[0][i]);
					}
					ptd.getsetChoice = -333;
					break;
				case 555:
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA[1][i], ptd.Widmo_zA[0][i]);
					}
					ptd.getsetChoice = 666;
					break;
				case 666:
					for (int i = 0; i < (ptd.getN / 2); i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP[1][i], ptd.Widmo_zP[0][i]);
					}
					ptd.getsetChoice = -555;
					break;


				case -111:
					series1.Name = iii+". Mod amp\n" + "kA="+ptd.getKA+"\n";
					this.Text = iii + ". Mod amp  " + "kA=" + ptd.getKA + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zA_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.Widmo_zA_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getM3A);
						
						if(ptd.getMax[0]>= ptd.getMax[1]-3 && ptd.getMax[2] >= ptd.getMax[1]-3)
						{
							if(ptd.getMax_pos[0] == i)
							{
								this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getMax[1] - 3);
							}
							if (ptd.getMax_pos[1] == i)
							{
								this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getMax[1] - 3);
							}
							if (ptd.getMax_pos[2] == i)
							{
								this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getMax[1] - 3);
							}
						}
					}
					Console.WriteLine("Szerokość pasma: "+ (ptd.Widmo_zA_fK[(int)ptd.getMax_pos[2]] - ptd.Widmo_zA_fK[(int)ptd.getMax_pos[0]]) + " Hz");
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000-100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000+100;
					ptd.getsetChoice = -222;
					this.chart1.SaveImage("../../../"+(iii-1)+" - zA.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case -222:
					series1.Name = iii + ". Mod kat\n" + "kP=" + ptd.getKP + "\n";
					this.Text = iii + ". Mod kat  " + "kP=" + ptd.getKP + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zP_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.Widmo_zP_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.getM3P);
					}
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000 - 100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000 + 100;
					this.chart1.SaveImage("../../../" + (iii - 1) + " - zP.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case -333:
					series1.Name = iii + ". Mod amp\n" + "kA=" + ptd.getKA + "\n";
					this.Text = iii + ". Mod amp  " + "kA=" + ptd.getKA + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zA_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.Widmo_zA_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getM3A);
					}
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000 - 100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000 + 100;
					ptd.getsetChoice = -444;
					this.chart1.SaveImage("../../../" + (iii - 1) + " - zA.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case -444:
					series1.Name = iii + ". Mod kat\n" + "kP=" + ptd.getKP + "\n";
					this.Text = iii + ". Mod kat  " + "kP=" + ptd.getKP + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zP_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.Widmo_zP_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.getM3P);
					}
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000 - 100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000 + 100;
					this.chart1.SaveImage("../../../" + (iii - 1) + " - zP.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case -555:
					series1.Name = iii + ". Mod amp\n" + "kA=" + ptd.getKA + "\n";
					this.Text = iii + ". Mod amp  " + "kA=" + ptd.getKA + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zA_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.Widmo_zA_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zA_fK[i], ptd.getM3A);
					}
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000 - 100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000 + 100;
					ptd.getsetChoice = -666;
					this.chart1.SaveImage("../../../" + (iii - 1) + " - zA.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
				case -666:
					series1.Name = iii + ". Mod kat\n" + "kP" + ptd.getKP + "\n";
					this.Text = iii + ". Mod kat  " + "kP" + ptd.getKP + "\n";
					iii++;
					for (int i = 1; i < ptd.Widmo_zP_log.Length; i++)
					{
						this.chart1.Series[0].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.Widmo_zP_log[i]);
						//this.chart1.Series[1].Points.AddXY(ptd.Widmo_zP_fK[i], ptd.getM3P);
					}
					//this.chart1.ChartAreas[0].AxisX.Minimum = 10000 - 100;
					//this.chart1.ChartAreas[0].AxisX.Maximum = 10000 + 100;
					this.chart1.SaveImage("../../../" + (iii - 1) + " - zP.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); //zapisujemy charta
					break;
			}

			this.ClientSize = new System.Drawing.Size(1315, 587);
			this.Controls.Add(this.chart1);
			this.Name = "Program";
			
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}


	}
	

}

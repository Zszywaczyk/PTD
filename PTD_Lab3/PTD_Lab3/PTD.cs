using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FFTLibrary;

namespace PTD_Lab3
{
	public class PTD
	{
		double[] m; //sygnał modulujący; ton prosty
		double[] zA; //sygnał zmodulowany amplitudy
		double[] zP; //sygnał zmodulowany kąta
		double kA; //wspolczynnik glebokosci modulacji
		double kP;
		double fn; //czestotliwosc sygnalu nośnego
		double fm; //czestotliwosc sygnalu informacyjnegoS
		double fs;
		double Am; //amplituda sygnału modulującego
		double T; //czas całkowity
		double[] t; //czas dla próbek
		double N; //liczba próbek
		double[][] widmo_zA;
		double[] widmo_zA_log;
		double[] widmo_zA_fK;
		double[][] widmo_zP;
		double[] widmo_zP_log;
		double[] widmo_zP_fK;
		double m3A, m3P;
		double[] max = new double[3];
		double[] max_pos = new double[3];

		int choice;

		public PTD(double fs, double fm, double fn, double kA, double kP, double T, double Am, int choice)
		{
			this.fs = fs; this.fm = fm; this.fn = fn;  this.T = T; this.Am = Am; this.choice = choice;

			this.N = fs * T;
			this.m = new double[(int)N]; this.t = new double[(int)N];
			mt(); //liczymy m(t)

			this.kA = kA;
			this.zA = new double[(int)N]; this.t = new double[(int)N];
			zAt(); //liczymy zA(t)
			widmo_zA = operationFFT(zA);
			widmo_zA_fK = widmo_zA[1];
			widmo_zA_log = operationLog(widmo_zA[0]);
			m3A = findM3(widmo_zA_log);
			findMaxDb(widmo_zA_log);

			this.kP = kP;
			this.zP = new double[(int)N]; this.t = new double[(int)N];
			zPt(); //liczymy zP(t)
			widmo_zP = operationFFT(zP);
			widmo_zP_fK = widmo_zP[1];
			widmo_zP_log = operationLog(widmo_zP[0]);
			//m3P = findM3(widmo_zP_log);

			//widma
		}
		private void mt()
		{
			for (int i=0;i<(int)N;i++)
			{
				//this.t[i] = new double();
				this.t[i] = i / fs;
				m[i] = Am * Math.Sin(2 * Math.PI * fm * t[i]);
				//Console.WriteLine("{0}: {1}", i, t[i]);
				//Console.WriteLine("{0} * Sin(2 * {1} * {2} * {3})", Am, Math.PI, fm, t[i]);
			}
			//Console.WriteLine(Am);
		}
		private void zAt()
		{
			for (int i = 0; i < (int)N; i++)
			{
				this.t[i] = i / fs;
				zA[i] = (kA * m[i] + 1) * Math.Cos(2 * Math.PI * fn * t[i]);
				//Console.WriteLine("{0}: {1}", i, zA[i]);
			}
		}
		private void zPt()
		{
			for (int i = 0; i < (int)N; i++)
			{
				this.t[i] = i / fs;
				zP[i] = Math.Cos(2 * Math.PI * fn * t[i] + kP * m[i]);
				//Console.WriteLine("{0}: {1}", i, zA[i]);
			}
		}
		private double[][] operationFFT(double[] x)
		{

			double fftN = 0;
			int m = 0;
			while((fftN = Math.Pow(2, m)) < N)
			{
				m++;
			}
			int localN = (int)fftN / 2;
			double[] im = new double[(int)fftN];
			double[] re = new double[(int)fftN];
			double[][] result = new double[2][];
			for (int i = 0; i < fftN; i++)
			{
				im[i] = 0;
				re[i] = x[i];
				
			}
			FFTLibrary.Complex.FFT(1, m, re, im);
			result[0] = new double[localN];
			result[1] = new double[localN];
			for (int i = 0; i < localN; i++)
			{
				result[0][i] = Math.Sqrt(re[i] * re[i] + im[i] * im[i]);
				result[1][i] = i * (fs / fftN);
			}

				return result;
			
		}
		private double[] operationLog(double[] localX)
		{
			double[] localY = new double[localX.Length];
			for(int i = 0; i < localX.Length; i++)
			{
				localY[i] = 10 * Math.Log(Math.Abs(localX[i]));
				//Console.WriteLine(i+": "+localX[i]);
			}
			//findMaxDb(localY);
			return localY;
		}
		private void findMaxDb(double[] localY)
		{
			max[0] = localY[0];
			for(int i = 1; i<localY.Length; i++)
			{
				if(max[0] < localY[i])
				{
					max[0] = localY[i];
					max_pos[0] = i;
				}
			}
			//Console.WriteLine(max[0]);
			max[1] = max[0]-40000;
			for (int i = 1; i < localY.Length; i++)
			{
				if (max[1] < localY[i] && localY[i] < max[0])
				{
					max[1] = localY[i];
					max_pos[1] = i;
				}
			}
			//Console.WriteLine(max[1]);
			max[2] = max[1] - 40000;
			for (int i = 1; i < localY.Length; i++)
			{
				if (max[2] < localY[i] && localY[i] < max[1])
				{
					max[2] = localY[i];
					max_pos[2] = i;
				}
			}
			//Console.WriteLine(max[2]);
			//Console.WriteLine();
			double temp;
			double temp_pos;

			for(int i = 1; i < 3; i++)
			{
				for (int j = i; j < 3; j++)
				{
					if (max_pos[i - 1] > max_pos[j])
					{
						temp_pos = max_pos[j];
						temp = max[j];

						max_pos[j] = max_pos[i - 1];
						max[j] = max[i - 1];

						max[i - 1] = temp;
						max_pos[i - 1] = temp_pos;
					}
				}
			}
			Console.WriteLine(max[0]);
			Console.WriteLine(max[1]);
			Console.WriteLine(max[2]);

			Console.WriteLine();
		}

		private double findM3(double[] localY)
		{
			double max = localY[0];
			for (int i = 1; i < localY.Length; i++)
			{
				if (max < localY[i])
				{
					max = localY[i];
				}
			}
			return max-3;
		}

		public static void SaveToFile()
		{

		}

		public double[] get_t { get => t;}
		public double get_T { get => T; }
		public double[] get_m { get => m; }
		public int getN { get => (int)N; }
		public double[] get_zA { get => zA; }
		public double[] get_zP { get => zP; }
		public int getsetChoice { get => choice; set => choice = value; }
		public double[][] Widmo_zP { get => widmo_zP; }
		public double[] Widmo_zP_log { get => widmo_zP_log; }
		public double[] Widmo_zP_fK { get => widmo_zP_fK; }
		public double[][] Widmo_zA { get => widmo_zA; }
		public double[] Widmo_zA_log { get => widmo_zA_log; }
		public double[] Widmo_zA_fK { get => widmo_zA_fK; }
		public double getM3A { get => m3A;}
		public double getM3P { get => m3P;}
		public double[] getMax { get => max; }
		public double[] getMax_pos { get => max_pos; }
		public double getKA { get => kA; }
		public double getKP{ get => kP; }
	}
}

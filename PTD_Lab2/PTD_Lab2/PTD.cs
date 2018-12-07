using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PTD_Lab2
{
	public class PTD
	{
		double[] x; //x,z,v,u,ga,gb,gc
		
		int N;
		double fs;
		double[] fk;
		double[] DFT_R;
		double[] DFT_Im;
		double[] M;
		double[] Mprim;
		Stopwatch stopWatch = new Stopwatch();
		public static double totalMsDft=0, totalMsFft = 0;
		public static List<string> measurement = new List<string>();


		public PTD(int choice)
		{
			if (choice == 1){ readXNFromFile(1); }
			else if (choice == 3) {	readXNFromFile(2);	}
			else if (choice == 5){	readXNFromFile(3);	}
			else if (choice == 7){	readXNFromFile(4);	}
			else if (choice == 9){	readXNFromFile(5);	}
			else if (choice == 11){	readXNFromFile(6);	}
			else if (choice == 13){	readXNFromFile(7);	}
			operationDFT();
			zad2();
			operationFFT();
		}


		private void readXNFromFile(int choice) {
			//wczytanie danych xn
			string readText="";
			switch (choice) {
				case 1:
					readText = File.ReadAllText("../../../xn.txt");
					break;
				case 2:
					readText = File.ReadAllText("../../../zn.txt");
					break;
				case 3:
					readText = File.ReadAllText("../../../vn.txt");
					break;
				case 4:
					readText = File.ReadAllText("../../../un.txt");
					break;
				case 5:
					readText = File.ReadAllText("../../../ga.txt");
					break;
				case 6:
					readText = File.ReadAllText("../../../gb.txt");
					break;
				case 7:
					readText = File.ReadAllText("../../../gc.txt");
					break;
			}
		string[] lines = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			this.x = new double[lines.Length-1];
			this.N = lines.Length-1;

			for (int i = 0; i < N+1; i++)
			{
				if (i < N - 1)
				{
					x[i] = Convert.ToDouble(lines[i]);
				}
				else
				{
					this.fs = Convert.ToDouble(lines[i]);
				}
			}
		}

		private void operationDFT() {
			DFT_R = new double[N];
			DFT_Im = new double[N];
			//stopWatch = new Stopwatch(); //set a timer

			stopWatch.Start();
			for (int k = 0; k < N; k++)
			{
				DFT_R[k] = 0;
				DFT_Im[k] = 0;
				for (int n = 0; n < N; n++)
				{
					DFT_R[k] = DFT_R[k] + x[n] * Math.Cos(-((2 * Math.PI * n * k) / (N)));
					DFT_Im[k] = DFT_Im[k] + x[n] * Math.Sin(-((2 * Math.PI * n * k) / (N)));
				}
				//System.Console.WriteLine("DFT "+k+" "+ "(" + DFT_R[k] + ", " + DFT_Im[k] + ")");
			}
			//System.Console.WriteLine(fs);
			stopWatch.Stop();
			//Console.WriteLine("czas = "+stopWatch.Elapsed);
		}
		private void zad2()
		{
			M = new double[N / 2+1];
			Mprim = new double[N / 2+1];
			fk = new double[N / 2 + 1];
			//System.Console.WriteLine(M.Length);
			//stopWatch = new Stopwatch();
			stopWatch.Start();
			for (int k = 0; k <= N / 2; k++)
			{
				M[k] = Math.Sqrt((DFT_R[k] * DFT_R[k]) + (DFT_Im[k] * DFT_Im[k]));
				if (M[k] > 0)
				{
					Mprim[k] = 10 * Math.Log10(M[k]);       //ile decybeli osiaga dla jakiego k
				}
				else if (M[k] < 0)
				{
					Mprim[k] = 500;
				}
				else { Mprim[k] = 1000; }
				//Console.WriteLine(k + "= " + Mprim[k]);
				fk[k] = k * (fs / N);
			}
			//Console.WriteLine(fs);
			stopWatch.Stop();
			measurement.Add(stopWatch.Elapsed.ToString());
			totalMsDft+=stopWatch.Elapsed.TotalMilliseconds;
		}
		private void operationFFT()
		{
			
			double fftN = 0;
			int m;
			for (m = 0; (fftN = Math.Pow(2, m)) < N; m++)//szukamy N=2^m
			{
				if (fftN > (N / 2)) //kiedy jest blisko N
				{
					break;
				}
			}

			//FFTLibrary.Complex[] complex = new FFTLibrary.Complex[(int)fftN];
			double[] zeros = new double[(int)fftN];
			double[] xx = new double[(int)fftN];
			for (int i = 0; i < fftN; i++)
			{
				zeros[i] = 0;
				xx[i] = x[i];
				//complex[i] = new FFTLibrary.Complex(x[i], 0);
				
			}
			stopWatch.Reset();
			stopWatch.Start();
			FFTLibrary.Complex.FFT(1, m, xx, zeros);
			stopWatch.Stop();
			measurement.Add(stopWatch.Elapsed.ToString());
			totalMsFft += stopWatch.Elapsed.TotalMilliseconds;
			/*double fftN=0;
			for (int m=0;(fftN = Math.Pow(2,m))<N;m++)//szukamy N=2^m
			{
				if(fftN>(N/2)) //kiedy jest blisko N
				{
					break;
				}
			}
			Console.WriteLine(); Console.WriteLine();
			Console.WriteLine(fftN);
			Console.WriteLine();
			AForge.Math.Complex[] complex = new AForge.Math.Complex[(int)fftN];
			for(int i=0; i<fftN; i++)
			{
				complex[i] = (AForge.Math.Complex)x[i];
				//Console.WriteLine("FFT "i+": "+complex[i].ToString());
			}
			AForge.Math.FourierTransform.FFT(complex, AForge.Math.FourierTransform.Direction.Forward);
			for (int i = 0; i < fftN; i++)
			{
				//complex[i] = (AForge.Math.Complex)x[i];
				//Console.WriteLine("FFT "+i + " " + complex[i].ToString());
			}*/
		}
		public int getN()
		{
			return this.N;
		}
		public double getDFT_RK(int k)
		{
			return DFT_R[k];
		}
		public double getDFT_ImK(int k)
		{
			return DFT_Im[k];
		}
		public double getFK(int i)
		{
			return fk[i];
		}
		public int MLength()
		{
			return M.Length;
		}
		public double getM(int i)
		{
			return M[i];
		}
		public double getMprim(int i)
		{
			return Mprim[i];
		}
		public double[] X { get => x; set => x = value; }
	}
}

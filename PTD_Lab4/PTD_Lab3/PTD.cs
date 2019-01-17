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
		string bits;	//ciąg bitów wejściowy
		int[] mt;	//ciag bitów uzupełnienony o dodatkowe
		double Tb;  //czas trwania jednego bitu
		double T; //czas całkowity
		double fs; //czestotliwość próbkowania
		double fn, fn1, fn2;
		double NN;
		int N; 
		double A1, A2;
		double[] zA, zF, zP, t;
		double[] widmo_zA, widmo_zF, widmo_zP;
		double[] widmo_zA_log, widmo_zF_log, widmo_zP_log;
		double[] widmo_fK;

		double[] max = new double[3];
		double[] max_pos = new double[3];


		

		public PTD(string bits, double Tb, double A1, double A2, double fs, double NN)
		{
			this.NN = NN;

			this.A1 = A1;
			this.A2 = A2;
			this.bits = bits;
			this.Tb = Tb;
			this.fs = fs;
			T = Tb * bits.Length;
			N = (int)(T * fs);
			set_mt();
			set_zA();
			set_zF();
			set_zP();

			double[][] temp = operationFFT(zA);
			widmo_zA = temp[0];
			//widmo_zA = testfft(zA);
			widmo_zA_log = operationLog(widmo_zA);
			widmo_fK = temp[1];
			//findMaxDb(widmo_zA_log);
			//testfft(zA);
			
			temp = operationFFT(zF);
			widmo_zF = temp[0];
			//widmo_zF = testfft(zF);
			widmo_zF_log = operationLog(widmo_zF);
			//findMaxDb(widmo_zF_log);

			temp = operationFFT(zP);
			widmo_zP = temp[0];
			widmo_zP_log = operationLog(widmo_zP);
			//findMaxDb(widmo_zP_log);

		}

		void set_mt()
		{
			mt = new int[N];
			t = new double[N];
			int i=0;
			for (int j = 0; j < N; j++)
			{
				t[j] = j / fs;
				
				if (getBits[i] == '1')
				{
					mt[j] = 1;
				}
				else if (getBits[i] == '0')
				{
					mt[j] = 0;
				}
				//Console.WriteLine(j+". "+t[j]+"= "+mt[j]);
				if (t[j] == Tb && i==0) 
				{
					i++;
				}
				else if ((t[j] % Tb) == 0 && i != 0)
				{
					i++;
				}
			}
		}

		void set_zA()
		{
			fn = NN * (1 / Tb);
			zA = new double[N];
			for (int j = 0; j < N; j++)
			{
				if(mt[j] == 0)
				{
					zA[j] = A1 * Math.Sin(2 * Math.PI * fn * t[j]);
				}
				else if(mt[j] == 1)
				{
					zA[j] = A2 * Math.Sin(2 * Math.PI * fn * t[j]);
				}
			}

			/*for(int i = 0; i< mt.Length; i++)
			{
				if (mt[i] == 1)
				{
					//<---------------------TU
					//zA = 
				}
				else if(mt[i] == 0)
				{

				}
			}*/
		}

		void set_zF()
		{
			fn1 = (NN + 1) * (1 / Tb);
			fn2 = (NN + 2) * (1 / Tb);
			zF = new double[N];
			for (int j = 0; j < N; j++)
			{
				if (mt[j] == 0)
				{
					zF[j] = Math.Sin(2 * Math.PI * fn1 * t[j]);
				}
				else if (mt[j] == 1)
				{
					zF[j] = Math.Sin(2 * Math.PI * fn2 * t[j]);
				}
			}
		}

		void set_zP()
		{
			fn = NN * (1 / Tb);
			zP = new double[N];
			for (int j = 0; j < N; j++)
			{
				if (mt[j] == 0)
				{
					zP[j] = Math.Sin(2 * Math.PI * fn * t[j]);
				}
				else if (mt[j] == 1)
				{
					zP[j] = Math.Sin(2 * Math.PI * fn * t[j]+Math.PI);
				}
			}
		}

		private double[][] operationFFT(double[] x)
		{

			double fftN = 0;
			int m = 0;
			while ((fftN = Math.Pow(2, m)) < N)
			{
				m++;
			}
			int localN = (int)fftN / 2;
			double[] im = new double[(int)fftN];
			double[] re = new double[(int)fftN];
			double[][] result = new double[2][];
			//Console.WriteLine(fftN);
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
			for (int i = 0; i < localX.Length; i++)
			{
				localY[i] = 10 * Math.Log(localX[i]);
				//Console.WriteLine(i+": "+localX[i]);
			}
			//findMaxDb(localY);
			return localY;
		}

		public void findMaxDb(double[] localY)
		{
			max[0] = localY[0];
			for (int i = 1; i < localY.Length; i++)
			{
				if (max[0] < localY[i])
				{
					max[0] = localY[i];
					max_pos[0] = i;
				}
			}
			//Console.WriteLine(max_pos[0]+". "+max[0]);
			max[1] = max[0] - 40000;
			for (int i = 1; i < localY.Length; i++)
			{
				if (max[1] < localY[i] && localY[i] < max[0])
				{
					max[1] = localY[i];
					max_pos[1] = i;
				}
			}
			//Console.WriteLine(max_pos[1] + ". " + max[1]);
			max[2] = max[1] - 40000;
			for (int i = 1; i < localY.Length; i++)
			{
				if (max[2] < localY[i] && localY[i] < max[1])
				{
					max[2] = localY[i];
					max_pos[2] = i;
				}
			}
			//Console.WriteLine(max_pos[2] + ". " + max[2]);
			//Console.WriteLine();
			double temp;
			double temp_pos;

			for (int i = 1; i < 3; i++)
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
			//Console.WriteLine(max_pos[0] +" "+ max[0]);
			//Console.WriteLine(max_pos[1] + " " + max[1]);
			//Console.WriteLine(max_pos[2] + " " + max[2]);

			//Console.WriteLine();
		}

		//================================================================
		//zapisuje dane wyjsciowe dla Lab5
		//(Pamietaj raz "z" raz "t" (modulo 2)(parzyste/nieparzyste))
		public void saveXNToFile(double[] x, double[] t, string name)
		{
			string createText;
			createText = "";
			int localLength = t.Length;
			for (int i = 0; i < localLength; i++)
			{
				if (i%2==0)
				{
					createText += x[i];
				}
				else
				{
					createText += x[i];
					createText += t[i];
				}

				if (i != localLength - 1)
				{
					createText += Environment.NewLine;
				}
			}
			File.WriteAllText("../../../../PTD_Lab5/"+name+".txt", createText);
		}

		/*private double[] testfft(double[] x)
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
			AForge.Math.Complex[] complex = new AForge.Math.Complex[(int)fftN];
			for (int i = 0; i < fftN; i++)
			{
				complex[i] = (AForge.Math.Complex)x[i];
				//Console.WriteLine("FFT "+i+": "+complex[i].ToString());
			}
			AForge.Math.FourierTransform.FFT(complex, AForge.Math.FourierTransform.Direction.Forward);
			for (int i = 0; i < fftN; i++)
			{
				//complex[i] = (AForge.Math.Complex)x[i];
				//Console.WriteLine("FFT "+i + " " + complex[i].ToString());
			}

			double[][] result = new double[2][];
			result[0] = new double[(int)fftN];
			result[1] = new double[(int)fftN];
			for (int i = 0; i < fftN; i++)
			{
				result[0][i] = Math.Sqrt(complex[i].Re * complex[i].Re + complex[i].Im * complex[i].Im);
				result[1][i] = i * (fs / fftN);
			}

			return result[0];

		}*/

		public string getBits { get => bits; }
		public double getTb { get => Tb; }
		public double[] get_t { get => t; }
		public int getN { get => N; set => N = value; }
		public int[] getMt { get => mt; }
		public double[] get_zA { get => zA; }
		public double[] get_zF { get => zF; }
		public double[] get_zP { get => zP; }
		public double[] get_widmo_zA { get => widmo_zA; }
		public double[] get_widmo_zF { get => widmo_zF; }
		public double[] get_widmo_zP { get => widmo_zP; }
		public double[] get_widmo_fK { get => widmo_fK; }
		public double[] get_widmo_zA_log { get => widmo_zA_log; }
		public double[] get_widmo_zF_log { get => widmo_zF_log; }
		public double[] get_widmo_zP_log { get => widmo_zP_log; }
		public double[] getMax { get => max; }
		public double[] getMax_pos { get => max_pos; }
	}
}

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

		int choice;

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


		public string getBits { get => bits; }
		public double getTb { get => Tb; }
		public double[] get_t { get => t; }
		public int getN { get => N; set => N = value; }
		public int[] getMt { get => mt; }
		public double[] get_zA { get => zA; }
		public double[] get_zF { get => zF; }
		public double[] get_zP { get => zP; }
	}
}

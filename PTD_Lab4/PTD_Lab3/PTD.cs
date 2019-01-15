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
		int N; 
		double A1, A2;
		double[] zA, zF, zP, t;

		int choice;

		public PTD(string bits, double Tb, double A1, double A2, double fs)
		{
			this.A1 = A1;
			this.A2 = A2;
			this.bits = bits;
			this.Tb = Tb;
			this.fs = fs;
			T = Tb * bits.Length;
			N = (int)(T * fs);
			set_mt();

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
				Console.WriteLine(j+". "+t[j]+"= "+mt[j]);
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
			/*double fn = N * (1 / Tb);
			for(int i = 0; i< mt.Length; i++)
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


		public string getBits { get => bits; }
		public double getTb { get => Tb; }
		public double[] get_t { get => t; }
		public int getN { get => N; set => N = value; }
		public int[] getMt { get => mt; }
	}
}

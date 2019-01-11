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
		double Tb;	//czas trwania jednego bitu
		int N;  //ilosc bitow przemnozona przez czas kazdej jednej
		double A1, A2;
		double[] zA, zF, zP;

		int choice;

		public PTD(string bits, double Tb, double A1, double A2)
		{
			this.A1 = A1;
			this.A2 = A2;
			this.bits = bits;
			this.Tb = Tb;
			N = bits.Length * (int)Tb;
			set_mt();



		}

		void set_mt()
		{
			mt = new int[N];
			int i;
			for (int j = 0; j < getN; j++)
			{
				i = (int)(j / getTb);
				
				if (getBits[i] == '1')
				{
					mt[j] = 1;
				}
				else if (getBits[i] == '0')
				{
					mt[j] = 0;
				}
				//Console.WriteLine(j+". "+mt[j]);
			}
		}

		void set_zA()
		{
			double fn = N * (1 / Tb);
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
			}
		}


		public string getBits { get => bits; }
		public double getTb { get => Tb; }
		public int getN { get => N; set => N = value; }
	}
}

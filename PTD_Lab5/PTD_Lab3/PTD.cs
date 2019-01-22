//PTD Lab 05
//Patryk Chowratowicz 32717
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
		double[] t;
		double[] zA, zF, zP;
		double[] sant, sn1t, sn2t, spnt;
		double Tb;

		double[] xt_ask, pt_ask, mt_ask;
		double h_ask;

		double[] xt_psk, pt_psk, mt_psk;
		double h_psk;

		double[] x1t_fsk, x2t_fsk, pt_fsk, mt_fsk;
		double h_fsk;

		public PTD(double Tb)
		{
			readAllFiles();
			this.Tb = Tb;

			//ask
			xt_ask = xtOperation(zA, sant);
			pt_ask = ptOperation(xt_ask);
			h_ask = 1536;
			mt_ask = mtOperation(pt_ask, h_ask);
			
			//psk
			xt_psk = xtOperation(zP, spnt);
			pt_psk = ptOperation(xt_psk);
			h_psk = 0;
			mt_psk = mtOperation(pt_psk, h_psk);

			//fsk
			x1t_fsk = xtOperation(zF, sn1t);
			x2t_fsk = xtOperation(zF, sn2t);
			pt_fsk = ptOperation(ptOperation(x1t_fsk), ptOperation(x2t_fsk));
			h_fsk = 0;
			mt_fsk = mtOperation(pt_psk, h_psk);
		}

		private double[] xtOperation(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				Console.WriteLine(a.Length + "    " + b.Length);
				throw new Exception("a != b");
			}
			else
			{

				double[] result = new double[a.Length];
				for (int i = 0; i < a.Length; i++)
				{
					result[i] = a[i] * b[i];
					//Console.WriteLine(result[i]);
				}

				return result;
			}

		}

		private double fastIntegral(double localX, double from, double to)
		{
			return localX * to - localX * from;
		}

		private double[] ptOperation(double[] a)
		{
			double[] result = new double[a.Length];
			int j = 0;
			double sum = 0;
			/*int NTb=0;	//liczba probek do czasu Tb
			for(int i = 0; t[i]<Tb; i++)
			{
				NTb = i+1;
			}
			Console.WriteLine(NTb);

			int parts=8; // czesci na jakie zostaje podzielona całka
			for(int i=parts; NTb % i != 0; )
			{
				parts = i - 1;
				i = parts;
				if(parts == 0)
				{
					parts--;
					i = parts;
				}
			}
			Console.WriteLine(parts);


			for (int i = 0; i < a.Length; i++)
			{
				sum += a[i];
				//result[i] = sum;
				if (i+1 == a.Length)
					break;
				result[i] = fastIntegral(a[i],t[i],t[i+1]);

				/*if (t[j + 1] >= Tb)
				{
					j = 0;
					sum = 0;
				}
				else
				{
					j++;
				}
			}*/

			
			for (int i=0; i < a.Length; i++)
			{
				sum += a[i];
				result[i] = sum;
				//result[i] = fastIntegral(a[i], t[j]);
				
				if (t[j+1] >= Tb)
				{
					j = 0;
					sum = 0;
				}
				else
				{
					j++;
				}
			}
			return result;
		}
		private double[] ptOperation(double[] a, double[] b)
		{
			if (a.Length != b.Length)
				throw new Exception("a != b");
			else
			{

				double[] result = new double[a.Length];
				for (int i = 0; i < a.Length; i++)
				{
					result[i] = a[i] - b[i];
					//Console.WriteLine(result[i]);
				}

				return result;
			}
		}

			private double[] mtOperation(double[] localX, double h)
		{
			double[] result = new double[localX.Length];
			for(int i = 0; i< localX.Length; i++)
			{
				if (localX[i] < h)
				{
					result[i] = 0;
				}
				else if (localX[i] >= h)
				{
					result[i] = 1;
				}
			}

			return result;
		}

			/// <summary>
			///Read All files
			/// </summary>
		private void readAllFiles()
		{
			this.t = readXNFromFile("t");
			this.zA = readXNFromFile("zA");
			this.zF = readXNFromFile("zF");
			this.zP = readXNFromFile("zP");
			this.sant = readXNFromFile("sant");
			this.sn1t = readXNFromFile("sn1t");
			this.sn2t = readXNFromFile("sn2t");
			this.spnt = readXNFromFile("spnt");
		}

		/// <summary>
		/// Read single file. Uses in readAllfiles.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private double[] readXNFromFile( string name)
		{
			//wczytanie danych xn
			string readText = File.ReadAllText("../../../"+name+".txt");
				
			string[] lines = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			double[] localX = new double[lines.Length];
			int localN = lines.Length - 1;

			for (int i = 0; i < localN + 1; i++)
			{
				localX[i] = Convert.ToDouble(lines[i]);
				//Console.WriteLine(i + ". " + localX[i]);
			}

			return localX;
		}

		public double[] get_t { get => t; }
		//ask
		public double[] get_xt_ask { get => xt_ask; }
		public double[] get_pt_ask { get => pt_ask; }
		public double[] get_mt_ask { get => mt_ask; }
		//psk
		public double[] get_xt_psk { get => xt_psk; }
		public double[] get_pt_psk { get => pt_psk; }
		public double[] get_mt_psk { get => mt_psk; }
		//fsk
		public double[] get_x1t_fsk { get => x1t_fsk; }
		public double[] get_x2t_fsk { get => x2t_fsk; }
		public double[] get_pt_fsk { get => pt_fsk; }
		public double[] get_mt_fsk { get => mt_fsk; }
		public double[] get_zA { get => zA; }
		public double[] get_zF { get => zF; }
		public double[] get_zP { get => zP; }
	}
}

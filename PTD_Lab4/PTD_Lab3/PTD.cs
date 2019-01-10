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
		string bits;
		double[] mt;
		double Tb;
		int N;

		int choice;

		public PTD(string bits, double Tb)
		{
			this.bits = bits;
			this.Tb = Tb;
			N = bits.Length * (int)Tb;

		}

		public string getBits { get => bits; }
		public double getTb { get => Tb; }
		public int getN { get => N; set => N = value; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTD_Lab1
{
	public class PTD
	{

		float f, phi, fs, time;
		int n;
		float[] x;

		public PTD(float f, float phi, float fs, float time, int n)
		{
			this.f = f;
			this.phi = phi;
			this.fs = fs;
			this.time = time;
			this.n = n;
			x = new float[n];

			for (int i = 0; i < n; i++)
			{
				x[i] = xn(this.f, i, this.fs, this.phi);
			}

		}

		float xn(float f, int n, float fs, float phi)
		{
			float wynik = (float)(0.7 * Math.Sin(2 * Math.PI * (double)f * (double)n / (double)fs + (double)phi) * n);
			return wynik; //TODO: change
		}
		public void getXN()
		{
			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(i + 1 + ": " + x[i]);
			}
		}


	}
}

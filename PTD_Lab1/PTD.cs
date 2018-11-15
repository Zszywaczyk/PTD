using System;

namespace PTD_lab1
{
	public class Zad1
	{

		float f, phi, fs, time;
		int n;
		float[] x;

		public Zad1(float f, float phi, float fs, float time, int n)
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
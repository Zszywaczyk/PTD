using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTD_Lab1
{
	public class PTD
	{

		float f, phi, fs, T;
		int N;
		float[] t;
		float[] x;

		float[] y;
		float[] z;
		float[] v;

		float[] u;

		int[] H;
		float[] ga;
		float[] gb;
		float[] gc;

		public PTD(float f, float phi, float fs, float T, int N)
		{
			this.f = f;
			this.phi = phi;
			this.fs = fs;
			this.T = T;
			this.N = N;
			x = new float[N];
			t = new float[N];

			for (int i = 0; i < N; i++)
			{
				x[i] = xn(this.f, i, this.fs, this.phi);
				t[i] = i * (1 / fs);
			}

			zad2();

		}

		public PTD(float T, float fs, int N)
		{
			this.T = T;
			this.fs = fs;
			this.N = N;
			this.t = new float[N];
			this.u = new float[N];

			for (int i = 0; i < N; i++)
			{
				this.t[i] = i * (1 / fs);

				if(this.t[i]>=0 && this.t[i] < 0.2)
				{
					this.u[i] = 0.8f * (float)Math.Sin(20 * (float)Math.PI * this.t[i]);
				}
				else if(this.t[i] >= 0.2 && this.t[i] < 0.4)
				{
					this.u[i] = (float)(Math.Exp(this.t[i] - 0.2) * 0.8 * Math.Sin(20 * Math.PI * this.t[i]));
				}
				else if (this.t[i] >= 0.4 && this.t[i] < 0.6)
				{
					this.u[i] = (float)(0.6 * Math.Sin(10 * Math.PI * this.t[i]));
				}
				else if (this.t[i] >= 0.6 && this.t[i] < 0.8)
				{
					this.u[i] = (float)(Math.Exp(this.t[i] - 0.6) * 0.6 * Math.Sin(10 * Math.PI * this.t[i]));
				}
				else if (this.t[i] >= 0.8 && this.t[i] < 1)
				{
					this.u[i] = (float)(Math.Log((0.7 * this.t[i]), 2) * 0.5 * Math.Sin(40 * Math.PI * this.t[i]));
				}
			}

		}
		public PTD(float T, float fs, int N, int[] H) {
			this.T = T;
			this.fs = fs;
			this.N = N;
			this.H = H;
			this.t = new float[N];
			this.ga = new float[N];

			//a
			double sum=0;
			for (int i = 0; i < N; i++) {
				t[i] = i * (1 / fs);
				for(int n = 1; n <= H[0]; n++)
				{
					sum = sum+ Math.Sin((n * t[i] * Math.PI) / 2) * Math.Sin(20 * n * Math.PI * t[i]);
				}
				this.ga[i] = (float)(9 / Math.Pow(Math.PI, 2) * sum);
					sum = 0;
			}
			//b
			this.gb = new float[N];
			sum = 0;
			for (int i = 0; i < N; i++)
			{
				for (int n = 1; n <= H[1]; n++)
				{
					sum = sum + Math.Sin((n * t[i] * Math.PI) / 2) * Math.Sin(20 * n * Math.PI * t[i]);
				}
				this.gb[i] = (float)(9 / Math.Pow(Math.PI, 2) * sum);
				sum = 0;
			}
			//c
			this.gc = new float[N];
			sum = 0;
			for (int i = 0; i < N; i++)
			{
				for (int n = 1; n <= H[2]; n++)
				{
					sum = sum + Math.Sin((n * t[i] * Math.PI) / 2) * Math.Sin(20 * n * Math.PI * t[i]);
				}
				this.gc[i] = (float)(9 / Math.Pow(Math.PI, 2) * sum);
				sum = 0;
			}

		}

		private void zad2()
		{
			this.y = new float[this.N];
			for(int i = 0; i < this.N; i++)
			{
				this.y[i] = (this.x[i] + 1) / (this.x[i] + 10);
			}
			this.z = new float[this.N];
			for (int i = 0; i < this.N; i++)
			{
				this.z[i] = y[i] * (float)(Math.Pow((double)Math.Abs(x[i]),0.333));
			}
			this.v = new float[this.N];
			for (int i = 0; i < this.N; i++)
			{
				v[i]=(3*x[i])+(y[i]*(Math.Abs(x[i]) + 1.78f));
			}

		}

		float xn(float f, int n, float fs, float phi)
		{
			float wynik = (float)(0.7 * Math.Sin(2 * Math.PI * (double)f * (double)n / (double)fs + (double)phi) * n);
			return wynik;
		}
		public void printXN()
		{
			for (int i = 0; i < N; i++)
			{
				Console.WriteLine(this.t[i] + ": " + this.x[i]);
			}
		}
		public int getN()
		{
			return this.N;
		}
		public float getXN(int i)
		{
			return this.x[i];
		}
		public float getYN(int i)
		{
			return this.y[i];
		}
		public float getZN(int i)
		{
			return this.z[i];
		}
		public float getVN(int i)
		{
			return this.v[i];
		}
		public float getUN(int i)
		{
			return this.u[i];
		}
		public float getGA(int i)
		{
			return this.ga[i];
		}
		public float getGB(int i)
		{
			return this.gb[i];
		}
		public float getGC(int i)
		{
			return this.gc[i];
		}
		public float getSmall_t(int i)
		{
			return this.t[i];
		}
		public float[] getX()
		{
			return this.x;
		}
		public float getBig_T()
		{
			return this.T;
		}
		public void saveXNToFile()
		{
			string createText;
			createText = this.N.ToString() + Environment.NewLine;
			for (int i = 0; i < N; i++)
			{
				createText += i+" "+this.x[i] + Environment.NewLine;
			}
			File.WriteAllText("../../../../PTD_Lab2/xn.txt", createText);
		}

	}
}

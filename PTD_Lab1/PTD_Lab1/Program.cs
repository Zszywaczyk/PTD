using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PTD_Lab1
{

	

	public partial class Program : Form
	{
		static void Main(string[] args)
		{
			//Console operations
			float f = 4;
			float phi = (float)((7 * Math.PI)/9);
			float fs = 100;
			float time = 1;
			int n = 100;
			PTD zad1 = new PTD(f, phi, fs, time, n);
			zad1.getXN();
			//========

			//Run Graphic
			Application.Run(new Program());
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Program
			// 
			this.ClientSize = new System.Drawing.Size(752, 472);
			this.Name = "Program";
			this.ResumeLayout(false);

		}
	}

}

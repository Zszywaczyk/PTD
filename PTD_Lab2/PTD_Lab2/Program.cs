using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTD_Lab2
{
	public partial class Program : Form
	{
		static void Main(string[] args)
		{
			//wczytanie danych xn
			string readText = File.ReadAllText("../../../xn.txt");
			Console.Write(readText[2]);

			Application.Run(new Program());
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Program
			// 
			this.ClientSize = new System.Drawing.Size(549, 351);
			this.Name = "Program";
			this.ResumeLayout(false);

		}
		public Program()
		{
			InitializeComponent();
		}
	}



	}

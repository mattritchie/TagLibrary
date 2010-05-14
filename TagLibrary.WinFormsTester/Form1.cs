using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tagLibrary;

namespace TagLibrary.WinFormsTester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			FillDataGrid();
			
		}

		private void FillDataGrid()
		{

			var dd = Stuff.GetContentsOfXmlFile()
							.Select(
								d =>
									new
									{
										Artist = d.AlbumArtists.FirstOrDefault(),
										d.AlbumTitle,
										d.Track,
										d.Name,
										d.FileName,
										d.Year
									}

									)
							.ToList();



			dataGridView1.DataSource = dd;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Stuff.DoLotsOfStuff();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FillDataGrid();
		}
	}
}

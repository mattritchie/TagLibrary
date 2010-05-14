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

			var dd = Stuff.GetContentsOfXmlFile()
							.Select(
							d =>
								new
									{
										//Artist = d.AlbumArtists.FirstOrDefault(),
										d.AlbumTitle,
										d.FileName,
										d.Name,
										d.Track,
										d.Year
									}

									);



			dataGridView1.DataSource = dd;
			
		}
	}
}

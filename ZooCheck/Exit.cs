﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooCheck
{
	public partial class Exit : Form
	{
		public Exit()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

    }
}

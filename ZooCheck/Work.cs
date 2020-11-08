using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooCheck
{
    public partial class Work : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";
        public Work()
        {
            InitializeComponent();
        }
        Point lastpoint;
        private void Work_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Work_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string add = $"INSERT INTO Logs VALUES(N'{textBox1.Text}',N'{textBox2.Text}',N'{textBox3.Text}')";
            cmd = new SqlCommand(add, connection);
            reader = cmd.ExecuteReader();
            this.DialogResult = DialogResult.OK;
            connection.Close();
            this.Close();
        }

		private void close_button_Click(object sender, EventArgs e)
		{
            Exit f = new Exit();
            f.ShowDialog();
        }

		private void pictureBox2_Click(object sender, EventArgs e)
		{
            WindowState = FormWindowState.Minimized;
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
	}
}

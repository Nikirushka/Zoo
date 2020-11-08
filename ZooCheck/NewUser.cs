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
    public partial class NewUser : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";
        public NewUser()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password mismatch", "Error");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string check = $"SELECT * FROM Users where Login=N'{textBox1.Text}' AND Password=N'{textBox2.Text}'";
                cmd = new SqlCommand(check, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    MessageBox.Show("Such user exists", "Error");
                    return;
                }
                else
                {
                    reader.Close();
                    string add = $"INSERT INTO Users VALUES(N'{textBox1.Text}',N'{textBox2.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}','{textBox8.Text}')";
                    cmd = new SqlCommand(add, connection);
                    reader = cmd.ExecuteReader();
                    
                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
            }
            connection.Close();
        }

		private void close_button_Click_1(object sender, EventArgs e)
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
        Point lastpoint;

        private void NewUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void NewUser_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}

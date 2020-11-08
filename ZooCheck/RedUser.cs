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
    public partial class RedUser : Form
    {
        string Login, Password, Access, Sex, Old, ZP, Stag,ID;

        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";

        private void RedUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        Point lastpoint;

        private void RedUser_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password mismatch", "Error");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string editQuery = $"UPDATE Users SET [Login] = N'{textBox1.Text}' , [Password] = N'{textBox2.Text}',[Access]=N'{textBox4.Text}',[Пол]=N'{textBox5.Text}',[Возраст]=N'{textBox6.Text}',[ЗП]=N'{textBox7.Text}',[Стаж работы]=N'{textBox8.Text}' WHERE Id = '{ID}'";

                cmd = new SqlCommand(editQuery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            connection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
		{
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

		private void pictureBox2_Click(object sender, EventArgs e)
		{
            WindowState = FormWindowState.Minimized;
        }

		private void close_button_Click(object sender, EventArgs e)
		{
            Exit f = new Exit();
            f.ShowDialog();
        }

		public RedUser()
        {
            InitializeComponent();
        }
        public RedUser(string x,string a, string b, string c, string d, string e, string f, string g)
        {
            InitializeComponent();
            ID = x;
            Login = a;
            Password = b;
            Access = c;
            Sex = d;
            Old = e;
            ZP = f;
            Stag = g;
        }

        private void RedUser_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login;
            textBox2.Text = Password;
            textBox3.Text = Password;
            textBox4.Text = Access;
            textBox5.Text = Sex;
            textBox6.Text = Old;
            textBox7.Text = ZP;
            textBox8.Text = Stag;
        }
    }
}

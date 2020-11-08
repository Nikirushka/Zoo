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
    
    public partial class RedAnimal : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";

        public RedAnimal()
        {
            InitializeComponent();
        }
        string ID;
        public RedAnimal(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string k, string l, string m)
        {
            InitializeComponent();
            ID = a;
            textBox1.Text = b;
            textBox2.Text = c;
            textBox3.Text = d;
            textBox4.Text = e;
            textBox5.Text = f;
            textBox6.Text = g;
            textBox12.Text = h;
            textBox11.Text = i;
            textBox10.Text = j;
            textBox9.Text = k;
            textBox8.Text = l;
            textBox7.Text = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string editQuery = $"UPDATE Animals SET [Животное] = N'{textBox1.Text}' , [Кличка] = N'{textBox2.Text}',[Вид]=N'{textBox3.Text}',[Корм]=N'{textBox4.Text}',[Помещение]=N'{textBox5.Text}',[Время проживания]=N'{textBox6.Text}',[Рост]=N'{textBox12.Text}',[Обмен]=N'{textBox7.Text}',[Вес]=N'{textBox11.Text}',[Возраст]=N'{textBox10.Text}',[Прививка]=N'{textBox9.Text}',[Потомство]=N'{textBox8.Text}' WHERE Id = '{ID}'";

            cmd = new SqlCommand(editQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
		private void pictureBox1_Click(object sender, EventArgs e)
		{
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
	}
}

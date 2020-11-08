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
    public partial class Korm : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";

        public Korm()
        {
            InitializeComponent();
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
        Point lastpoint;

        private void close_button_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void close_button_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Korm_Load(object sender, EventArgs e)
        {
            button4.Hide();
            ConnectBD1();
            panel1.Hide();
        }
        public void ConnectBD1()
        {
            dataGridView1.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Korm]";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView1.Rows.Add();

                    dataGridView1.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView1.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView1.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView1.Rows[rows].Cells[3].Value = reader[3];
                    dataGridView1.Rows[rows].Cells[4].Value = reader[4];
                }
            }
            reader.Close();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, index].Value);

            string delQuery = $"DELETE FROM Korm WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            ConnectBD1();
            connection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string add = $"INSERT INTO Korm VALUES(N'{textBox1.Text}',N'{textBox2.Text}',N'{textBox3.Text}',N'{textBox4.Text}')";
            cmd = new SqlCommand(add, connection);
            reader = cmd.ExecuteReader();
            connection.Close();
            ConnectBD1();
            panel1.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1.Show();
            panel1.Show();
            button4.Hide();
        }

        private void Korm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Korm_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string log, pas, acc, sex;
            if (textBox14.Text == "Поставщик") log = "";
            else log = textBox14.Text;
            if (textBox13.Text == "Корм") pas = "";
            else pas = textBox13.Text;
            if (textBox12.Text == "Объём") acc = "";
            else acc = textBox12.Text;
            if (textBox11.Text == "Дата") sex = "";
            else sex = textBox11.Text;

            dataGridView1.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Korm] where [Поставщик] like '%{log}%' and [Корм] like '%{pas}%' and [Объём] like '%{acc}%' and [Дата] like N'%{sex}%'";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView1.Rows.Add();

                    dataGridView1.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView1.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView1.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView1.Rows[rows].Cells[3].Value = reader[3];
                    dataGridView1.Rows[rows].Cells[4].Value = reader[4];
                }
            }
            reader.Close();
            connection.Close();
        }
        string IDD;
        private void button3_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
           IDD = Convert.ToString(dataGridView1[0, index].Value);
            string ID = Convert.ToString(dataGridView1[1, index].Value);
            string jiv = Convert.ToString(dataGridView1[2, index].Value);
            string kli4 = Convert.ToString(dataGridView1[3, index].Value);
            string vid = Convert.ToString(dataGridView1[4, index].Value);
            button1.Hide();
            panel1.Show();
            button4.Show();
            textBox1.Text = ID;
            textBox2.Text = jiv;
            textBox3.Text = kli4;
            textBox4.Text = vid;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string editQuery = $"UPDATE Korm SET [Поставщик] = N'{textBox1.Text}' , [Корм] = N'{textBox2.Text}',[Объём]=N'{textBox3.Text}',[Дата]=N'{textBox4.Text}'  WHERE Id = '{IDD}'";

            cmd = new SqlCommand(editQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            ConnectBD1();
            panel1.Hide();
        }
    }
}

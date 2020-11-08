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
    public partial class ForTrainer : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string name;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";
        public ForTrainer()
        {
            InitializeComponent();
        }
        public ForTrainer(string a)
        {
            InitializeComponent();
            name = a;
        }

        private void ForTrainer_Load(object sender, EventArgs e)
        {
            label1.Text = $"Профиль : {name}";
            ConnectBD2();
        }
        public void ConnectBD2()
        {

            dataGridView2.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Animals]";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView2.Rows.Add();

                    dataGridView2.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView2.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView2.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView2.Rows[rows].Cells[3].Value = reader[3];
                    dataGridView2.Rows[rows].Cells[4].Value = reader[4];
                    dataGridView2.Rows[rows].Cells[5].Value = reader[5];
                    dataGridView2.Rows[rows].Cells[6].Value = reader[6];
                    dataGridView2.Rows[rows].Cells[7].Value = reader[7];
                    dataGridView2.Rows[rows].Cells[8].Value = reader[8];
                    dataGridView2.Rows[rows].Cells[9].Value = reader[9];
                    dataGridView2.Rows[rows].Cells[10].Value = reader[10];
                    dataGridView2.Rows[rows].Cells[11].Value = reader[11];
                    dataGridView2.Rows[rows].Cells[12].Value = reader[12];
                }
            }
            reader.Close();
            connection.Close();
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{
            Exit f = new Exit();
            f.ShowDialog();
        }

		private void pictureBox2_Click(object sender, EventArgs e)
		{
            WindowState = FormWindowState.Minimized;
        }

		private void pictureBox3_Click(object sender, EventArgs e)
		{
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Work work = new Work();
            DialogResult dialogResult = new DialogResult();
            dialogResult = work.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }
	}
}

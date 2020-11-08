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
    public partial class ForBuilder : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string name;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";
        public ForBuilder()
        {
            InitializeComponent();
        }
        public ForBuilder(string a)
        {
            InitializeComponent();
            name = a;
        }
        private void ForBuilder_Load(object sender, EventArgs e)
        {
            label1.Text = $"Профиль : {name}";
            ConnectBD1();
        }
        public void ConnectBD1()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Houses]";
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
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void close_button_MouseEnter(object sender, EventArgs e)
		{
            close_button.ForeColor = Color.White;
        }

		private void close_button_MouseLeave(object sender, EventArgs e)
		{
            close_button.ForeColor = Color.Black;
        }

		private void pictureBox1_Click(object sender, EventArgs e)
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

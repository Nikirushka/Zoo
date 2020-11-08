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
    public partial class LogIN : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string name, surname, phone, email;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";

        public LogIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string LoginTB, PasswordTB;
            LoginTB = textBox1.Text;
            PasswordTB = textBox2.Text;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT * FROM [Users] WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS)";
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong Login", "Error");
                reader.Close();
                return;
            }
            else
            {
                reader.Close();
                query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) ";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    MessageBox.Show("Wrong Password", "Error");
                    return;
                }
                else
                {
                    this.Hide();
                    reader.Close();
                    query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=13";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        Admin mainMenuForAdmin = new Admin(LoginTB);
                        DialogResult dialogResult = new DialogResult();
                        dialogResult = mainMenuForAdmin.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Show();
                        }
                        else
                        {
                            connection.Close();
                            this.Close();
                        }

                    }
                    else
                    {
                        reader.Close();
                        query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=1";
                        cmd = new SqlCommand(query, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Close();
                            ForVet forVet = new ForVet(LoginTB);
                            DialogResult dialogResult = new DialogResult();
                            dialogResult = forVet.ShowDialog();
                            if (dialogResult == DialogResult.OK)
                            {
                                this.Show();
                            }
                            else
                            {
                                connection.Close();
                                this.Close();
                            }
                        }
                        else
                        {
                            reader.Close();
                            query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=2";
                            cmd = new SqlCommand(query, connection);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Close();
                                ForCleaner forCleaner = new ForCleaner(LoginTB);
                                DialogResult dialogResult = new DialogResult();
                                dialogResult = forCleaner.ShowDialog();
                                if (dialogResult == DialogResult.OK)
                                {
                                    this.Show();
                                }
                                else
                                {
                                    connection.Close();
                                    this.Close();
                                }
                            }
                            else
                            {
                                reader.Close();
                                query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=3";
                                cmd = new SqlCommand(query, connection);
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    reader.Close();
                                    ForTrainer forTrainer = new ForTrainer(LoginTB);
                                    DialogResult dialogResult = new DialogResult();
                                    dialogResult = forTrainer.ShowDialog();
                                    if (dialogResult == DialogResult.OK)
                                    {
                                        this.Show();
                                    }
                                    else
                                    {
                                        connection.Close();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    reader.Close();
                                    query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=4";
                                    cmd = new SqlCommand(query, connection);
                                    reader = cmd.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        reader.Close();
                                        ForBuilder forBuilder = new ForBuilder(LoginTB);
                                        DialogResult dialogResult = new DialogResult();
                                        dialogResult = forBuilder.ShowDialog();
                                        if (dialogResult == DialogResult.OK)
                                        {
                                            this.Show();
                                        }
                                        else
                                        {
                                            connection.Close();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        MessageBox.Show("Wrong User access\nUse admin panel", "Error");
                                        return;
                                    }
                                }
                            }
                        }
             
                    }

                }

            }
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

		private void close_button_MouseLeave(object sender, EventArgs e)
		{
            close_button.ForeColor = Color.Black;
        }

		private void close_button_MouseEnter(object sender, EventArgs e)
		{
            close_button.ForeColor = Color.White;
        }

        Point lastpoint;
        private void LogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}

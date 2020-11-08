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
    public partial class Admin : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string name;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|ZooDB.mdf';Integrated Security=True;Connect Timeout=30";

        public Admin()
        {
            InitializeComponent();
        }

        public Admin(string a)
        {
            InitializeComponent();
            
            name = a;
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, index].Value);

            string delQuery = $"DELETE FROM [Users] WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            ConnectBD1();
            ConnectBD2();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ConnectBD3();
            button2.Hide(); button3.Hide(); button9.Hide();
            label1.Text = $"Профиль : {name}";
            ConnectBD1();
             textBox10.Hide(); textBox12.Hide(); textBox14.Hide(); textBox16.Hide(); textBox18.Hide(); textBox20.Hide();
            textBox9.Hide(); textBox11.Hide(); textBox13.Hide();  textBox17.Hide(); textBox19.Hide(); textBox21.Hide();
            ConnectBD2();
        }
        public void ConnectBD1()
        {
            dataGridView1.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Users]";
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
                    dataGridView1.Rows[rows].Cells[5].Value = reader[5];
                    dataGridView1.Rows[rows].Cells[6].Value = reader[6];
                    dataGridView1.Rows[rows].Cells[7].Value = reader[7];
                }
            }
            reader.Close();
            connection.Close();
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
        public void ConnectBD3()
        {
            dataGridView3.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Logs]";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView3.Rows.Add();

                    dataGridView3.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView3.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView3.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView3.Rows[rows].Cells[3].Value = reader[3];
                }
            }
            reader.Close();
            connection.Close();
        }
        private void close_button_MouseEnter(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.DarkGreen;
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            close_button.ForeColor = Color.White;
        }

        Point lastpoint;
        private void Admin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        private void Admin_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string Login = Convert.ToString(dataGridView1[1, index].Value);
            string Password = Convert.ToString(dataGridView1[2, index].Value);
            string Access = Convert.ToString(dataGridView1[3, index].Value);
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT * FROM [Users] WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS)";
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
                query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) ";
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
                    query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) AND Access=13";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        Admin mainMenuForAdmin = new Admin(Login);
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
                        query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) AND Access={Access}";
                        cmd = new SqlCommand(query, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows && Convert.ToInt32(Access) == 1)
                        {
                            reader.Close();
                            ForVet forVet = new ForVet(Login);
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
                            query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) AND Access={Access}";
                            cmd = new SqlCommand(query, connection);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows && Convert.ToInt32(Access) == 2)
                            {
                                reader.Close();
                                ForCleaner forCleaner = new ForCleaner(Login);
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
                                query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) AND Access={Access}";
                                cmd = new SqlCommand(query, connection);
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows && Convert.ToInt32(Access) == 3)
                                {
                                    reader.Close();
                                    ForTrainer forTrainer = new ForTrainer(Login);
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
                                    query = $"SELECT * FROM Users WHERE (Login=N'{Login}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{Password}' COLLATE CYRILLIC_General_CS_AS) AND Access={Access}";
                                    cmd = new SqlCommand(query, connection);
                                    reader = cmd.ExecuteReader();
                                    if (reader.HasRows && Convert.ToInt32(Access) == 4)
                                    {
                                        reader.Close();
                                        ForBuilder forBuilder = new ForBuilder(Login);
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

		private void button8_Click(object sender, EventArgs e)
		{
            dataGridView3.Hide();
            ConnectBD2();
            dataGridView1.Hide();
            dataGridView2.Show();
            textBox10.Show(); textBox12.Show(); textBox14.Show(); textBox16.Show(); textBox18.Show(); textBox20.Show();
            textBox9.Show(); textBox11.Show(); textBox13.Show();  textBox17.Show(); textBox19.Show(); textBox21.Show();
            textBox1.Hide(); textBox3.Hide(); textBox4.Hide(); textBox5.Hide(); textBox6.Hide(); textBox7.Hide(); textBox2.Hide();
            button4.Hide(); button5.Hide(); button6.Hide(); button7.Hide();
            button2.Show();button3.Show();button9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewUser newUser = new NewUser();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newUser.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                ConnectBD1();
                this.Show();
            }
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string log, pas, acc, sex, old, zp, stag;
            if (textBox1.Text == "Login") log = "";
            else log = textBox1.Text;
            if (textBox2.Text == "Password") pas = "";
            else pas = textBox2.Text;
            if (textBox3.Text == "Access") acc = "";
            else acc = textBox3.Text;
            if (textBox4.Text == "Пол") sex = "";
            else sex = textBox4.Text;
            if (textBox5.Text == "Возраст") old = "";
            else old = textBox5.Text;
            if (textBox6.Text == "Зп") zp = "";
            else zp = textBox6.Text;
            if (textBox7.Text == "Стаж работы") stag= "";
            else stag = textBox7.Text;

            dataGridView1.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Users] where Login like '%{log}%' and Password like '%{pas}%' and Access like '%{acc}%' and [Пол] like N'%{sex}%' and Возраст like '%{old}%'and ЗП like '%{zp}%' and [Стаж работы] like '%{stag}%'";
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
                    dataGridView1.Rows[rows].Cells[5].Value = reader[5];
                    dataGridView1.Rows[rows].Cells[6].Value = reader[6];
                    dataGridView1.Rows[rows].Cells[7].Value = reader[7];
                }
            }
            reader.Close();

            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string ID = Convert.ToString(dataGridView1[0, index].Value);
            string Login = Convert.ToString(dataGridView1[1, index].Value);
            string Password = Convert.ToString(dataGridView1[2, index].Value);
            string Access = Convert.ToString(dataGridView1[3, index].Value);
            string Sex = Convert.ToString(dataGridView1[4, index].Value);
            string Old = Convert.ToString(dataGridView1[5, index].Value);
            string Zp = Convert.ToString(dataGridView1[6, index].Value);
            string Stag = Convert.ToString(dataGridView1[7, index].Value);
            RedUser redUser = new RedUser(ID, Login, Password, Access, Sex, Old, Zp, Stag);
            DialogResult dialogResult = new DialogResult();
            dialogResult = redUser.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                ConnectBD1();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Hide();
            dataGridView2.Hide();
            dataGridView1.Show();
            textBox1.Show(); textBox3.Show(); textBox4.Show(); textBox5.Show(); textBox6.Show(); textBox7.Show(); textBox2.Show();
            textBox10.Hide(); textBox12.Hide(); textBox14.Hide(); textBox16.Hide(); textBox18.Hide(); textBox20.Hide();
            textBox9.Hide(); textBox11.Hide(); textBox13.Hide(); textBox17.Hide(); textBox19.Hide(); textBox21.Hide();
            button2.Hide(); button3.Hide(); button9.Hide();
            button4.Show();button5.Show(); button6.Show();button7.Show();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string jiv,kli4,vid,korm,pom,time,rost,ves,old,priv,potom,trade;
            if (textBox14.Text == "Животное") jiv = null;
            else jiv = textBox14.Text;
            if (textBox13.Text == "Кличка") kli4 = null;
            else kli4 = textBox13.Text;
            if (textBox12.Text == "Вид") vid = null;
            else vid = textBox12.Text;
            if (textBox11.Text == "Корм") korm = null;
            else korm = textBox11.Text;
            if (textBox10.Text == "Помещение") pom = null;
            else pom = textBox10.Text;
            if (textBox9.Text == "Время") time = null;
            else time = textBox9.Text;
            if (textBox21.Text == "Рост") rost = null;
            else rost = textBox21.Text;
            if (textBox20.Text == "Вес") ves = null;
            else ves = textBox20.Text;
            if (textBox19.Text == "Возраст") old = null;
            else old = textBox19.Text;
            if (textBox16.Text == "Обмен") trade = null;
            else trade = textBox16.Text;
            if (textBox18.Text == "Прививка") priv = null;
            else priv = textBox18.Text;
            if (textBox17.Text == "Потомство") potom = null;
            else potom = textBox17.Text;

            dataGridView2.Rows.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Animals] where [Животное] like N'%{jiv}%' and [Кличка] like N'%{kli4}%' and Вид like N'%{vid}%' and [Корм] like N'%{korm}%' and Помещение like N'%{pom}%'and [Время проживания] like N'%{time}%' and [Рост] like N'%{rost}%' and [Вес] like N'%{ves}%' and [Возраст] like N'%{old}%' and [Прививка] like N'%{priv}%' and [Потомство] like N'%{potom}%' and [Обмен] like N'%{trade}%'";
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

        private void textBox14_Click(object sender, EventArgs e)
        {
            textBox14.Clear();
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
        }

        private void textBox21_Click(object sender, EventArgs e)
        {
            textBox21.Clear();
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            textBox20.Clear();
        }

        private void textBox19_Click(object sender, EventArgs e)
        {
            textBox19.Clear();
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            textBox18.Clear();
        }

        private void textBox17_Click(object sender, EventArgs e)
        {
            textBox17.Clear();
        }

        private void textBox16_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewAnimal newAnimal = new NewAnimal();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newAnimal.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView2.Rows.Clear();
                ConnectBD2();
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView2[0, index].Value);

            string delQuery = $"DELETE FROM [Animals] WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView2.Rows.Clear();
            ConnectBD1();
            ConnectBD2();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string ID = Convert.ToString(dataGridView2[0, index].Value);
            string jiv = Convert.ToString(dataGridView2[1, index].Value);
            string kli4 = Convert.ToString(dataGridView2[2, index].Value);
            string vid = Convert.ToString(dataGridView2[3, index].Value);
            string korm = Convert.ToString(dataGridView2[4, index].Value);
            string pom = Convert.ToString(dataGridView2[5, index].Value);
            string time = Convert.ToString(dataGridView2[6, index].Value);
            string rost = Convert.ToString(dataGridView2[7, index].Value);
            string ves = Convert.ToString(dataGridView2[8, index].Value);
            string old = Convert.ToString(dataGridView2[9, index].Value);
            string priv = Convert.ToString(dataGridView2[10, index].Value);
            string potom = Convert.ToString(dataGridView2[11, index].Value);
            string trade = Convert.ToString(dataGridView2[12, index].Value);
            RedAnimal redAnimal= new RedAnimal(ID,jiv,kli4,vid,korm,pom,time,rost,ves,old,priv,potom,trade);
            DialogResult dialogResult = new DialogResult();
            dialogResult = redAnimal.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView2.Rows.Clear();
                ConnectBD2();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView3.Show(); dataGridView2.Hide(); dataGridView1.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Korm korm = new Korm();
            DialogResult dialogResult = new DialogResult();
            dialogResult = korm.ShowDialog();
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
    }
}

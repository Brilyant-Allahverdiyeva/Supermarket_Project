using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectOOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3EAMENA;Initial Catalog=Supermarket;Integrated Security=True");

        private void ViewData()
        {
            listView1.Items.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand("Select *From Data", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem enter = new ListViewItem();
                enter.Text = reader["ID"].ToString();
                enter.SubItems.Add(reader["Name"].ToString());
                enter.SubItems.Add(reader["Price"].ToString());
                enter.SubItems.Add(reader["Unit"].ToString());
                enter.SubItems.Add(reader["Type"].ToString());
                enter.SubItems.Add(reader["ExpirationDate"].ToString());

                listView1.Items.Add(enter);
            }
            connection.Close();
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            ViewData();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Data (ID,Name,Price,Unit,Type,ExpirationDate) values ('"+textBox7.Text.ToString()+ "','" + textBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() +"')",connection);
            command.ExecuteNonQuery();
            connection.Close();
            ViewData();
            textBox7.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox4.Clear();
            comboBox1.Text=string.Empty;
            textBox2.Clear();
            MessageBox.Show("SAVED");
        }
        int ID = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From Data where ID =(" + ID + ")", connection);
            command.ExecuteNonQuery();
            connection.Close();
            ViewData();
            textBox7.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox4.Clear();
            comboBox1.Text = string.Empty;
            textBox2.Clear();
            MessageBox.Show("DELETED");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID=int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(" update Data set ID='" + textBox7.Text.ToString() + "',Name='"+textBox1.Text.ToString()+"',Price='"+textBox5.Text.ToString()+"',Unit='"+textBox4.Text.ToString()+"',Type='"+comboBox1.Text.ToString()+"',ExpirationDate='"+textBox2.Text.ToString()+"' where ID=" + ID + "", connection);
            command.ExecuteNonQuery();
            connection.Close();
            ViewData();
            textBox7.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox4.Clear();
            comboBox1.Text = string.Empty;
            textBox2.Clear();
            MessageBox.Show("UPDATED");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand("Select *From Data where ID like '%"+textBox6.Text+ "%' or Name like '%" + textBox6.Text + "%' or Price like '%" + textBox6.Text + "%'or Unit like '%" + textBox6.Text + "%' or Type like '%" + textBox6.Text + "%' or ExpirationDate like '%" + textBox6.Text + "%'", connection);
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem enter = new ListViewItem();
                enter.Text = reader["ID"].ToString();
                enter.SubItems.Add(reader["Name"].ToString());
                enter.SubItems.Add(reader["Price"].ToString());
                enter.SubItems.Add(reader["Unit"].ToString());
                enter.SubItems.Add(reader["Type"].ToString());
                enter.SubItems.Add(reader["ExpirationDate"].ToString());

                listView1.Items.Add(enter);
            }
            connection.Close();
        }
    }
 }


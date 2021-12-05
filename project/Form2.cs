using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public SqlConnection connection;
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public SqlDataReader dataReader;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            lblScrollValue.Text = hScrollBar1.Value.ToString();

            connection.Open();

            string sql = "SELECT * FROM Records WHERE PartMark = '" + hScrollBar1.Value.ToString() + "'   ";
            cmd = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Records");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Records";
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\matom\Desktop\project\project\Students.mdf;Integrated Security=True";

            connection = new SqlConnection(connectionString);
            txtSurname.Focus();
            hScrollBar1.Value = 0;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = 100;
            hScrollBar1.SmallChange = 1;
            hScrollBar1.LargeChange = 5;

            
            cbModule.Items.Add("Physics ");
            cbModule.Items.Add("Maths ");
            cbModule.Items.Add("Chemistry ");
            cbModule.Items.Add("Economics ");
            cbModule.Items.Add("Business ");
            cbModule.Items.Add("Accounting ");

            connection.Open();

            

            string sql;
            sql = "SELECT * FROM Records ";
            cmd = new SqlCommand(sql, connection);

            DataSet ds = new DataSet();

            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Records");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Records";
            connection.Close();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            connection.Open();

            string sql = "SELECT * FROM Records WHERE Surname Like '%" +txtSurname.Text+ "%'   ";
            cmd = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Records");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Records";
            connection.Close();

        }

        private void cbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();

            string sql = "SELECT * FROM Records WHERE Module = '" + cbModule.SelectedItem.ToString()+"'   ";
            cmd = new SqlCommand(sql , connection);
            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Records");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Records";
            connection.Close();
        }
    }
}

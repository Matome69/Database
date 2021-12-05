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

    public partial class Form1 : Form
    {
        public SqlConnection connection;
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public SqlDataReader dataReader;


        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\matom\Desktop\project\project\Students.mdf;Integrated Security=True";

            connection = new SqlConnection(connectionString);

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

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frmSearch = new Form2();
            frmSearch.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frmInsert = new Form4();
            
            frmInsert.ShowDialog();
            //this.Close();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frmDelete = new Form3();
            frmDelete.ShowDialog();
            this.Close();
        }
    }
}

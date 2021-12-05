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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();

            SqlConnection connection;
            SqlCommand cmd;
             
            SqlDataAdapter adapter;
            

            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\matom\Desktop\project\project\Students.mdf;Integrated Security=True";

            connection = new SqlConnection(connectionString);

            connection.Open();

            string sql;
            sql = "DELETE FROM Records WHERE Name = '" + txtDelete.Text + "'";
            cmd = new SqlCommand(sql , connection);
            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            //adapter.SelectCommand = cmd;
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();
            MessageBox.Show("Student record deleted");
            connection.Close();

            string select = "SELECT * FROM Records";
            connection.Open();
            cmd = new SqlCommand(select, connection);
            ds = new DataSet();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Records");
            main.dataGridView1.DataSource = ds;
            main.dataGridView1.DataMember = "Records";
            connection.Close();

            //this.Close();
            //main.ShowDialog();


        }
    }
}

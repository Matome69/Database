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
    public partial class Form4 : Form
    {
        public SqlConnection connection;
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public DataSet ds;
        

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cbModules.Items.Add("Physics ");
            cbModules.Items.Add("Maths ");
            cbModules.Items.Add("Chemistry ");
            cbModules.Items.Add("Economics ");
            cbModules.Items.Add("Business ");
            cbModules.Items.Add("Accounting ");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\matom\Desktop\project\project\Students.mdf;Integrated Security=True";

            connection = new SqlConnection(connectionString);
            connection.Open();
            string sql;
            sql = "INSERT INTO Records(StudentNo,Surname,Name,Module,PartMark,ExamMark) VALUES('"+txtStudent.Text+"' ,'"+txtSurname.Text+ "', '"+txtName.Text+"', '"+cbModules.SelectedItem+"', '"+txtPart.Text+"','"+txtExam.Text+"')";
            cmd = new SqlCommand(sql , connection);
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

           
   
            cmd.Dispose();
            connection.Close();
            MessageBox.Show("Student Record inserted");

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

            this.Close();
            main.ShowDialog();
            
        }


    }
}

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
using System.Data;

namespace ADONET
{
    public partial class Form1 : Form
    {
        string connStr = "Server=INSTRUCTORIT; Database=IBTCollege; User Id=ProfileUser; Password=ProfileUser2019";
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string testConn = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(testConn, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int total = 0;

                while (reader.Read())
                {
                    string fullName = reader["firstName"] + " " + reader["lastName"];
                    lstStudents.Items.Add(fullName);
                    total++;
                }

                lblInfo.Text = String.Format("{0} Records found", total);
            }            
        }

        private void RefreshData()
        {
            var select = "SELECT * FROM Students";
            var c = new SqlConnection(connStr); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvStudents.ReadOnly = true;
            dgvStudents.DataSource = ds.Tables[0];
        }

        private void AddRecord()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string addRecord = String.Format("INSERT INTO Students (firstName, lastName, ID) " +
                    "VALUES ('{0}', '{1}', {2})", txtFirstName.Text, txtLastName.Text, txtID.Text);
                SqlCommand cmd = new SqlCommand(addRecord, conn);
                int rowsAffected = cmd.ExecuteNonQuery();
                lblResult.Text = String.Format("{0}, {1}, Added into the database.", txtFirstName.Text, txtLastName.Text);
            }
            txtFirstName.Clear();
            txtLastName.Clear();
            txtID.Clear();                
        }

        private void EditRecord()
        {

        }

        private void DeleteRecord()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string deleteRecord = String.Format("DELETE FROM Students WHERE firstName='{0}' OR lastName='{1}' OR ID={2}", txtFirstName.Text, txtLastName.Text, txtID.Text);
                SqlCommand cmd = new SqlCommand(deleteRecord, conn);
                int rowsAffected = cmd.ExecuteNonQuery();                
                lblResult.Text = String.Format("{0} Records deleted.", rowsAffected);
            }
            txtFirstName.Clear();
            txtLastName.Clear();
            txtID.Clear();
        }

        private void SearchRecord()
        {
            lstStudents.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string SearchConn = String.Format("SELECT * FROM Students " +
                    "WHERE firstName='{0}' OR lastName='{1}' OR ID={2}", txtFirstName.Text, txtLastName.Text, txtID.Text);
                SqlCommand cmd = new SqlCommand(SearchConn, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int rowsAffected = 0;                

                while (reader.Read())
                {
                    string fullName = reader["firstName"] + " " + reader["lastName"];
                    lstStudents.Items.Add(fullName);
                    rowsAffected++;
                }
                lblResult.Text = String.Format("{0} Records found.", rowsAffected);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchRecord();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }
    }
}

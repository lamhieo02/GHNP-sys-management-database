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

namespace LanguageCenter.GUI.childForms
{
    public partial class StaffManage : Form
    {
        public StaffManage()
        {
            InitializeComponent();
        }

        private void DisplayStaffList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Staff_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            staffGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            staffGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            staffGridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayStaffList();
        }

        private void AddStaff(string username, string name, string dateofbirth, string address, string email, string phone, string position)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("AddStaff", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            da.SelectCommand.Parameters.Add("@position", SqlDbType.VarChar, 20).Value = position;
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxUsername.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(comboBox2.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    AddStaff(txtBoxUsername.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text, comboBox2.Text);
                    MessageBox.Show("Add data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayStaffList();
                
                }
                catch (Exception)
                {
                    MessageBox.Show("Add failed! Please double check the data!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateStaff(string username, string name, string dateofbirth, string address, string email, string phone, string position)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("UpdateStaff", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            da.SelectCommand.Parameters.Add("@position", SqlDbType.VarChar, 20).Value = position;
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxUsername.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(comboBox2.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    UpdateStaff(txtBoxUsername.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text, comboBox2.Text);
                    MessageBox.Show("Update data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayStaffList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Update failed! Please double check the data!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteStaff(string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deleteACCOUNT_STAFF_sequently", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxUsername.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    DeleteStaff(txtBoxUsername.Text);
                    MessageBox.Show("Delete data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayStaffList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Delete failed! Please double check the data!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void staffGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.staffGridview.Rows[e.RowIndex];
                txtBoxUsername.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
                comboBox2.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
            }
        }

        private void GetStaffByStaffName(string staffname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStaffByStaffName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = staffname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void GetStaffByPosition(string position)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStaffByPosition", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = position;
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //staff name
            {
                GetStaffByStaffName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) //position
            {
                GetStaffByPosition(textBox1.Text);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            txtBoxUsername.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            DisplayStaffList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Staff_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffGridview.DataSource = dt;
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{6}%' or [{1}] LIKE '%{6}%' or [{2}] LIKE '%{6}%' " +
                "or [{3}] LIKE '%{6}%' or [{4}] LIKE '%{6}%' or [{5}] LIKE '%{6}%' or Convert([{7}],'System.String') LIKE '%{6}%' or [{8}] LIKE '%{6}%'", "Username", "StaffName",
                "DateOfBirth", "Address", "Email", "Phone", textBox1.Text, "Salary", "Position");
        }
    }
}

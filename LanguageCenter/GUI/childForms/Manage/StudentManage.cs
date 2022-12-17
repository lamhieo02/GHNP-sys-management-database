using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using LanguageCenter.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LanguageCenter.GUI.childForms
{
    public partial class StudentManage : Form
    {
        public StudentManage()
        {
            InitializeComponent();
        }


        private void DisplayStudentsList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetListStudent", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }



        private void ClassManage_Load(object sender, EventArgs e)
        {
            studentGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentGridview.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            studentGridview.AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllCells;
            DisplayStudentsList();
        }

        private void GetStudentByStudentName(string studentname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStudentByStudentName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name",SqlDbType.NVarChar,50).Value= studentname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }


        private void GetStudentByTeacherName(string teachername)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStudentByTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = teachername;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void GetStudentByCourseName(string coursename)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStudentByCourseName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = coursename;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void GetStudentByClassName(string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetStudentByClassName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //student name
            {
                GetStudentByStudentName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) //class name
            {
                GetStudentByClassName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 2) //course name
            {
                GetStudentByCourseName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 3) //teacher name
            {
                GetStudentByTeacherName(textBox1.Text);
            }
        }

        private void AddStudent(string username, string name, string dateofbirth, string address, string email, string phone, string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("AddStudent", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
                    String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox5.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    AddStudent(textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text, textBox5.Text);
                    MessageBox.Show("Add data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayStudentsList();

                }
                catch (Exception)
                {

                    MessageBox.Show("Add failed! Please double check the data!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }

            }
        }

        private void studentGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.studentGridview.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text= row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
            }
        }

        private void UpdateStudent(string username, string name, string dateofbirth, string address, string email, string phone, string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("UpdateStudent", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }



        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
        String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    UpdateStudent(textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text, textBox5.Text);
                    MessageBox.Show("Update data successfully!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayStudentsList();
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

        private void DeleteStudentFull(string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deleteACCOUNT_STUDENT_sequently", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void DeleteStudentView(string username, string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deleteSTUDENT_View", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr =  MessageBox.Show("Delete all student accounts (Yes) or delete a student's class information (No) ", "Warning", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (DialogResult.Yes == dr)
            {
                if (String.IsNullOrEmpty(textBox2.Text))
                    MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    try
                    {
                        DeleteStudentFull(textBox2.Text);
                        MessageBox.Show("Delete data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayStudentsList();
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
            if (DialogResult.No == dr)
            {
                if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox5.Text))
                    MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    try
                    {
                        DeleteStudentView(textBox2.Text, textBox5.Text);
                        MessageBox.Show("Delete data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayStudentsList();
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
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            DisplayStudentsList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetListStudent", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            studentGridview.DataSource = dt;

            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{6}%' or [{1}] LIKE '%{6}%' or [{2}] LIKE '%{6}%' " +
                "or [{3}] LIKE '%{6}%' or [{4}] LIKE '%{6}%' or [{5}] LIKE '%{6}%'", "Username","StudentName","DateOfBirth","Address","Email","Phone", textBox1.Text);
        }
    }
}

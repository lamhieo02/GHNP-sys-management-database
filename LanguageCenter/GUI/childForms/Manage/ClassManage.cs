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
    public partial class ClassManage : Form
    {
        public ClassManage()
        {
            InitializeComponent();
        }

        private void DisplayClassList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Class_Info;", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
            classGridview.Columns[0].Width= 65;
            classGridview.Columns[10].Width = 70;
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            classGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            classGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            classGridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayClassList();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            DisplayClassList();
        }

        private void AddClass(string classname, string startdate, string enddate, string weekdays, TimeSpan starttime, TimeSpan endtime, 
            string classroom, string coursename, float target, string teachername)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("AddClass", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            da.SelectCommand.Parameters.Add("@startdate", SqlDbType.Date).Value = startdate;
            da.SelectCommand.Parameters.Add("@enddate", SqlDbType.Date).Value = enddate;
            da.SelectCommand.Parameters.Add("@weekdays", SqlDbType.VarChar, 10).Value = weekdays;
            da.SelectCommand.Parameters.Add("@starttime", SqlDbType.Time, 20).Value = starttime;
            da.SelectCommand.Parameters.Add("@endtime", SqlDbType.Time, 20).Value = endtime;
            da.SelectCommand.Parameters.Add("@classroom", SqlDbType.VarChar, 20).Value = classroom;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            da.SelectCommand.Parameters.Add("@target", SqlDbType.Float).Value = target;
            da.SelectCommand.Parameters.Add("@teachername", SqlDbType.NVarChar, 50).Value = teachername;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) ||
String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox6.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    AddClass(textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, textBox6.Text, dateTimePicker4.Value.TimeOfDay
                        , dateTimePicker3.Value.TimeOfDay, textBox4.Text,
                        textBox9.Text, float.Parse(textBox7.Text), textBox5.Text);
                    MessageBox.Show("Add data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayClassList();
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

        private void UpdateClass(int classid, string classname, string startdate, string enddate, string weekdays, TimeSpan starttime, TimeSpan endtime,
            string classroom, string coursename, float target, string teachername)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("UpdateClass", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@classid", SqlDbType.Int).Value = classid;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            da.SelectCommand.Parameters.Add("@startdate", SqlDbType.Date).Value = startdate;
            da.SelectCommand.Parameters.Add("@enddate", SqlDbType.Date).Value = enddate;
            da.SelectCommand.Parameters.Add("@weekdays", SqlDbType.VarChar, 10).Value = weekdays;
            da.SelectCommand.Parameters.Add("@starttime", SqlDbType.Time, 20).Value = starttime;
            da.SelectCommand.Parameters.Add("@endtime", SqlDbType.Time, 20).Value = endtime;
            da.SelectCommand.Parameters.Add("@classroom", SqlDbType.VarChar, 20).Value = classroom;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            da.SelectCommand.Parameters.Add("@target", SqlDbType.Float).Value = target;
            da.SelectCommand.Parameters.Add("@teachername", SqlDbType.NVarChar, 50).Value = teachername;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) ||
String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox6.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {

                    UpdateClass(int.Parse(textBox3.Text),textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, 
                        textBox6.Text, dateTimePicker4.Value.TimeOfDay, dateTimePicker3.Value.TimeOfDay, textBox4.Text,
                        textBox9.Text, float.Parse(textBox7.Text), textBox5.Text);
                    MessageBox.Show("Update data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayClassList();
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

        private void DeleteClass(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deleteCLASS_sequently", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    DeleteClass(int.Parse(textBox3.Text));
                    MessageBox.Show("Delete data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayClassList();
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox7.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8  && ch != 46)
            {
                e.Handled= true;
            }
        }

        private void classGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.classGridview.Rows[e.RowIndex];
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                dateTimePicker2.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                dateTimePicker4.Text = row.Cells[5].Value.ToString();
                dateTimePicker3.Text = row.Cells[6].Value.ToString();
                textBox4.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
                textBox9.Text = row.Cells[9].Value.ToString();
                textBox7.Text = row.Cells[10].Value.ToString();
                textBox5.Text = row.Cells[11].Value.ToString();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox3.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Class_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
            dt.DefaultView.RowFilter = string.Format("Convert([{0}],'System.String') LIKE '%{12}%' or [{1}] LIKE '%{12}%' or [{2}] LIKE '%{12}%' or [{3}] LIKE '%{12}%' " +
                "or [{4}] LIKE '%{12}%' or [{5}] LIKE '%{12}%' or [{6}] LIKE '%{12}%' or [{7}] LIKE '%{12}%' or Convert([{8}],'System.String') LIKE '%{12}%' " +
                "or [{9}] LIKE '%{12}%' or Convert([{10}],'System.String') LIKE '%{12}%' or [{11}] LIKE '%{12}%'",
                "ID", "ClassName", "StartDate", "EndDate", "WeekDays", "StartTime", "EndTime", "ClassRoom", "NoStudents", "CourseName", "Target", "TeacherName", textBox1.Text);

        }

        private void GetClassBYClassName(string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassBYClassName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void GetClassBYClassRoom(string classroom)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassBYClassRoom", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@classroom", SqlDbType.VarChar, 20).Value = classroom;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void GetClassBYCourseName(string coursename)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassBYCourseName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void GetClassBYTeacherName(string teachername)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassBYTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@teachername", SqlDbType.NVarChar, 100).Value = teachername;
            DataTable dt = new DataTable();
            da.Fill(dt);
            classGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //class name
            {
                GetClassBYClassName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) //classroom
            {
                GetClassBYClassRoom(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 2) //course name
            {
                GetClassBYCourseName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 3) //teacher name
            {
                GetClassBYTeacherName(textBox1.Text);
            }
        }
    }
}

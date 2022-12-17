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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LanguageCenter.GUI.childForms
{
    public partial class CourseManage : Form
    {
        public CourseManage()
        {
            InitializeComponent();
        }

        private void DisplayCourseList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Course_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            courseGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            courseGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            courseGridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayCourseList();
        }

        private void AddCourse(string coursename, float target, int nolessons, int price)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("AddCourse", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            da.SelectCommand.Parameters.Add("@target", SqlDbType.Float).Value = target;
            da.SelectCommand.Parameters.Add("@nolessons", SqlDbType.Int).Value = nolessons;
            da.SelectCommand.Parameters.Add("@price", SqlDbType.Int).Value = price;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    AddCourse(textBox2.Text,float.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                    MessageBox.Show("Add data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayCourseList();
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

        private void UpdateCourse(int courseid, string coursename, float target, int nolessons, int price)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("UpdateCourse", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@courseid", SqlDbType.Int).Value = courseid;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            da.SelectCommand.Parameters.Add("@target", SqlDbType.Float).Value = target;
            da.SelectCommand.Parameters.Add("@nolessons", SqlDbType.Int).Value = nolessons;
            da.SelectCommand.Parameters.Add("@price", SqlDbType.Int).Value = price;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    UpdateCourse(int.Parse(textBox3.Text), textBox2.Text, float.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                    MessageBox.Show("Update data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayCourseList();
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

        private void DeleteCouse(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deleteCOURSE_sequently", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
                MessageBox.Show("Please enter enough information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    DeleteCouse(int.Parse(textBox3.Text));
                    MessageBox.Show("Delete data successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayCourseList();
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

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            DisplayCourseList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Course_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
            dt.DefaultView.RowFilter = string.Format("Convert([{0}],'System.String') LIKE '%{5}%' or [{1}] LIKE '%{5}%' or Convert([{2}],'System.String') LIKE '%{5}%' " +
                "or Convert([{3}],'System.String') LIKE '%{5}%' or Convert([{4}],'System.String') LIKE '%{5}%'",
                "ID", "CourseName", "Target", "NoLessons", "Price", textBox1.Text);
        }

        private void GetCourseByCoureName(string coursename)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetCourseByCoureName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar, 40).Value = coursename;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void GetCourseByMinPrice(int price)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetCourseByMinPrice", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@price", SqlDbType.Int).Value = price;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void GetCourseByMaxPrice(int price)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetCourseByMaxPrice", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@price", SqlDbType.Int).Value = price;
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //class name
            {
                GetCourseByCoureName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) //min price
            {
                try
                {
                    GetCourseByMinPrice(int.Parse(textBox1.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Please double check the data!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
            if (comboBox1.SelectedIndex == 2) //max price
            {
                try
                {
                    GetCourseByMaxPrice(int.Parse(textBox1.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Please double check the data!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void courseGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.courseGridview.Rows[e.RowIndex];
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox6.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox5.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox4.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
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
    }
}

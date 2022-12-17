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
    public partial class AllClass : Form
    {
        public AllClass()
        {
            InitializeComponent();
        }


        private void ClassManage_Load(object sender, EventArgs e)
        {
            AllClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllClass_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllClass_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void AllClass_Load(object sender, EventArgs e)
        {
            AllClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllClass_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllClass_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayAllClassesList();
        }
        public void DisplayAllClassesList()
        {

            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getAllClasses", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
            AllClass_Gridview.Columns[0].Width = 65;
            AllClass_Gridview.Columns[7].Width = 80;
            AllClass_Gridview.Columns[8].Width = 90;
            AllClass_Gridview.Columns[10].Width = 70;
        }

        public void GetClassByTeacherName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@teachername", SqlDbType.NVarChar, 100).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByClasssID(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByClassID", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByClasssName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByClassName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@classname", SqlDbType.NVarChar, 100).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByCourseName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByCourseName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@coursename", SqlDbType.NVarChar,40).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }


        private void refreshBtn_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            searchCbb.Text = "";
            DisplayAllClassesList();
        }

        private void searchCbb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (searchCbb.SelectedIndex == 0) //class name
            {
                GetClassByClasssName(txtSearch.Text);
            }
            if (searchCbb.SelectedIndex == 1) //teacher name
            {
                GetClassByTeacherName(txtSearch.Text);
            }
            if (searchCbb.SelectedIndex == 2) //course name
            {
                GetClassByCourseName(txtSearch.Text);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getAllClasses", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
            dt.DefaultView.RowFilter = string.Format("Convert([{0}],'System.String') LIKE '%{12}%' or [{1}] LIKE '%{12}%' or [{2}] LIKE '%{12}%' or [{3}] LIKE '%{12}%' " +
                "or [{4}] LIKE '%{12}%' or [{5}] LIKE '%{12}%' or [{6}] LIKE '%{12}%' or [{7}] LIKE '%{12}%' or Convert([{8}],'System.String') LIKE '%{12}%' " +
                "or [{9}] LIKE '%{12}%' or Convert([{10}],'System.String') LIKE '%{12}%' or [{11}] LIKE '%{12}%'",
                "ID", "ClassName", "StartDate", "EndDate", "WeekDays", "StartTime", "EndTime", "ClassRoom", "NoStudents", "CourseName", "Target", "TeacherName", txtSearch.Text);
        }
    }
}

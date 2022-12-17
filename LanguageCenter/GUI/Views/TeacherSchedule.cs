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
    public partial class TeacherSchedule : Form
    {
        string usernameTeacher;
        public TeacherSchedule(string Username)
        {
            this.usernameTeacher = Username;
            InitializeComponent();
        }


        private void DisplayScheduleList()
        {
            var conn = DAL.DataAccess.getConnection();
            SqlDataAdapter da = new SqlDataAdapter("getScheduleTeacher", conn);
            da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = usernameTeacher;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TeacherSchedule_GridView.DataSource = dt;
        }
        private void ClassManage_Load(object sender, EventArgs e)
        {
            TeacherSchedule_GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TeacherSchedule_GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TeacherSchedule_GridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayScheduleList();
        }
    }
}

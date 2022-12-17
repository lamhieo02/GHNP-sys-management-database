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
    public partial class StudentSchedule : Form
    {
        string usernameStudent;
        public StudentSchedule(string Username)
        {
            usernameStudent = Username;
            InitializeComponent();
        }
        private void DisplayScheduleList()
        {
            var conn = DAL.DataAccess.getConnection();
            //var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getScheduleStudent", conn);
            da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = usernameStudent;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            schedule_Gridview.DataSource = dt;
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            schedule_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            schedule_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            schedule_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayScheduleList();
        }
    }
}

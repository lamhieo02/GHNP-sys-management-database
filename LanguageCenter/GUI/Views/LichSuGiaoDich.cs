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
    public partial class LichSuGiaoDich : Form
    {
        string paymentUsername = "";
        public LichSuGiaoDich(string paymentUsername)
        {
            InitializeComponent();
            this.paymentUsername = paymentUsername; 
        }
        private void DisplayTransactionHistory()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionHistory", conn);
            da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = paymentUsername;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            TransactionHistory.DataSource = dt;
            TransactionHistory.Columns["PaymentStatus"].ReadOnly = true;
        }
        private void ClassManage_Load(object sender, EventArgs e)
        {
            TransactionHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TransactionHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TransactionHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayTransactionHistory();
        }
    }
}

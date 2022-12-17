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
    public partial class PaymentManage : Form
    {
        public PaymentManage()
        {
            InitializeComponent();
        }

        private void DisplayPaymentsList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from getPayments_func()", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
            paymentGridview.Columns[0].Width = 40;
        }
        private void ClassManage_Load(object sender, EventArgs e)
        {
            paymentGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paymentGridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayPaymentsList();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || dateTimePicker1.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Please enter enough information!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string username = txtUsername.Text;
            string date = dateTimePicker1.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            int method = Convert.ToInt32(methodCbb.SelectedIndex) + 1;

            try
            {
                InsertPayment(date, amount, method, 0, username); // default status = 0
            }
            catch (Exception e1)
            {
                MessageBox.Show("Add failed! Please double check the data!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                MessageBox.Show(e1.ToString());
            }
        }
        public void InsertPayment(string payment_date, int amount, int method_id, int status, string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("InsertPayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@payment_date", SqlDbType.Date).Value = payment_date;
            da.SelectCommand.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
            da.SelectCommand.Parameters.Add("@method_id", SqlDbType.Int).Value = method_id;
            da.SelectCommand.Parameters.Add("@status", SqlDbType.Int).Value = 0;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Add data successfully!!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || dateTimePicker1.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Please enter enough information!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            string username = txtUsername.Text;
            string payment_date = dateTimePicker1.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            int method_id = Convert.ToInt32(methodCbb.SelectedIndex) + 1;

            try
            {
                UpdatePayment(id, payment_date, amount, method_id, username);
            }
            catch
            {
                MessageBox.Show("Update failed! Please double check the data!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        public void UpdatePayment(int id, string payment_date, int amount, int method_id, string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("updatePayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            da.SelectCommand.Parameters.Add("@payment_date", SqlDbType.Date).Value = payment_date;
            da.SelectCommand.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
            da.SelectCommand.Parameters.Add("@method_id", SqlDbType.Int).Value = method_id;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Update data successfully!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUsername.Text == "" || dateTimePicker1.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Please enter enough information!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            try
            {
                deletePayment(id);
            }
            catch
            {
                MessageBox.Show("Delete failed! Please double check the data!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void deletePayment(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deletePayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Delete data successfully!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void paymentGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.paymentGridview.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[5].Value.ToString();
                txtAmount.Text = row.Cells[6].Value.ToString();
                methodCbb.Text = row.Cells[7].Value.ToString();
                string statusStr = row.Cells[8].Value.ToString();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtUsername.Text = "";
            dateTimePicker1.Text = "";
            txtAmount.Text = "";
            methodCbb.Text = "";
            DisplayPaymentsList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from PaymentsView", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
            dt.DefaultView.RowFilter = string.Format("Convert([ID],'System.String') LIKE '%{0}%' or" +
                                                     "[Username] LIKE '%{0}%' or" +
                                                     "[StudentName] LIKE '%{0}%' or" +
                                                     "[Email] LIKE '%{0}%' or" +
                                                     "[Phone] LIKE '%{0}%' or" +
                                                     " Convert([Amount],'System.String') LIKE '%{0}%' or" +
                                                     " Convert([PaymentDate],'System.String') LIKE '%{0}%' or" +
                                                     "[PaymentMethod] LIKE '%{0}%' or" +
                                                     "[PaymentStatus] LIKE '%{0}%'", textBox1.Text);
        }
        public void GetPaymentBYStudentName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetPaymentBYStudentName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
        }
        public void GetPaymentBYPhone(string phone)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetPaymentBYPhone", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
        }
        public void GetPaymentBYPaymentMethod(string method)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetPaymentBYPaymentMethod", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@method", SqlDbType.NVarChar, 100).Value = method;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
        }
        public void GetPaymentByPaymentStatus(string status)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetPaymentBYPaymentStatus", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@status", SqlDbType.NVarChar, 100).Value = status;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) 
            {
                GetPaymentBYStudentName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) 
            {
                GetPaymentBYPhone(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 2) 
            {
                GetPaymentBYPaymentMethod(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 3) 
            {
                try
                {
                    GetPaymentByPaymentStatus(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Payment status malformed!");
                }
            }
        }
    }
}

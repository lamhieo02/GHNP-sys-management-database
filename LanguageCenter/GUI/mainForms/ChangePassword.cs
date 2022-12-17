using LanguageCenter.BLL;
using LanguageCenter.DTO;
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

namespace LanguageCenter.GUI.mainForms
{
    public partial class ChangePassword : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
        }

        public void changePassword(string username, string password)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("ChangePassword", conn);
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            da.SelectCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            //da.Fill(dt);
            try
            {
                da.Fill(dt);
                MessageBox.Show("Change password successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(username);
                MessageBox.Show(password);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Password is not eligible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XuliChangePw()
        {
            string username = Username;
            string password = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            if (password == "" || password2 == "")
            {
                MessageBox.Show("Please enter enough information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (password == password2)
                {
                    changePassword(username, password);
                }
                else
                {
                    MessageBox.Show("Password incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            XuliChangePw();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Username;
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                XuliChangePw();
            }
        }
    }
}

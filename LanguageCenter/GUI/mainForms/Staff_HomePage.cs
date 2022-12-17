using LanguageCenter.DTO;
using LanguageCenter.GUI.childForms;
using LanguageCenter.GUI.mainForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI
{
    public partial class Staff_HomePage : Form
    {
        private Form activeForm;
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Date_Birth { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private Form parent;
        public Staff_HomePage(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void Staff_HomePage_Load(object sender, EventArgs e)
        {
           
            txtName.Text = "          " + Name;
            FormBorderStyle = FormBorderStyle.Sizable;
            TopMost = false;
            this.WindowState = FormWindowState.Maximized;
        }
        private void OpenChildForm(Form childForm, object btnSender) {
            {
                if(activeForm != null)
                {
                    activeForm.Close();
                }
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(childForm);
                this.panelDesktopPane.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

            } 
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.ShowDialog();
        }
        private void profileBtn_Click(object sender, EventArgs e)
        {
            var profile = new childForms.Staff_Profile();
            profile.ID = ID;
            profile.Username = Username;
            profile.Position = Position;
            profile.Address = Address;
            profile.Date_Birth = Date_Birth;
            profile.Name = Name;
            profile.Email = Email;
            profile.Phone = Phone;
            OpenChildForm(profile, sender);
        }
        private void changePwBtn_Click(object sender, EventArgs e)
        {
            var changePw = new ChangePassword();
            changePw.Username = Username;
            changePw.ShowDialog();
        }
        private void studentManageBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new childForms.StudentManage(), sender);
        }

        private void teacherManageBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new childForms.TeacherManage(), sender);
        }

        private void courseManageBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new childForms.CourseManage(), sender);
        }

        private void classManageBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new childForms.ClassManage(), sender);
        }

        private void paymentManageBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new childForms.PaymentManage(), sender);
        }

        private void Staff_HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();   
        }
    }
}

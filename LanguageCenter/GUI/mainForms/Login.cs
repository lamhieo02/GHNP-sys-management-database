using LanguageCenter.BLL;
using LanguageCenter.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.mainForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string username;
        public static string password;

        public void XuLiLogin()
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            //xu li login
            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Please enter enough information!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            AccountDAO accountDAO = new AccountDAO();
            Account account = accountDAO.getAccountByUsername(username, password);

            if (account == null)
            {
                MessageBox.Show("User does not exist!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string account_pw = account.Password;
                string account_username = account.Username;
                if (password != account_pw || username != account_username)
                {
                    MessageBox.Show("Wrong password!",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    Application.Restart();
                }
                else
                {
                    int role = accountDAO.getRoleByUserName(username);
                    string role_name = "";
                    if (role == 1)
                    {
                        role_name = accountDAO.getRoleName(username);
                    }

                    // LoginStudent();
                    if (role == 1)
                    {
                        if (role_name == "Admin")
                        {
                            LoginAdmin();
                        }
                        else
                        {
                            LoginStaff();
                        }    

                    }
                    else if (role == 2)
                    {
                        LoginTeacher();
                    }
                    else if (role == 3)
                    {
                        LoginStudent();
                    }
                    else
                    {
                        LoginAdmin();
                    }
                }
            }
           
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            XuLiLogin();
        }
        public void LoginAdmin()
        {
            string username = txtUsername.Text;
            //lay thong tin user
            StaffDAO staff_dao = new StaffDAO();
            Staff staff = staff_dao.getStaffByUsername(username);
            Admin_HomePage adminForm = new Admin_HomePage(this);
            adminForm.Username = staff.Username;
            adminForm.Password = staff.Password;
            adminForm.Position = staff.Position;
            adminForm.Address = staff.Address;
            adminForm.Date_Birth = staff.Date_Birth;
            adminForm.Name = staff.Name;
            adminForm.Email = staff.Email;
            adminForm.Phone = staff.Phone;

            this.Hide();
            adminForm.ShowDialog();
        }
        public void LoginStaff()
        {
            string username = txtUsername.Text;
            //lay thong tin user
            StaffDAO staff_dao = new StaffDAO();
            Staff staff = staff_dao.getStaffByUsername(username);
            Staff_HomePage staffForm = new Staff_HomePage(this);
            staffForm.Username = staff.Username;
            staffForm.Password = staff.Password;
            staffForm.Address = staff.Address;
            staffForm.Date_Birth = staff.Date_Birth;
            staffForm.Name = staff.Name;
            staffForm.Email = staff.Email;
            staffForm.Phone = staff.Phone;
            staffForm.Position = staff.Position;

            this.Hide();
            staffForm.ShowDialog();
        }
        public void LoginStudent()
        {
            string username = txtUsername.Text;
            //lay thong tin user
            StudentDAO student_dao = new StudentDAO();
            Student student = student_dao.getStudentByUsername(username);
            Student_HomePage studentForm = new Student_HomePage(this);
            studentForm.Username = student.Username;
            studentForm.Address = student.Address;
            studentForm.Date_Birth = student.Date_Birth;
            studentForm.Name = student.Name;
            studentForm.Email = student.Email;
            studentForm.Phone = student.Phone;
            
            this.Hide();
            studentForm.ShowDialog();   
        }
        public void LoginTeacher()
        {
            string username = txtUsername.Text;
            //lay thong tin user
            TeacherDAO teacher_dao = new TeacherDAO();
            Teacher teacher = teacher_dao.getTeacherByUsername(username);
            Teacher_HomePage teacherForm = new Teacher_HomePage(this);
            teacherForm.Username = teacher.Username;
            teacherForm.Address = teacher.Address;
            teacherForm.Date_Birth = teacher.Date_Birth;
            teacherForm.Name = teacher.Name;
            teacherForm.Email = teacher.Email;
            teacherForm.Phone = teacher.Phone;

            this.Hide();
            teacherForm.ShowDialog();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                XuLiLogin();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

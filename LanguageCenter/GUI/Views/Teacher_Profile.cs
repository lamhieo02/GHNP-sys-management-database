using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.childForms
{
    public partial class Teacher_Profile : Form
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Date_Birth { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Teacher_Profile()
        {
            InitializeComponent();
        }

  

        private void Teacher_Profile_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtAddress.Text = Address;
            txtDateBirth.Text = Date_Birth;
            txtEmail.Text = Email;
            txtPhone.Text = Phone;
        }
    }
}

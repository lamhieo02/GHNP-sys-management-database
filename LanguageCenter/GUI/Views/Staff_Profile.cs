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
    public partial class Staff_Profile : Form
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Date_Birth { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public Staff_Profile()
        {
            InitializeComponent();
        }

   

        private void Staff_Profile_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtUsername.Text = Username;
            txtAddress.Text = Address;
            txtDateBirth.Text = Date_Birth;
            txtEmail.Text = Email;
            txtPhone.Text = Phone;
            txtPosition.Text = Position;
        }
    }
}

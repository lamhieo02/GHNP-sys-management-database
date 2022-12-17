
namespace LanguageCenter.GUI
{
    partial class Staff_HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff_HomePage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.changePwBtn = new System.Windows.Forms.Button();
            this.paymentManageBtn = new System.Windows.Forms.Button();
            this.classManageBtn = new System.Windows.Forms.Button();
            this.courseManageBtn = new System.Windows.Forms.Button();
            this.teacherManageBtn = new System.Windows.Forms.Button();
            this.studentManageBtn = new System.Windows.Forms.Button();
            this.profileBtn = new System.Windows.Forms.Button();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 69);
            this.panel1.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Image = global::LanguageCenter.Properties.Resources.representative;
            this.txtName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Location = new System.Drawing.Point(1078, 0);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(0, 25, 9, 20);
            this.txtName.Size = new System.Drawing.Size(9, 63);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::LanguageCenter.Properties.Resources.education;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(9, 25, 0, 20);
            this.label1.Size = new System.Drawing.Size(207, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "                Language Center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.changePwBtn);
            this.panel2.Controls.Add(this.paymentManageBtn);
            this.panel2.Controls.Add(this.classManageBtn);
            this.panel2.Controls.Add(this.courseManageBtn);
            this.panel2.Controls.Add(this.teacherManageBtn);
            this.panel2.Controls.Add(this.studentManageBtn);
            this.panel2.Controls.Add(this.profileBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 683);
            this.panel2.TabIndex = 2;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Image = global::LanguageCenter.Properties.Resources.logout;
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.Location = new System.Drawing.Point(0, 546);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.logoutBtn.Size = new System.Drawing.Size(283, 78);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "         Log Out";
            this.logoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // changePwBtn
            // 
            this.changePwBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.changePwBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.changePwBtn.FlatAppearance.BorderSize = 0;
            this.changePwBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePwBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.changePwBtn.ForeColor = System.Drawing.Color.White;
            this.changePwBtn.Image = global::LanguageCenter.Properties.Resources.settings;
            this.changePwBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePwBtn.Location = new System.Drawing.Point(0, 468);
            this.changePwBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changePwBtn.Name = "changePwBtn";
            this.changePwBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.changePwBtn.Size = new System.Drawing.Size(283, 78);
            this.changePwBtn.TabIndex = 6;
            this.changePwBtn.Text = "         Change Password";
            this.changePwBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePwBtn.UseVisualStyleBackColor = false;
            this.changePwBtn.Click += new System.EventHandler(this.changePwBtn_Click);
            // 
            // paymentManageBtn
            // 
            this.paymentManageBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.paymentManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.paymentManageBtn.FlatAppearance.BorderSize = 0;
            this.paymentManageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentManageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.paymentManageBtn.ForeColor = System.Drawing.Color.White;
            this.paymentManageBtn.Image = global::LanguageCenter.Properties.Resources.credit_card;
            this.paymentManageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentManageBtn.Location = new System.Drawing.Point(0, 390);
            this.paymentManageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentManageBtn.Name = "paymentManageBtn";
            this.paymentManageBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.paymentManageBtn.Size = new System.Drawing.Size(283, 78);
            this.paymentManageBtn.TabIndex = 5;
            this.paymentManageBtn.Text = "         Payment Management";
            this.paymentManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentManageBtn.UseVisualStyleBackColor = false;
            this.paymentManageBtn.Click += new System.EventHandler(this.paymentManageBtn_Click);
            // 
            // classManageBtn
            // 
            this.classManageBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.classManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.classManageBtn.FlatAppearance.BorderSize = 0;
            this.classManageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classManageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.classManageBtn.ForeColor = System.Drawing.Color.White;
            this.classManageBtn.Image = global::LanguageCenter.Properties.Resources._class;
            this.classManageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.classManageBtn.Location = new System.Drawing.Point(0, 312);
            this.classManageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classManageBtn.Name = "classManageBtn";
            this.classManageBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.classManageBtn.Size = new System.Drawing.Size(283, 78);
            this.classManageBtn.TabIndex = 4;
            this.classManageBtn.Text = "         Class Management";
            this.classManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.classManageBtn.UseVisualStyleBackColor = false;
            this.classManageBtn.Click += new System.EventHandler(this.classManageBtn_Click);
            // 
            // courseManageBtn
            // 
            this.courseManageBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.courseManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseManageBtn.FlatAppearance.BorderSize = 0;
            this.courseManageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseManageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.courseManageBtn.ForeColor = System.Drawing.Color.White;
            this.courseManageBtn.Image = global::LanguageCenter.Properties.Resources.open_book;
            this.courseManageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courseManageBtn.Location = new System.Drawing.Point(0, 234);
            this.courseManageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.courseManageBtn.Name = "courseManageBtn";
            this.courseManageBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.courseManageBtn.Size = new System.Drawing.Size(283, 78);
            this.courseManageBtn.TabIndex = 3;
            this.courseManageBtn.Text = "         Course Management";
            this.courseManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courseManageBtn.UseVisualStyleBackColor = false;
            this.courseManageBtn.Click += new System.EventHandler(this.courseManageBtn_Click);
            // 
            // teacherManageBtn
            // 
            this.teacherManageBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.teacherManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.teacherManageBtn.FlatAppearance.BorderSize = 0;
            this.teacherManageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teacherManageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.teacherManageBtn.ForeColor = System.Drawing.Color.White;
            this.teacherManageBtn.Image = global::LanguageCenter.Properties.Resources.teacher;
            this.teacherManageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teacherManageBtn.Location = new System.Drawing.Point(0, 156);
            this.teacherManageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teacherManageBtn.Name = "teacherManageBtn";
            this.teacherManageBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.teacherManageBtn.Size = new System.Drawing.Size(283, 78);
            this.teacherManageBtn.TabIndex = 2;
            this.teacherManageBtn.Text = "         Teacher Management";
            this.teacherManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teacherManageBtn.UseVisualStyleBackColor = false;
            this.teacherManageBtn.Click += new System.EventHandler(this.teacherManageBtn_Click);
            // 
            // studentManageBtn
            // 
            this.studentManageBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.studentManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.studentManageBtn.FlatAppearance.BorderSize = 0;
            this.studentManageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.studentManageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.studentManageBtn.ForeColor = System.Drawing.Color.White;
            this.studentManageBtn.Image = global::LanguageCenter.Properties.Resources.student_admin;
            this.studentManageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.studentManageBtn.Location = new System.Drawing.Point(0, 78);
            this.studentManageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentManageBtn.Name = "studentManageBtn";
            this.studentManageBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.studentManageBtn.Size = new System.Drawing.Size(283, 78);
            this.studentManageBtn.TabIndex = 1;
            this.studentManageBtn.Text = "         Student Management";
            this.studentManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.studentManageBtn.UseVisualStyleBackColor = false;
            this.studentManageBtn.Click += new System.EventHandler(this.studentManageBtn_Click);
            // 
            // profileBtn
            // 
            this.profileBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.profileBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.profileBtn.FlatAppearance.BorderSize = 0;
            this.profileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.profileBtn.ForeColor = System.Drawing.Color.White;
            this.profileBtn.Image = global::LanguageCenter.Properties.Resources.user;
            this.profileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileBtn.Location = new System.Drawing.Point(0, 0);
            this.profileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.profileBtn.Size = new System.Drawing.Size(283, 78);
            this.profileBtn.TabIndex = 0;
            this.profileBtn.Text = "         Profile";
            this.profileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileBtn.UseVisualStyleBackColor = false;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.button1);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(283, 69);
            this.panelDesktopPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(804, 683);
            this.panelDesktopPane.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::LanguageCenter.Properties.Resources._5514;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(804, 683);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Staff_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 752);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Staff_HomePage";
            this.Text = "Staff_HomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Staff_HomePage_FormClosed);
            this.Load += new System.EventHandler(this.Staff_HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelDesktopPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button profileBtn;
        private System.Windows.Forms.Button classManageBtn;
        private System.Windows.Forms.Button courseManageBtn;
        private System.Windows.Forms.Button teacherManageBtn;
        private System.Windows.Forms.Button studentManageBtn;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button changePwBtn;
        private System.Windows.Forms.Button paymentManageBtn;
    }
}
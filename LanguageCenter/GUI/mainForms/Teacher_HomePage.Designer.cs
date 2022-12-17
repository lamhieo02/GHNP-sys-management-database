
namespace LanguageCenter.GUI
{
    partial class Teacher_HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher_HomePage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.changePwBtn = new System.Windows.Forms.Button();
            this.ScheduleViewBtn = new System.Windows.Forms.Button();
            this.AllClassBtn = new System.Windows.Forms.Button();
            this.teacherClassBtn = new System.Windows.Forms.Button();
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
            this.txtName.Image = global::LanguageCenter.Properties.Resources.teacher;
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
            this.panel2.Controls.Add(this.ScheduleViewBtn);
            this.panel2.Controls.Add(this.AllClassBtn);
            this.panel2.Controls.Add(this.teacherClassBtn);
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
            this.logoutBtn.Image = global::LanguageCenter.Properties.Resources.logout1;
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.Location = new System.Drawing.Point(0, 390);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.logoutBtn.Size = new System.Drawing.Size(283, 78);
            this.logoutBtn.TabIndex = 11;
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
            this.changePwBtn.Location = new System.Drawing.Point(0, 312);
            this.changePwBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changePwBtn.Name = "changePwBtn";
            this.changePwBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.changePwBtn.Size = new System.Drawing.Size(283, 78);
            this.changePwBtn.TabIndex = 10;
            this.changePwBtn.Text = "         Change Password";
            this.changePwBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePwBtn.UseVisualStyleBackColor = false;
            this.changePwBtn.Click += new System.EventHandler(this.changePwBtn_Click);
            // 
            // ScheduleViewBtn
            // 
            this.ScheduleViewBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.ScheduleViewBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScheduleViewBtn.FlatAppearance.BorderSize = 0;
            this.ScheduleViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScheduleViewBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ScheduleViewBtn.ForeColor = System.Drawing.Color.White;
            this.ScheduleViewBtn.Image = global::LanguageCenter.Properties.Resources.schedule;
            this.ScheduleViewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ScheduleViewBtn.Location = new System.Drawing.Point(0, 234);
            this.ScheduleViewBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScheduleViewBtn.Name = "ScheduleViewBtn";
            this.ScheduleViewBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.ScheduleViewBtn.Size = new System.Drawing.Size(283, 78);
            this.ScheduleViewBtn.TabIndex = 7;
            this.ScheduleViewBtn.Text = "         Timetable";
            this.ScheduleViewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ScheduleViewBtn.UseVisualStyleBackColor = false;
            this.ScheduleViewBtn.Click += new System.EventHandler(this.ScheduleViewBtn_Click);
            // 
            // AllClassBtn
            // 
            this.AllClassBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.AllClassBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AllClassBtn.FlatAppearance.BorderSize = 0;
            this.AllClassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllClassBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.AllClassBtn.ForeColor = System.Drawing.Color.White;
            this.AllClassBtn.Image = global::LanguageCenter.Properties.Resources.class1;
            this.AllClassBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AllClassBtn.Location = new System.Drawing.Point(0, 156);
            this.AllClassBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllClassBtn.Name = "AllClassBtn";
            this.AllClassBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.AllClassBtn.Size = new System.Drawing.Size(283, 78);
            this.AllClassBtn.TabIndex = 6;
            this.AllClassBtn.Text = "         Class List";
            this.AllClassBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AllClassBtn.UseVisualStyleBackColor = false;
            this.AllClassBtn.Click += new System.EventHandler(this.AllClassBtn_Click);
            // 
            // teacherClassBtn
            // 
            this.teacherClassBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.teacherClassBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.teacherClassBtn.FlatAppearance.BorderSize = 0;
            this.teacherClassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teacherClassBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.teacherClassBtn.ForeColor = System.Drawing.Color.White;
            this.teacherClassBtn.Image = global::LanguageCenter.Properties.Resources.open_book1;
            this.teacherClassBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teacherClassBtn.Location = new System.Drawing.Point(0, 78);
            this.teacherClassBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teacherClassBtn.Name = "teacherClassBtn";
            this.teacherClassBtn.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.teacherClassBtn.Size = new System.Drawing.Size(283, 78);
            this.teacherClassBtn.TabIndex = 1;
            this.teacherClassBtn.Text = "         My Class";
            this.teacherClassBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teacherClassBtn.UseVisualStyleBackColor = false;
            this.teacherClassBtn.Click += new System.EventHandler(this.teacherClassBtn_Click);
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
            // Teacher_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 752);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Teacher_HomePage";
            this.Text = "Teacher_HomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Teacher_HomePage_FormClosed);
            this.Load += new System.EventHandler(this.Teacher_HomePage_Load);
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
        private System.Windows.Forms.Button teacherClassBtn;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ScheduleViewBtn;
        private System.Windows.Forms.Button AllClassBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button changePwBtn;
    }
}
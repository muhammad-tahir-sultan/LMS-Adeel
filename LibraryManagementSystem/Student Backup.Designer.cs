namespace LibraryManagementSystem
{
    partial class Student_Backup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addStudent_gridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addStudent_gender = new System.Windows.Forms.ComboBox();
            this.addStudent_semester = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addStudent_department = new System.Windows.Forms.ComboBox();
            this.addStudent_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addStudent_importBtn = new System.Windows.Forms.Button();
            this.addStudent_clearBtn = new System.Windows.Forms.Button();
            this.addStudent_deleteBtn = new System.Windows.Forms.Button();
            this.addStudent_updateBtn = new System.Windows.Forms.Button();
            this.addStudent_addBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.addStudent_pictureBox = new System.Windows.Forms.PictureBox();
            this.addStudent_rollNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addStudent_phoneNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addStudent_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent_gridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Students";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.addStudent_gridView);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1525, 673);
            this.panel2.TabIndex = 3;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(1014, 46);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(341, 30);
            this.searchTextBox.TabIndex = 35;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(861, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 24);
            this.label9.TabIndex = 34;
            this.label9.Text = "Search Student:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addStudent_gridView
            // 
            this.addStudent_gridView.AllowUserToAddRows = false;
            this.addStudent_gridView.AllowUserToDeleteRows = false;
            this.addStudent_gridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.addStudent_gridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addStudent_gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.addStudent_gridView.ColumnHeadersHeight = 34;
            this.addStudent_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.addStudent_gridView.EnableHeadersVisualStyles = false;
            this.addStudent_gridView.Location = new System.Drawing.Point(48, 98);
            this.addStudent_gridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_gridView.Name = "addStudent_gridView";
            this.addStudent_gridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addStudent_gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.addStudent_gridView.RowHeadersVisible = false;
            this.addStudent_gridView.RowHeadersWidth = 62;
            this.addStudent_gridView.Size = new System.Drawing.Size(1316, 538);
            this.addStudent_gridView.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addStudent_gender);
            this.panel1.Controls.Add(this.addStudent_semester);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.addStudent_department);
            this.panel1.Controls.Add(this.addStudent_email);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.addStudent_importBtn);
            this.panel1.Controls.Add(this.addStudent_clearBtn);
            this.panel1.Controls.Add(this.addStudent_deleteBtn);
            this.panel1.Controls.Add(this.addStudent_updateBtn);
            this.panel1.Controls.Add(this.addStudent_addBtn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.addStudent_pictureBox);
            this.panel1.Controls.Add(this.addStudent_rollNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.addStudent_phoneNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addStudent_name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(7, 688);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1520, 347);
            this.panel1.TabIndex = 5;
            // 
            // addStudent_gender
            // 
            this.addStudent_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_gender.FormattingEnabled = true;
            this.addStudent_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.addStudent_gender.Location = new System.Drawing.Point(612, 110);
            this.addStudent_gender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addStudent_gender.Name = "addStudent_gender";
            this.addStudent_gender.Size = new System.Drawing.Size(404, 37);
            this.addStudent_gender.TabIndex = 6;
            // 
            // addStudent_semester
            // 
            this.addStudent_semester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_semester.FormattingEnabled = true;
            this.addStudent_semester.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.addStudent_semester.Location = new System.Drawing.Point(612, 159);
            this.addStudent_semester.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addStudent_semester.Name = "addStudent_semester";
            this.addStudent_semester.Size = new System.Drawing.Size(404, 37);
            this.addStudent_semester.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(476, 168);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 30;
            this.label7.Text = "Semester:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addStudent_department
            // 
            this.addStudent_department.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_department.FormattingEnabled = true;
            this.addStudent_department.Items.AddRange(new object[] {
            "Computer Science",
            "Information Technology",
            "Cyber Security",
            "Mass Communication",
            "Software Engineering",
            "Tele Communication"});
            this.addStudent_department.Location = new System.Drawing.Point(615, 20);
            this.addStudent_department.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addStudent_department.Name = "addStudent_department";
            this.addStudent_department.Size = new System.Drawing.Size(404, 37);
            this.addStudent_department.TabIndex = 4;
            // 
            // addStudent_email
            // 
            this.addStudent_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addStudent_email.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_email.Location = new System.Drawing.Point(118, 140);
            this.addStudent_email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_email.Name = "addStudent_email";
            this.addStudent_email.Size = new System.Drawing.Size(332, 36);
            this.addStudent_email.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Gender:";
            // 
            // addStudent_importBtn
            // 
            this.addStudent_importBtn.BackColor = System.Drawing.Color.Black;
            this.addStudent_importBtn.FlatAppearance.BorderSize = 0;
            this.addStudent_importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudent_importBtn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_importBtn.ForeColor = System.Drawing.Color.White;
            this.addStudent_importBtn.Location = new System.Drawing.Point(1030, 182);
            this.addStudent_importBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_importBtn.Name = "addStudent_importBtn";
            this.addStudent_importBtn.Size = new System.Drawing.Size(150, 35);
            this.addStudent_importBtn.TabIndex = 8;
            this.addStudent_importBtn.Text = "Import";
            this.addStudent_importBtn.UseVisualStyleBackColor = false;
            this.addStudent_importBtn.Click += new System.EventHandler(this.addStudent_importBtn_Click);
            // 
            // addStudent_clearBtn
            // 
            this.addStudent_clearBtn.BackColor = System.Drawing.Color.Black;
            this.addStudent_clearBtn.FlatAppearance.BorderSize = 0;
            this.addStudent_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudent_clearBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_clearBtn.ForeColor = System.Drawing.Color.White;
            this.addStudent_clearBtn.Location = new System.Drawing.Point(728, 241);
            this.addStudent_clearBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_clearBtn.Name = "addStudent_clearBtn";
            this.addStudent_clearBtn.Size = new System.Drawing.Size(150, 51);
            this.addStudent_clearBtn.TabIndex = 20;
            this.addStudent_clearBtn.Text = "CLEAR";
            this.addStudent_clearBtn.UseVisualStyleBackColor = false;
            this.addStudent_clearBtn.Click += new System.EventHandler(this.addStudent_clearBtn_Click_1);
            // 
            // addStudent_deleteBtn
            // 
            this.addStudent_deleteBtn.BackColor = System.Drawing.Color.Black;
            this.addStudent_deleteBtn.FlatAppearance.BorderSize = 0;
            this.addStudent_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudent_deleteBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.addStudent_deleteBtn.Location = new System.Drawing.Point(551, 241);
            this.addStudent_deleteBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_deleteBtn.Name = "addStudent_deleteBtn";
            this.addStudent_deleteBtn.Size = new System.Drawing.Size(150, 51);
            this.addStudent_deleteBtn.TabIndex = 19;
            this.addStudent_deleteBtn.Text = "DELETE";
            this.addStudent_deleteBtn.UseVisualStyleBackColor = false;
            this.addStudent_deleteBtn.Click += new System.EventHandler(this.addStudent_deleteBtn_Click_1);
            // 
            // addStudent_updateBtn
            // 
            this.addStudent_updateBtn.BackColor = System.Drawing.Color.Black;
            this.addStudent_updateBtn.FlatAppearance.BorderSize = 0;
            this.addStudent_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudent_updateBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_updateBtn.ForeColor = System.Drawing.Color.White;
            this.addStudent_updateBtn.Location = new System.Drawing.Point(356, 241);
            this.addStudent_updateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_updateBtn.Name = "addStudent_updateBtn";
            this.addStudent_updateBtn.Size = new System.Drawing.Size(168, 51);
            this.addStudent_updateBtn.TabIndex = 18;
            this.addStudent_updateBtn.Text = "UPDATE";
            this.addStudent_updateBtn.UseVisualStyleBackColor = false;
            this.addStudent_updateBtn.Click += new System.EventHandler(this.addStudent_updateBtn_Click_1);
            // 
            // addStudent_addBtn
            // 
            this.addStudent_addBtn.BackColor = System.Drawing.Color.Black;
            this.addStudent_addBtn.FlatAppearance.BorderSize = 0;
            this.addStudent_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudent_addBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_addBtn.ForeColor = System.Drawing.Color.White;
            this.addStudent_addBtn.Location = new System.Drawing.Point(179, 241);
            this.addStudent_addBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_addBtn.Name = "addStudent_addBtn";
            this.addStudent_addBtn.Size = new System.Drawing.Size(150, 51);
            this.addStudent_addBtn.TabIndex = 17;
            this.addStudent_addBtn.Text = "ADD";
            this.addStudent_addBtn.UseVisualStyleBackColor = false;
            this.addStudent_addBtn.Click += new System.EventHandler(this.addStudent_addBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(479, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Department:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addStudent_pictureBox
            // 
            this.addStudent_pictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.addStudent_pictureBox.Location = new System.Drawing.Point(1030, 22);
            this.addStudent_pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_pictureBox.Name = "addStudent_pictureBox";
            this.addStudent_pictureBox.Size = new System.Drawing.Size(150, 154);
            this.addStudent_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addStudent_pictureBox.TabIndex = 12;
            this.addStudent_pictureBox.TabStop = false;
            // 
            // addStudent_rollNo
            // 
            this.addStudent_rollNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addStudent_rollNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_rollNo.Location = new System.Drawing.Point(118, 22);
            this.addStudent_rollNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_rollNo.Name = "addStudent_rollNo";
            this.addStudent_rollNo.Size = new System.Drawing.Size(319, 36);
            this.addStudent_rollNo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Roll No:";
            // 
            // addStudent_phoneNo
            // 
            this.addStudent_phoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addStudent_phoneNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_phoneNo.Location = new System.Drawing.Point(118, 78);
            this.addStudent_phoneNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_phoneNo.Name = "addStudent_phoneNo";
            this.addStudent_phoneNo.Size = new System.Drawing.Size(332, 36);
            this.addStudent_phoneNo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone No:";
            // 
            // addStudent_name
            // 
            this.addStudent_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addStudent_name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudent_name.Location = new System.Drawing.Point(614, 66);
            this.addStudent_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStudent_name.Name = "addStudent_name";
            this.addStudent_name.Size = new System.Drawing.Size(408, 36);
            this.addStudent_name.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(483, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // Student_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Student_Backup";
            this.Size = new System.Drawing.Size(1569, 1050);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent_gridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStudent_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox addStudent_gender;
        private System.Windows.Forms.ComboBox addStudent_semester;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox addStudent_department;
        private System.Windows.Forms.TextBox addStudent_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addStudent_importBtn;
        private System.Windows.Forms.Button addStudent_clearBtn;
        private System.Windows.Forms.Button addStudent_deleteBtn;
        private System.Windows.Forms.Button addStudent_updateBtn;
        private System.Windows.Forms.Button addStudent_addBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox addStudent_pictureBox;
        private System.Windows.Forms.TextBox addStudent_rollNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addStudent_phoneNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addStudent_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView addStudent_gridView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label9;
    }
}
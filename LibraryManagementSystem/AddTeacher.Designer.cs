using System.Windows.Forms;

namespace LibraryManagementSystem
{
    partial class AddTeacher
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
            this.addTeacher_gridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.addTeacher_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addTeacher_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addTeacher_cnic = new System.Windows.Forms.TextBox();
            this.addTeacher_imagePicBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addTeacher_dob = new System.Windows.Forms.DateTimePicker();
            this.addTeacher_addBtn = new System.Windows.Forms.Button();
            this.addTeacher_updateBtn = new System.Windows.Forms.Button();
            this.addTeacher_deleteBtn = new System.Windows.Forms.Button();
            this.addTeacher_clearBtn = new System.Windows.Forms.Button();
            this.addTeacher_importBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.addTeacher_gender = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacher_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacher_imagePicBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Teachers";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.addTeacher_gridView);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1635, 1038);
            this.panel2.TabIndex = 5;
            // 
            // addTeacher_gridView
            // 
            this.addTeacher_gridView.AllowUserToAddRows = false;
            this.addTeacher_gridView.AllowUserToDeleteRows = false;
            this.addTeacher_gridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.addTeacher_gridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTeacher_gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.addTeacher_gridView.ColumnHeadersHeight = 34;
            this.addTeacher_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.addTeacher_gridView.EnableHeadersVisualStyles = false;
            this.addTeacher_gridView.Location = new System.Drawing.Point(27, 68);
            this.addTeacher_gridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_gridView.Name = "addTeacher_gridView";
            this.addTeacher_gridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addTeacher_gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.addTeacher_gridView.RowHeadersVisible = false;
            this.addTeacher_gridView.RowHeadersWidth = 62;
            this.addTeacher_gridView.Size = new System.Drawing.Size(1118, 322);
            this.addTeacher_gridView.TabIndex = 2;
            this.addTeacher_gridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addTeacher_gridView_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(428, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // addTeacher_name
            // 
            this.addTeacher_name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_name.Location = new System.Drawing.Point(516, 53);
            this.addTeacher_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_name.Name = "addTeacher_name";
            this.addTeacher_name.Size = new System.Drawing.Size(363, 32);
            this.addTeacher_name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address:";
            // 
            // addTeacher_address
            // 
            this.addTeacher_address.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_address.Location = new System.Drawing.Point(104, 62);
            this.addTeacher_address.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_address.Name = "addTeacher_address";
            this.addTeacher_address.Size = new System.Drawing.Size(296, 32);
            this.addTeacher_address.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "CNIC:";
            // 
            // addTeacher_cnic
            // 
            this.addTeacher_cnic.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_cnic.Location = new System.Drawing.Point(104, 18);
            this.addTeacher_cnic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_cnic.Name = "addTeacher_cnic";
            this.addTeacher_cnic.Size = new System.Drawing.Size(284, 32);
            this.addTeacher_cnic.TabIndex = 1;
            // 
            // addTeacher_imagePicBox
            // 
            this.addTeacher_imagePicBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.addTeacher_imagePicBox.Location = new System.Drawing.Point(895, 18);
            this.addTeacher_imagePicBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_imagePicBox.Name = "addTeacher_imagePicBox";
            this.addTeacher_imagePicBox.Size = new System.Drawing.Size(133, 123);
            this.addTeacher_imagePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addTeacher_imagePicBox.TabIndex = 12;
            this.addTeacher_imagePicBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(425, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "DOB:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addTeacher_dob
            // 
            this.addTeacher_dob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_dob.Location = new System.Drawing.Point(516, 16);
            this.addTeacher_dob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_dob.Name = "addTeacher_dob";
            this.addTeacher_dob.Size = new System.Drawing.Size(360, 30);
            this.addTeacher_dob.TabIndex = 3;
            // 
            // addTeacher_addBtn
            // 
            this.addTeacher_addBtn.BackColor = System.Drawing.Color.Black;
            this.addTeacher_addBtn.FlatAppearance.BorderSize = 0;
            this.addTeacher_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacher_addBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_addBtn.ForeColor = System.Drawing.Color.White;
            this.addTeacher_addBtn.Location = new System.Drawing.Point(109, 194);
            this.addTeacher_addBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_addBtn.Name = "addTeacher_addBtn";
            this.addTeacher_addBtn.Size = new System.Drawing.Size(133, 41);
            this.addTeacher_addBtn.TabIndex = 17;
            this.addTeacher_addBtn.Text = "ADD";
            this.addTeacher_addBtn.UseVisualStyleBackColor = false;
            this.addTeacher_addBtn.Click += new System.EventHandler(this.addTeacher_addBtn_Click);
            // 
            // addTeacher_updateBtn
            // 
            this.addTeacher_updateBtn.BackColor = System.Drawing.Color.Black;
            this.addTeacher_updateBtn.FlatAppearance.BorderSize = 0;
            this.addTeacher_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacher_updateBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_updateBtn.ForeColor = System.Drawing.Color.White;
            this.addTeacher_updateBtn.Location = new System.Drawing.Point(267, 194);
            this.addTeacher_updateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_updateBtn.Name = "addTeacher_updateBtn";
            this.addTeacher_updateBtn.Size = new System.Drawing.Size(150, 41);
            this.addTeacher_updateBtn.TabIndex = 18;
            this.addTeacher_updateBtn.Text = "UPDATE";
            this.addTeacher_updateBtn.UseVisualStyleBackColor = false;
            this.addTeacher_updateBtn.Click += new System.EventHandler(this.addTeacher_updateBtn_Click);
            // 
            // addTeacher_deleteBtn
            // 
            this.addTeacher_deleteBtn.BackColor = System.Drawing.Color.Black;
            this.addTeacher_deleteBtn.FlatAppearance.BorderSize = 0;
            this.addTeacher_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacher_deleteBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.addTeacher_deleteBtn.Location = new System.Drawing.Point(440, 194);
            this.addTeacher_deleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_deleteBtn.Name = "addTeacher_deleteBtn";
            this.addTeacher_deleteBtn.Size = new System.Drawing.Size(133, 41);
            this.addTeacher_deleteBtn.TabIndex = 19;
            this.addTeacher_deleteBtn.Text = "DELETE";
            this.addTeacher_deleteBtn.UseVisualStyleBackColor = false;
            this.addTeacher_deleteBtn.Click += new System.EventHandler(this.addTeacher_deleteBtn_Click);
            // 
            // addTeacher_clearBtn
            // 
            this.addTeacher_clearBtn.BackColor = System.Drawing.Color.Black;
            this.addTeacher_clearBtn.FlatAppearance.BorderSize = 0;
            this.addTeacher_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacher_clearBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_clearBtn.ForeColor = System.Drawing.Color.White;
            this.addTeacher_clearBtn.Location = new System.Drawing.Point(597, 194);
            this.addTeacher_clearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_clearBtn.Name = "addTeacher_clearBtn";
            this.addTeacher_clearBtn.Size = new System.Drawing.Size(133, 41);
            this.addTeacher_clearBtn.TabIndex = 20;
            this.addTeacher_clearBtn.Text = "CLEAR";
            this.addTeacher_clearBtn.UseVisualStyleBackColor = false;
            this.addTeacher_clearBtn.Click += new System.EventHandler(this.addTeacher_clearBtn_Click);
            // 
            // addTeacher_importBtn
            // 
            this.addTeacher_importBtn.BackColor = System.Drawing.Color.Black;
            this.addTeacher_importBtn.FlatAppearance.BorderSize = 0;
            this.addTeacher_importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacher_importBtn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_importBtn.ForeColor = System.Drawing.Color.White;
            this.addTeacher_importBtn.Location = new System.Drawing.Point(895, 146);
            this.addTeacher_importBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addTeacher_importBtn.Name = "addTeacher_importBtn";
            this.addTeacher_importBtn.Size = new System.Drawing.Size(133, 28);
            this.addTeacher_importBtn.TabIndex = 5;
            this.addTeacher_importBtn.Text = "Import";
            this.addTeacher_importBtn.UseVisualStyleBackColor = false;
            this.addTeacher_importBtn.Click += new System.EventHandler(this.addTeacher_importBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(429, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Gender:";
            // 
            // addTeacher_gender
            // 
            this.addTeacher_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeacher_gender.FormattingEnabled = true;
            this.addTeacher_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.addTeacher_gender.Location = new System.Drawing.Point(514, 88);
            this.addTeacher_gender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addTeacher_gender.Name = "addTeacher_gender";
            this.addTeacher_gender.Size = new System.Drawing.Size(360, 33);
            this.addTeacher_gender.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addTeacher_gender);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.addTeacher_importBtn);
            this.panel1.Controls.Add(this.addTeacher_clearBtn);
            this.panel1.Controls.Add(this.addTeacher_deleteBtn);
            this.panel1.Controls.Add(this.addTeacher_updateBtn);
            this.panel1.Controls.Add(this.addTeacher_addBtn);
            this.panel1.Controls.Add(this.addTeacher_dob);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.addTeacher_imagePicBox);
            this.panel1.Controls.Add(this.addTeacher_cnic);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.addTeacher_address);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addTeacher_name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(28, 411);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 280);
            this.panel1.TabIndex = 4;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(842, 22);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(303, 26);
            this.searchTextBox.TabIndex = 37;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(706, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 21);
            this.label9.TabIndex = 36;
            this.label9.Text = "Search Teacher:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddTeacher";
            this.Size = new System.Drawing.Size(1173, 695);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacher_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacher_imagePicBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView addTeacher_gridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addTeacher_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addTeacher_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addTeacher_cnic;
        private System.Windows.Forms.PictureBox addTeacher_imagePicBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker addTeacher_dob;
        private System.Windows.Forms.Button addTeacher_addBtn;
        private System.Windows.Forms.Button addTeacher_updateBtn;
        private System.Windows.Forms.Button addTeacher_deleteBtn;
        private System.Windows.Forms.Button addTeacher_clearBtn;
        private System.Windows.Forms.Button addTeacher_importBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox addTeacher_gender;
        private System.Windows.Forms.Panel panel1;
        private TextBox searchTextBox;
        private Label label9;
    }
}
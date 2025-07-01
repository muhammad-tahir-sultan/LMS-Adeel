namespace LibraryManagementSystem
{
    partial class Fine
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
            this.dataGridViewFines = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sendEmailBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clearFineBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFines
            // 
            this.dataGridViewFines.AllowUserToAddRows = false;
            this.dataGridViewFines.AllowUserToDeleteRows = false;
            this.dataGridViewFines.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewFines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFines.ColumnHeadersHeight = 34;
            this.dataGridViewFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewFines.EnableHeadersVisualStyles = false;
            this.dataGridViewFines.Location = new System.Drawing.Point(6, 85);
            this.dataGridViewFines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewFines.Name = "dataGridViewFines";
            this.dataGridViewFines.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFines.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFines.RowHeadersVisible = false;
            this.dataGridViewFines.RowHeadersWidth = 62;
            this.dataGridViewFines.Size = new System.Drawing.Size(1511, 728);
            this.dataGridViewFines.TabIndex = 2;
            this.dataGridViewFines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Students Who Has To Pay Fine";
            // 
            // sendEmailBtn
            // 
            this.sendEmailBtn.BackColor = System.Drawing.Color.Black;
            this.sendEmailBtn.FlatAppearance.BorderSize = 0;
            this.sendEmailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendEmailBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendEmailBtn.ForeColor = System.Drawing.Color.White;
            this.sendEmailBtn.Location = new System.Drawing.Point(35, 824);
            this.sendEmailBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendEmailBtn.Name = "sendEmailBtn";
            this.sendEmailBtn.Size = new System.Drawing.Size(342, 72);
            this.sendEmailBtn.TabIndex = 17;
            this.sendEmailBtn.Text = "Send Email";
            this.sendEmailBtn.UseVisualStyleBackColor = false;
            this.sendEmailBtn.Click += new System.EventHandler(this.sendEmailBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dataGridViewFines);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(10, -10);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1525, 820);
            this.panel2.TabIndex = 3;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(1163, 31);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(341, 30);
            this.searchTextBox.TabIndex = 41;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1059, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 24);
            this.label9.TabIndex = 40;
            this.label9.Text = "Search :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clearFineBtn
            // 
            this.clearFineBtn.BackColor = System.Drawing.Color.Black;
            this.clearFineBtn.FlatAppearance.BorderSize = 0;
            this.clearFineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFineBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFineBtn.ForeColor = System.Drawing.Color.White;
            this.clearFineBtn.Location = new System.Drawing.Point(1173, 824);
            this.clearFineBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearFineBtn.Name = "clearFineBtn";
            this.clearFineBtn.Size = new System.Drawing.Size(342, 72);
            this.clearFineBtn.TabIndex = 18;
            this.clearFineBtn.Text = "Clear Fine";
            this.clearFineBtn.UseVisualStyleBackColor = false;
            this.clearFineBtn.Click += new System.EventHandler(this.clearFineBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.Black;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Location = new System.Drawing.Point(604, 824);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(342, 72);
            this.refreshBtn.TabIndex = 19;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click_1);
            // 
            // Fine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.sendEmailBtn);
            this.Controls.Add(this.clearFineBtn);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Fine";
            this.Size = new System.Drawing.Size(1545, 949);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendEmailBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button clearFineBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}
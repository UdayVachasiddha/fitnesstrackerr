namespace fitnesstrackerr
{
    partial class Activity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Activity));
            this.lblMetric1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panelLifting = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panelLifting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMetric1
            // 
            this.lblMetric1.AutoSize = true;
            this.lblMetric1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric1.ForeColor = System.Drawing.Color.White;
            this.lblMetric1.Location = new System.Drawing.Point(40, 166);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Size = new System.Drawing.Size(67, 23);
            this.lblMetric1.TabIndex = 30;
            this.lblMetric1.Text = "Metric1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(39, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 22);
            this.textBox1.TabIndex = 32;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(92, 38);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(184, 28);
            this.label24.TabIndex = 2;
            this.label24.Text = "RECORD ACTIVITY";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(40, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 23);
            this.label23.TabIndex = 4;
            this.label23.Text = "Activity";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(106)))), ((int)(((byte)(115)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(40, 341);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(250, 40);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(27, 24);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // comboBox6
            // 
            this.comboBox6.AllowDrop = true;
            this.comboBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.comboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox6.ForeColor = System.Drawing.Color.White;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "Walking",
            "Swimming",
            "Running",
            "Cycling",
            "Lifting",
            "Yoga"});
            this.comboBox6.Location = new System.Drawing.Point(44, 130);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(159, 24);
            this.comboBox6.TabIndex = 21;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // lblMetric3
            // 
            this.lblMetric3.AutoSize = true;
            this.lblMetric3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric3.ForeColor = System.Drawing.Color.White;
            this.lblMetric3.Location = new System.Drawing.Point(40, 271);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(67, 23);
            this.lblMetric3.TabIndex = 24;
            this.lblMetric3.Text = "Metric3";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(39, 298);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(250, 22);
            this.textBox3.TabIndex = 25;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // lblMetric2
            // 
            this.lblMetric2.AutoSize = true;
            this.lblMetric2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric2.ForeColor = System.Drawing.Color.White;
            this.lblMetric2.Location = new System.Drawing.Point(40, 222);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(67, 23);
            this.lblMetric2.TabIndex = 37;
            this.lblMetric2.Text = "Metric2";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(39, 248);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 22);
            this.textBox2.TabIndex = 38;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // panelLifting
            // 
            this.panelLifting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.panelLifting.Controls.Add(this.textBox2);
            this.panelLifting.Controls.Add(this.lblMetric2);
            this.panelLifting.Controls.Add(this.textBox3);
            this.panelLifting.Controls.Add(this.lblMetric3);
            this.panelLifting.Controls.Add(this.comboBox6);
            this.panelLifting.Controls.Add(this.pictureBox6);
            this.panelLifting.Controls.Add(this.BtnSave);
            this.panelLifting.Controls.Add(this.label23);
            this.panelLifting.Controls.Add(this.label24);
            this.panelLifting.Controls.Add(this.textBox1);
            this.panelLifting.Controls.Add(this.lblMetric1);
            this.panelLifting.ForeColor = System.Drawing.Color.White;
            this.panelLifting.Location = new System.Drawing.Point(389, 55);
            this.panelLifting.Name = "panelLifting";
            this.panelLifting.Size = new System.Drawing.Size(350, 400);
            this.panelLifting.TabIndex = 36;
            // 
            // Activity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1305, 526);
            this.Controls.Add(this.panelLifting);
            this.Name = "Activity";
            this.Text = "Activity";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panelLifting.ResumeLayout(false);
            this.panelLifting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMetric1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panelLifting;
    }
}
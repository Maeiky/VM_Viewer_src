namespace VM_Viewer {
    partial class VM_GUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VM_GUI));
            this.btnLauch = new System.Windows.Forms.Button();
            this.ckbAdmin = new System.Windows.Forms.CheckBox();
            this.btnLocatePath = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.cbDrive = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbOpen = new System.Windows.Forms.CheckBox();
            this.cbFullScreen = new System.Windows.Forms.CheckBox();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.rtOutput = new System.Windows.Forms.RichTextBox();
            this.btConfig = new System.Windows.Forms.Button();
            this.gbFullScreen = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbFullScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLauch
            // 
            this.btnLauch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLauch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLauch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnLauch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLauch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnLauch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLauch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLauch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLauch.Location = new System.Drawing.Point(562, 23);
            this.btnLauch.Name = "btnLauch";
            this.btnLauch.Size = new System.Drawing.Size(103, 39);
            this.btnLauch.TabIndex = 0;
            this.btnLauch.Text = "Lauch";
            this.btnLauch.UseVisualStyleBackColor = false;
            this.btnLauch.Click += new System.EventHandler(this.btnLauch_Click);
            // 
            // ckbAdmin
            // 
            this.ckbAdmin.AutoSize = true;
            this.ckbAdmin.Checked = true;
            this.ckbAdmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAdmin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbAdmin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ckbAdmin.Location = new System.Drawing.Point(20, 10);
            this.ckbAdmin.Name = "ckbAdmin";
            this.ckbAdmin.Size = new System.Drawing.Size(102, 18);
            this.ckbAdmin.TabIndex = 1;
            this.ckbAdmin.Text = "Run as Admin";
            this.ckbAdmin.UseVisualStyleBackColor = true;
            this.ckbAdmin.Visible = false;
            // 
            // btnLocatePath
            // 
            this.btnLocatePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocatePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLocatePath.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnLocatePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLocatePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnLocatePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocatePath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocatePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLocatePath.Location = new System.Drawing.Point(503, 34);
            this.btnLocatePath.Name = "btnLocatePath";
            this.btnLocatePath.Size = new System.Drawing.Size(40, 21);
            this.btnLocatePath.TabIndex = 3;
            this.btnLocatePath.Text = "...";
            this.btnLocatePath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocatePath.UseVisualStyleBackColor = false;
            this.btnLocatePath.Click += new System.EventHandler(this.btnLocatePath_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Location = new System.Drawing.Point(562, 106);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 39);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Drive";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbPath
            // 
            this.cbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPath.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPath.ForeColor = System.Drawing.SystemColors.Info;
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Location = new System.Drawing.Point(12, 34);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(485, 21);
            this.cbPath.TabIndex = 5;
            this.cbPath.TextChanged += new System.EventHandler(this.cbPath_TextChanged);
            // 
            // cbDrive
            // 
            this.cbDrive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDrive.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDrive.ForeColor = System.Drawing.SystemColors.Info;
            this.cbDrive.FormattingEnabled = true;
            this.cbDrive.Location = new System.Drawing.Point(12, 106);
            this.cbDrive.Name = "cbDrive";
            this.cbDrive.Size = new System.Drawing.Size(485, 21);
            this.cbDrive.TabIndex = 6;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(541, 451);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 18);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "V·Liance Team";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbOpen
            // 
            this.cbOpen.AutoSize = true;
            this.cbOpen.Checked = true;
            this.cbOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOpen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbOpen.Location = new System.Drawing.Point(20, 133);
            this.cbOpen.Name = "cbOpen";
            this.cbOpen.Size = new System.Drawing.Size(110, 18);
            this.cbOpen.TabIndex = 8;
            this.cbOpen.Text = "Open on Mount";
            this.cbOpen.UseVisualStyleBackColor = true;
            // 
            // cbFullScreen
            // 
            this.cbFullScreen.AutoSize = true;
            this.cbFullScreen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFullScreen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFullScreen.Location = new System.Drawing.Point(20, 61);
            this.cbFullScreen.Name = "cbFullScreen";
            this.cbFullScreen.Size = new System.Drawing.Size(121, 18);
            this.cbFullScreen.TabIndex = 10;
            this.cbFullScreen.Text = "Full Screen Mode";
            this.cbFullScreen.UseVisualStyleBackColor = true;
            this.cbFullScreen.CheckedChanged += new System.EventHandler(this.cbFullScreen_CheckedChanged);
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btPause.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPause.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPause.ForeColor = System.Drawing.SystemColors.Control;
            this.btPause.Location = new System.Drawing.Point(316, 16);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(103, 39);
            this.btPause.TabIndex = 11;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = false;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btStop.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStop.ForeColor = System.Drawing.SystemColors.Control;
            this.btStop.Location = new System.Drawing.Point(428, 16);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(103, 39);
            this.btStop.TabIndex = 12;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // rtOutput
            // 
            this.rtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtOutput.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtOutput.ForeColor = System.Drawing.SystemColors.Info;
            this.rtOutput.Location = new System.Drawing.Point(12, 238);
            this.rtOutput.Name = "rtOutput";
            this.rtOutput.ReadOnly = true;
            this.rtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtOutput.Size = new System.Drawing.Size(653, 231);
            this.rtOutput.TabIndex = 9;
            this.rtOutput.Text = "";
            this.rtOutput.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btConfig
            // 
            this.btConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btConfig.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfig.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfig.ForeColor = System.Drawing.SystemColors.Control;
            this.btConfig.Location = new System.Drawing.Point(540, 16);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(103, 39);
            this.btConfig.TabIndex = 13;
            this.btConfig.Text = "Config";
            this.btConfig.UseVisualStyleBackColor = false;
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // gbFullScreen
            // 
            this.gbFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFullScreen.Controls.Add(this.btnReset);
            this.gbFullScreen.Controls.Add(this.btConfig);
            this.gbFullScreen.Controls.Add(this.btStop);
            this.gbFullScreen.Controls.Add(this.btPause);
            this.gbFullScreen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFullScreen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbFullScreen.Location = new System.Drawing.Point(12, 169);
            this.gbFullScreen.Name = "gbFullScreen";
            this.gbFullScreen.Size = new System.Drawing.Size(653, 63);
            this.gbFullScreen.TabIndex = 15;
            this.gbFullScreen.TabStop = false;
            this.gbFullScreen.Text = "FullScreen Mode";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(207, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 39);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // VM_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(677, 480);
            this.Controls.Add(this.cbFullScreen);
            this.Controls.Add(this.cbOpen);
            this.Controls.Add(this.cbDrive);
            this.Controls.Add(this.cbPath);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLocatePath);
            this.Controls.Add(this.ckbAdmin);
            this.Controls.Add(this.btnLauch);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rtOutput);
            this.Controls.Add(this.gbFullScreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VM_GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VM·Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VM_GUI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VM_GUI_FormClosed);
            this.Load += new System.EventHandler(this.VM_GUI_Load);
            this.ResizeEnd += new System.EventHandler(this.VM_GUI_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.VM_GUI_SizeChanged);
            this.Move += new System.EventHandler(this.VM_GUI_Move);
            this.Resize += new System.EventHandler(this.VM_GUI_Resize);
            this.gbFullScreen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLauch;
        private System.Windows.Forms.CheckBox ckbAdmin;
        private System.Windows.Forms.Button btnLocatePath;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbPath;
        private System.Windows.Forms.ComboBox cbDrive;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cbOpen;
        private System.Windows.Forms.CheckBox cbFullScreen;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.RichTextBox rtOutput;
        private System.Windows.Forms.Button btConfig;
        private System.Windows.Forms.GroupBox gbFullScreen;
        private System.Windows.Forms.Button btnReset;
    }
}


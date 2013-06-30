namespace DocumentAuthorChanger
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.selectDirButton = new System.Windows.Forms.Button();
			this.folderBox = new System.Windows.Forms.TextBox();
			this.folderGroup = new System.Windows.Forms.GroupBox();
			this.countLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.logBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.keepLastModifiedBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.applyButton = new System.Windows.Forms.Button();
			this.authorBox = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.folderGroup.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectDirButton
			// 
			this.selectDirButton.Location = new System.Drawing.Point(447, 19);
			this.selectDirButton.Name = "selectDirButton";
			this.selectDirButton.Size = new System.Drawing.Size(75, 23);
			this.selectDirButton.TabIndex = 0;
			this.selectDirButton.Text = "Select";
			this.selectDirButton.UseVisualStyleBackColor = true;
			this.selectDirButton.Click += new System.EventHandler(this.selectDirButton_Click);
			// 
			// folderBox
			// 
			this.folderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.folderBox.Location = new System.Drawing.Point(6, 21);
			this.folderBox.Name = "folderBox";
			this.folderBox.ReadOnly = true;
			this.folderBox.Size = new System.Drawing.Size(435, 20);
			this.folderBox.TabIndex = 1;
			this.folderBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// folderGroup
			// 
			this.folderGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.folderGroup.Controls.Add(this.countLabel);
			this.folderGroup.Controls.Add(this.folderBox);
			this.folderGroup.Controls.Add(this.selectDirButton);
			this.folderGroup.Location = new System.Drawing.Point(12, 12);
			this.folderGroup.Name = "folderGroup";
			this.folderGroup.Size = new System.Drawing.Size(528, 67);
			this.folderGroup.TabIndex = 2;
			this.folderGroup.TabStop = false;
			this.folderGroup.Text = "Document file directory";
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Location = new System.Drawing.Point(6, 44);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(61, 13);
			this.countLabel.TabIndex = 2;
			this.countLabel.Text = "- files found";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.logBox);
			this.groupBox2.Location = new System.Drawing.Point(12, 248);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(528, 126);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Log";
			// 
			// logBox
			// 
			this.logBox.BackColor = System.Drawing.Color.White;
			this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logBox.Location = new System.Drawing.Point(3, 16);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.ReadOnly = true;
			this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logBox.Size = new System.Drawing.Size(522, 107);
			this.logBox.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.progressBar);
			this.groupBox3.Controls.Add(this.cancelButton);
			this.groupBox3.Controls.Add(this.keepLastModifiedBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.applyButton);
			this.groupBox3.Controls.Add(this.authorBox);
			this.groupBox3.Location = new System.Drawing.Point(12, 85);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(258, 157);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "New Author";
			// 
			// keepLastModifiedBox
			// 
			this.keepLastModifiedBox.AutoSize = true;
			this.keepLastModifiedBox.Checked = true;
			this.keepLastModifiedBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.keepLastModifiedBox.Location = new System.Drawing.Point(54, 45);
			this.keepLastModifiedBox.Name = "keepLastModifiedBox";
			this.keepLastModifiedBox.Size = new System.Drawing.Size(186, 17);
			this.keepLastModifiedBox.TabIndex = 3;
			this.keepLastModifiedBox.Text = "Keep \'last modified\' property intact";
			this.keepLastModifiedBox.UseVisualStyleBackColor = true;
			this.keepLastModifiedBox.CheckedChanged += new System.EventHandler(this.keepLastModifiedBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Author:";
			// 
			// applyButton
			// 
			this.applyButton.Enabled = false;
			this.applyButton.Location = new System.Drawing.Point(177, 68);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(75, 23);
			this.applyButton.TabIndex = 1;
			this.applyButton.Text = "Apply to all";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// authorBox
			// 
			this.authorBox.Location = new System.Drawing.Point(54, 19);
			this.authorBox.Name = "authorBox";
			this.authorBox.Size = new System.Drawing.Size(198, 20);
			this.authorBox.TabIndex = 0;
			this.authorBox.TextChanged += new System.EventHandler(this.authorBox_TextChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Location = new System.Drawing.Point(276, 85);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(264, 157);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "About";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(258, 138);
			this.label3.TabIndex = 0;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(177, 97);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Visible = false;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(6, 128);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(246, 23);
			this.progressBar.TabIndex = 5;
			this.progressBar.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 386);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.folderGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Document Author Changer";
			this.folderGroup.ResumeLayout(false);
			this.folderGroup.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button selectDirButton;
		private System.Windows.Forms.TextBox folderBox;
		private System.Windows.Forms.GroupBox folderGroup;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox keepLastModifiedBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.TextBox authorBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox logBox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button cancelButton;
	}
}


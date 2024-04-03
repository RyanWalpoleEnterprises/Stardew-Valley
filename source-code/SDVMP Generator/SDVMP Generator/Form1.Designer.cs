
namespace SDVMP_Generator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Create = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.LearnMoreLink = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.Cancelquit = new System.Windows.Forms.Button();
            this.folderlist = new System.Windows.Forms.ListBox();
            this.Operation1 = new System.ComponentModel.BackgroundWorker();
            this.Operation2 = new System.ComponentModel.BackgroundWorker();
            this.ProgressWorker = new System.Windows.Forms.ProgressBar();
            this.IniWrite = new System.Windows.Forms.RichTextBox();
            this.TargetSMAPIVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddMod = new System.Windows.Forms.ToolStripButton();
            this.RemoveMod = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a Modpack";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Use this tool to generate a Stardew Valley Modpack that can be distributed and in" +
    "stalled with just a few clicks using the Stardew Valley Mod Manager.";
            // 
            // Create
            // 
            this.Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Create.Location = new System.Drawing.Point(376, 476);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(111, 30);
            this.Create.TabIndex = 6;
            this.Create.Text = "Create Modpack";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "Mods";
            // 
            // LearnMoreLink
            // 
            this.LearnMoreLink.ActiveLinkColor = System.Drawing.Color.Blue;
            this.LearnMoreLink.AutoSize = true;
            this.LearnMoreLink.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.LearnMoreLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LearnMoreLink.Location = new System.Drawing.Point(130, 77);
            this.LearnMoreLink.Name = "LearnMoreLink";
            this.LearnMoreLink.Size = new System.Drawing.Size(67, 15);
            this.LearnMoreLink.TabIndex = 16;
            this.LearnMoreLink.TabStop = true;
            this.LearnMoreLink.Text = "Learn More";
            this.LearnMoreLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LearnMoreLink_LinkClicked);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(16, 485);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Version 230201 (Beta)";
            // 
            // Cancelquit
            // 
            this.Cancelquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelquit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelquit.Location = new System.Drawing.Point(259, 476);
            this.Cancelquit.Name = "Cancelquit";
            this.Cancelquit.Size = new System.Drawing.Size(111, 30);
            this.Cancelquit.TabIndex = 5;
            this.Cancelquit.Text = "Cancel + Exit";
            this.Cancelquit.UseVisualStyleBackColor = true;
            this.Cancelquit.Click += new System.EventHandler(this.Cancelquit_Click);
            // 
            // folderlist
            // 
            this.folderlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderlist.FormattingEnabled = true;
            this.folderlist.Location = new System.Drawing.Point(17, 183);
            this.folderlist.Name = "folderlist";
            this.folderlist.Size = new System.Drawing.Size(470, 199);
            this.folderlist.TabIndex = 18;
            this.folderlist.SelectedIndexChanged += new System.EventHandler(this.folderlist_SelectedIndexChanged);
            // 
            // Operation1
            // 
            this.Operation1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Operation1_DoWork);
            this.Operation1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Operation1_RunWorkerCompleted);
            // 
            // Operation2
            // 
            this.Operation2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Operation2_DoWork);
            this.Operation2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Operation2_RunWorkerCompleted);
            // 
            // ProgressWorker
            // 
            this.ProgressWorker.Location = new System.Drawing.Point(17, 476);
            this.ProgressWorker.Name = "ProgressWorker";
            this.ProgressWorker.Size = new System.Drawing.Size(470, 30);
            this.ProgressWorker.Step = 50;
            this.ProgressWorker.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressWorker.TabIndex = 20;
            this.ProgressWorker.Value = 50;
            this.ProgressWorker.Visible = false;
            // 
            // IniWrite
            // 
            this.IniWrite.Location = new System.Drawing.Point(387, 183);
            this.IniWrite.Name = "IniWrite";
            this.IniWrite.Size = new System.Drawing.Size(100, 84);
            this.IniWrite.TabIndex = 22;
            this.IniWrite.Text = "";
            this.IniWrite.Visible = false;
            // 
            // TargetSMAPIVersion
            // 
            this.TargetSMAPIVersion.Location = new System.Drawing.Point(143, 432);
            this.TargetSMAPIVersion.Name = "TargetSMAPIVersion";
            this.TargetSMAPIVersion.Size = new System.Drawing.Size(146, 20);
            this.TargetSMAPIVersion.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "SMAPI";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label4.Location = new System.Drawing.Point(14, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Target SMAPI Version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SDVMP_Generator.Properties.Resources.SDVMPIcon;
            this.pictureBox1.Location = new System.Drawing.Point(414, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::SDVMP_Generator.Properties.Resources.white;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMod,
            this.RemoveMod});
            this.toolStrip1.Location = new System.Drawing.Point(17, 146);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(470, 26);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddMod
            // 
            this.AddMod.Image = global::SDVMP_Generator.Properties.Resources.icons8_add_48;
            this.AddMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddMod.Name = "AddMod";
            this.AddMod.Size = new System.Drawing.Size(77, 23);
            this.AddMod.Text = "Add Mod";
            this.AddMod.Click += new System.EventHandler(this.AddMod_Click);
            // 
            // RemoveMod
            // 
            this.RemoveMod.Enabled = false;
            this.RemoveMod.Image = global::SDVMP_Generator.Properties.Resources.sdvDelete;
            this.RemoveMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveMod.Name = "RemoveMod";
            this.RemoveMod.Size = new System.Drawing.Size(120, 23);
            this.RemoveMod.Text = "Remove from List";
            this.RemoveMod.Click += new System.EventHandler(this.RemoveMod_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.Cancelquit;
            this.ClientSize = new System.Drawing.Size(504, 544);
            this.ControlBox = false;
            this.Controls.Add(this.folderlist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TargetSMAPIVersion);
            this.Controls.Add(this.IniWrite);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ProgressWorker);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Cancelquit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LearnMoreLink);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(520, 485);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modpack Compiler | Stardew Valley Modded Framework";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel LearnMoreLink;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Cancelquit;
        private System.Windows.Forms.ListBox folderlist;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddMod;
        private System.Windows.Forms.ToolStripButton RemoveMod;
        private System.ComponentModel.BackgroundWorker Operation1;
        private System.ComponentModel.BackgroundWorker Operation2;
        private System.Windows.Forms.ProgressBar ProgressWorker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox IniWrite;
        private System.Windows.Forms.TextBox TargetSMAPIVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}


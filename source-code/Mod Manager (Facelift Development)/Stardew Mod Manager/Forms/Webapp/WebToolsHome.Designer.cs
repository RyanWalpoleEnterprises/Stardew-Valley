namespace Stardew_Mod_Manager.Forms.Webapp
{
    partial class WebToolsHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebToolsHome));
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Back = new System.Windows.Forms.ToolStripButton();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Refresh = new System.Windows.Forms.ToolStripButton();
            this.Forward = new System.Windows.Forms.ToolStripButton();
            this.StatusButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IgnoreWarning = new System.Windows.Forms.CheckBox();
            this.WarningReturn = new Syncfusion.WinForms.Controls.SfButton();
            this.ContinueWarning = new Syncfusion.WinForms.Controls.SfButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WarningPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.WarningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 40);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(800, 582);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            this.webView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView_NavigationCompleted);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(30, 2, 2, 2);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Back,
            this.Home,
            this.Refresh,
            this.Forward,
            this.StatusButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(800, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Back
            // 
            this.Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Back.Enabled = false;
            this.Back.Image = global::Stardew_Mod_Manager.Properties.Resources.WTBack;
            this.Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Back.Name = "Back";
            this.Back.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Back.Size = new System.Drawing.Size(49, 38);
            this.Back.Text = "Back";
            this.Back.ToolTipText = "Back";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Home
            // 
            this.Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Home.Image = global::Stardew_Mod_Manager.Properties.Resources.WTHome;
            this.Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Home.Size = new System.Drawing.Size(49, 38);
            this.Home.Text = "Home";
            this.Home.ToolTipText = "Home";
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Refresh
            // 
            this.Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh.Image = global::Stardew_Mod_Manager.Properties.Resources.WTRefresh;
            this.Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh.Name = "Refresh";
            this.Refresh.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Refresh.Size = new System.Drawing.Size(49, 38);
            this.Refresh.Text = "Refresh";
            this.Refresh.ToolTipText = "Refresh";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Forward
            // 
            this.Forward.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Forward.Enabled = false;
            this.Forward.Image = global::Stardew_Mod_Manager.Properties.Resources.WTForward;
            this.Forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Forward.Name = "Forward";
            this.Forward.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Forward.Size = new System.Drawing.Size(49, 38);
            this.Forward.Text = "Forward";
            this.Forward.ToolTipText = "Forward";
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // StatusButton
            // 
            this.StatusButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusButton.Image = global::Stardew_Mod_Manager.Properties.Resources.sdvWTWarning;
            this.StatusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.StatusButton.Size = new System.Drawing.Size(49, 38);
            this.StatusButton.Text = "Warning";
            this.StatusButton.ToolTipText = "Warning: You are currently viewing a website that is not owned or operated by RWE" +
    " Labs.";
            this.StatusButton.Visible = false;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IgnoreWarning);
            this.panel1.Controls.Add(this.WarningReturn);
            this.panel1.Controls.Add(this.ContinueWarning);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(11, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 339);
            this.panel1.TabIndex = 2;
            // 
            // IgnoreWarning
            // 
            this.IgnoreWarning.AutoSize = true;
            this.IgnoreWarning.Location = new System.Drawing.Point(106, 293);
            this.IgnoreWarning.Name = "IgnoreWarning";
            this.IgnoreWarning.Size = new System.Drawing.Size(181, 17);
            this.IgnoreWarning.TabIndex = 5;
            this.IgnoreWarning.Text = "Always ignore this safety warning";
            this.IgnoreWarning.UseVisualStyleBackColor = true;
            // 
            // WarningReturn
            // 
            this.WarningReturn.AccessibleName = "Button";
            this.WarningReturn.BackColor = System.Drawing.Color.Gainsboro;
            this.WarningReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.WarningReturn.ForeColor = System.Drawing.Color.Black;
            this.WarningReturn.Location = new System.Drawing.Point(106, 239);
            this.WarningReturn.Name = "WarningReturn";
            this.WarningReturn.Size = new System.Drawing.Size(134, 28);
            this.WarningReturn.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.WarningReturn.Style.ForeColor = System.Drawing.Color.Black;
            this.WarningReturn.TabIndex = 4;
            this.WarningReturn.Text = "Return to Safety";
            this.WarningReturn.UseVisualStyleBackColor = false;
            this.WarningReturn.Click += new System.EventHandler(this.WarningReturn_Click);
            // 
            // ContinueWarning
            // 
            this.ContinueWarning.AccessibleName = "Button";
            this.ContinueWarning.BackColor = System.Drawing.Color.Silver;
            this.ContinueWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.ContinueWarning.ForeColor = System.Drawing.Color.Black;
            this.ContinueWarning.Location = new System.Drawing.Point(246, 239);
            this.ContinueWarning.Name = "ContinueWarning";
            this.ContinueWarning.Size = new System.Drawing.Size(136, 28);
            this.ContinueWarning.Style.BackColor = System.Drawing.Color.Silver;
            this.ContinueWarning.Style.ForeColor = System.Drawing.Color.Black;
            this.ContinueWarning.TabIndex = 3;
            this.ContinueWarning.Text = "Continue";
            this.ContinueWarning.UseVisualStyleBackColor = false;
            this.ContinueWarning.Click += new System.EventHandler(this.ContinueWarning_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(103, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 161);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(101, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Warning";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stardew_Mod_Manager.Properties.Resources.sdvWTWarning;
            this.pictureBox1.Location = new System.Drawing.Point(25, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WarningPanel
            // 
            this.WarningPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WarningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WarningPanel.Controls.Add(this.panel1);
            this.WarningPanel.ForeColor = System.Drawing.Color.DimGray;
            this.WarningPanel.Location = new System.Drawing.Point(0, 41);
            this.WarningPanel.Name = "WarningPanel";
            this.WarningPanel.Size = new System.Drawing.Size(800, 581);
            this.WarningPanel.TabIndex = 3;
            this.WarningPanel.Visible = false;
            // 
            // WebToolsHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 622);
            this.Controls.Add(this.WarningPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.webView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WebToolsHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stardew Valley Web Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WebToolsHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.WarningPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Back;
        private System.Windows.Forms.ToolStripButton Refresh;
        private System.Windows.Forms.ToolStripButton Forward;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton StatusButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel WarningPanel;
        private Syncfusion.WinForms.Controls.SfButton ContinueWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.WinForms.Controls.SfButton WarningReturn;
        private System.Windows.Forms.CheckBox IgnoreWarning;
    }
}
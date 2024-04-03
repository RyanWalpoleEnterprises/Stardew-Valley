namespace Stardew_Mod_Manager.Forms
{
    partial class TelemetryOnboarding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelemetryOnboarding));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AllowTelemetry = new Syncfusion.WinForms.Controls.SfButton();
            this.DenyTelemetry = new Syncfusion.WinForms.Controls.SfButton();
            this.ViewTelemetryPolicy = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stardew_Mod_Manager.Properties.Resources.SDVTelemetryTask;
            this.pictureBox1.Location = new System.Drawing.Point(16, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Improve Stardew Valley Mod Manager";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(196, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 58);
            this.label2.TabIndex = 2;
            this.label2.Text = "RWE Labs can benefit by seeing how you use the Stardew Valley Mod Manager and it\'" +
    "s features. This data can help show us what features we should focus on and what" +
    " needs fixing.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(195, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Here\'s an example of what you might be sending us";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(199, 150);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(374, 182);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(196, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 97);
            this.label4.TabIndex = 5;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // AllowTelemetry
            // 
            this.AllowTelemetry.AccessibleName = "Button";
            this.AllowTelemetry.CanApplyTheme = false;
            this.AllowTelemetry.CanOverrideStyle = true;
            this.AllowTelemetry.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.AllowTelemetry.Location = new System.Drawing.Point(456, 455);
            this.AllowTelemetry.Name = "AllowTelemetry";
            this.AllowTelemetry.Size = new System.Drawing.Size(117, 28);
            this.AllowTelemetry.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.AllowTelemetry.Style.DisabledForeColor = System.Drawing.Color.RoyalBlue;
            this.AllowTelemetry.Style.FocusedBackColor = System.Drawing.Color.RoyalBlue;
            this.AllowTelemetry.Style.FocusedForeColor = System.Drawing.Color.White;
            this.AllowTelemetry.Style.ForeColor = System.Drawing.Color.White;
            this.AllowTelemetry.Style.HoverBackColor = System.Drawing.Color.MidnightBlue;
            this.AllowTelemetry.Style.HoverForeColor = System.Drawing.Color.White;
            this.AllowTelemetry.Style.PressedBackColor = System.Drawing.Color.MidnightBlue;
            this.AllowTelemetry.Style.PressedForeColor = System.Drawing.Color.White;
            this.AllowTelemetry.TabIndex = 6;
            this.AllowTelemetry.Text = "Allow";
            this.AllowTelemetry.Click += new System.EventHandler(this.AllowTelemetry_Click);
            // 
            // DenyTelemetry
            // 
            this.DenyTelemetry.AccessibleName = "Button";
            this.DenyTelemetry.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.DenyTelemetry.Location = new System.Drawing.Point(333, 455);
            this.DenyTelemetry.Name = "DenyTelemetry";
            this.DenyTelemetry.Size = new System.Drawing.Size(117, 28);
            this.DenyTelemetry.TabIndex = 7;
            this.DenyTelemetry.Text = "Deny";
            this.DenyTelemetry.Click += new System.EventHandler(this.DenyTelemetry_Click);
            // 
            // ViewTelemetryPolicy
            // 
            this.ViewTelemetryPolicy.AutoSize = true;
            this.ViewTelemetryPolicy.Location = new System.Drawing.Point(37, 173);
            this.ViewTelemetryPolicy.Name = "ViewTelemetryPolicy";
            this.ViewTelemetryPolicy.Size = new System.Drawing.Size(110, 13);
            this.ViewTelemetryPolicy.TabIndex = 8;
            this.ViewTelemetryPolicy.TabStop = true;
            this.ViewTelemetryPolicy.Text = "View Telemetry Policy";
            this.ViewTelemetryPolicy.Click += new System.EventHandler(this.ViewTelemetryPolicy_Click);
            // 
            // TelemetryOnboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 510);
            this.Controls.Add(this.ViewTelemetryPolicy);
            this.Controls.Add(this.DenyTelemetry);
            this.Controls.Add(this.AllowTelemetry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelemetryOnboarding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telemetry | Stardew Valley Mod Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private Syncfusion.WinForms.Controls.SfButton AllowTelemetry;
        private Syncfusion.WinForms.Controls.SfButton DenyTelemetry;
        private System.Windows.Forms.LinkLabel ViewTelemetryPolicy;
    }
}
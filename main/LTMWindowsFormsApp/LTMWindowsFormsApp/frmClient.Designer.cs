namespace LTMWindowsFormsApp
{
    partial class frmClient
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnConnectAndWatch = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Size = new System.Drawing.Size(550, 70);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 18);
            this.lblTitle.Text = "CLIENT CONNECTOR";

            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIP.ForeColor = System.Drawing.Color.Gray;
            this.lblIP.Location = new System.Drawing.Point(35, 95);
            this.lblIP.Text = "SERVER ADDRESS";

            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtIP.Location = new System.Drawing.Point(38, 120);
            this.txtIP.Size = new System.Drawing.Size(470, 32);
            this.txtIP.Text = "127.0.0.1";

            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPath.ForeColor = System.Drawing.Color.Gray;
            this.lblPath.Location = new System.Drawing.Point(35, 175);
            this.lblPath.Text = "SYNC FOLDER PATH";

            this.txtFolderPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFolderPath.Location = new System.Drawing.Point(38, 200);
            this.txtFolderPath.Size = new System.Drawing.Size(470, 32);

            this.btnConnectAndWatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(168)))), ((int)(((byte)(83)))));
            this.btnConnectAndWatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnectAndWatch.FlatAppearance.BorderSize = 0;
            this.btnConnectAndWatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectAndWatch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConnectAndWatch.ForeColor = System.Drawing.Color.White;
            this.btnConnectAndWatch.Location = new System.Drawing.Point(38, 265);
            this.btnConnectAndWatch.Size = new System.Drawing.Size(470, 50);
            this.btnConnectAndWatch.Text = "ESTABLISH CONNECTION";
            this.btnConnectAndWatch.UseVisualStyleBackColor = false;
            this.btnConnectAndWatch.Click += new System.EventHandler(this.btnConnectAndWatch_Click);

            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LTM Sync Client";
            this.notifyIcon1.Visible = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 360);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnConnectAndWatch);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.txtIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnConnectAndWatch;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPath;
    }
}
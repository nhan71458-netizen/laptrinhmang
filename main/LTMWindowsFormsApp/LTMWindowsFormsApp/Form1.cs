using System;
using System.Drawing;
using System.Windows.Forms;

namespace LTMWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Opacity = 0;
            Timer timer = new Timer { Interval = 10 };
            timer.Tick += (s, args) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else timer.Stop();
            };
            timer.Start();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {

            frmServer serverWindow = new frmServer();


            serverWindow.FormClosed += (s, args) => this.Show();

            serverWindow.Show();
            this.Hide();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            frmClient clientWindow = new frmClient();

            clientWindow.FormClosed += (s, args) => this.Show();

            clientWindow.Show();
            this.Hide();
        }

    }
}
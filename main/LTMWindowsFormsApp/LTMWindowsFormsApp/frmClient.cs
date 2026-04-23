using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LTMWindowsFormsApp
{
    public partial class frmClient : Form
    {
        private Socket clientSocket;
        private FileSystemWatcher watcher;

        public frmClient()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            notifyIcon1.Text = "Ứng dụng Giám sát Thư mục";
        }

        private void btnConnectAndWatch_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string path = txtFolderPath.Text.Trim();

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Thư mục không tồn tại!");
                return;
            }

            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 5000);
                clientSocket.Connect(ep);

                btnConnectAndWatch.Enabled = false;
                btnConnectAndWatch.Text = "MONITORING ACTIVE";
                btnConnectAndWatch.BackColor = Color.FromArgb(45, 52, 54);

                StartWatching(path);
                this.Hide();

                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000, "Thông báo", "Ứng dụng đang chạy ngầm và giám sát thư mục.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void StartWatching(string path)
        {
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName |
                                   NotifyFilters.LastWrite | NotifyFilters.Size;
            watcher.IncludeSubdirectories = true;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = $"Sự kiện: {e.ChangeType} | File: {e.Name}";
            SendToServer(message);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string message = $"Sự kiện: Renamed | Cũ: {e.OldName} -> Mới: {e.Name}";
            SendToServer(message);
        }

        private void SendToServer(string message)
        {
            try
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    clientSocket.Send(data);
                }
            }
            catch
            {
                if (watcher != null) watcher.EnableRaisingEvents = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                }

                if (clientSocket != null)
                {
                    if (clientSocket.Connected) clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch { }
            finally
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
                Environment.Exit(0);
            }
        }

        private void frmClient_Load(object sender, EventArgs e) { }
    }
}
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMWindowsFormsApp
{
    public partial class frmServer : Form
    {
        private Socket serverSocket;
        private bool isListening = false;
        private string logFilePath = "ServerLogs.txt";

        public frmServer()
        {
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Trạng thái: Sẵn sàng";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 5000);

                try
                {
                    serverSocket.Bind(ep);
                    serverSocket.Listen(10);
                    isListening = true;

                    lblStatus.Text = "Trạng thái: Đang lắng nghe ở port 5000...";
                    lblStatus.ForeColor = Color.FromArgb(52, 168, 83);

                    btnStart.Enabled = false;
                    btnStart.Text = "SERVER ONLINE";
                    btnStart.BackColor = Color.FromArgb(52, 168, 83);

                    UpdateLog("Server đã khởi động");
                    Task.Run(() => AcceptClients());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khởi tạo Server: " + ex.Message);
                }
            }
        }

        private void AcceptClients()
        {
            while (isListening)
            {
                try
                {
                    Socket clientSocket = serverSocket.Accept();
                    UpdateLog("Client mới đã kết nối");
                    Task.Run(() => ReceiveData(clientSocket));
                }
                catch { }
            }
        }

        private void ReceiveData(Socket client)
        {
            byte[] buffer = new byte[1024 * 5];
            while (true)
            {
                try
                {
                    int receivedBytes = client.Receive(buffer);
                    if (receivedBytes == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    UpdateLog(message);
                    SaveLogToFile(message);
                }
                catch
                {
                    UpdateLog("Client đã ngắt kết nối");
                    break;
                }
            }
            client.Close();
        }

        private void UpdateLog(string msg)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => UpdateLog(msg)));
                return;
            }

            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionColor = Color.LimeGreen;
            rtbLog.AppendText($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ");

            rtbLog.SelectionColor = Color.White;
            rtbLog.AppendText($"{msg}{Environment.NewLine}");
            rtbLog.ScrollToCaret();
        }

        private void SaveLogToFile(string msg)
        {
            try
            {
                string logLine = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {msg}\n";
                File.AppendAllText(logFilePath, logLine);
            }
            catch { }
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            serverSocket?.Close();
        }

        private void lblStatus_Click(object sender, EventArgs e) { }
    }
}
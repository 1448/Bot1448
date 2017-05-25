using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Installer
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }

        public void CreateConfig()
        {
            Task.Factory.StartNew(() =>
            {
                #region Rename files
                Info("Moving files...");
                Thread.Sleep(500);
                File.Copy(Application.ExecutablePath, Application.StartupPath + "\\Bot1448\\update.exe");
                File.Move(Application.StartupPath + "\\Bot1448\\BOT_TEMP.bin", Application.StartupPath + "\\Bot1448\\Bot1448.exe");
                Directory.CreateDirectory(Application.StartupPath + "\\Bot1448\\config");
                #endregion

                #region Set up config files 
                Info("Fetching version info...");
                Thread.Sleep(500);
                string version;
                using (var br = new BinaryReader(new WebClient().OpenRead("http://1448.co.nf/ee/botversion.dat")))
                {
                    version = br.ReadString();
                }
                using (var bw = new BinaryWriter(File.Open(Application.StartupPath + "\\Bot1448\\config\\version.dat", FileMode.Create)))
                {
                    bw.Write(version);
                }
                if (chkDark.Checked)
                {
                    Info("Creating theme file...");
                    Thread.Sleep(500);
                    using (BinaryWriter bw = new BinaryWriter(File.Create(Application.StartupPath + "\\Bot1448\\config\\theme.dat")))
                    {
                        bw.Write("[Dark]");
                        bw.Write(17);
                        bw.Write(17);
                        bw.Write(17);
                        bw.Write(255);
                        bw.Write(223);
                        bw.Write(0);
                        bw.Write(28);
                        bw.Write(28);
                        bw.Write(28);
                        bw.Write(107);
                        bw.Write(208);
                        bw.Write(255);
                        bw.Write(135);
                        bw.Write(0);
                        bw.Write(255);
                        bw.Write(255);
                        bw.Write(255);
                        bw.Write(255);
                        bw.Write("https://vgy.me/PmNl33.png");
                    }
                }
                File.Create(Application.StartupPath + "\\config\\installer");
                #endregion

                Info("And, we're done!");
                MessageBox.Show("Successfully downloaded Bot1448 onto your computer!", "Bot1448 > Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        public void UpdateConfig(string cloudVer)
        {
            File.Delete(Application.StartupPath + "\\Bot1448.exe");
            File.Move(Application.StartupPath + "\\bot.bin", Application.StartupPath + "\\Bot1448.exe");
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\config\\version.dat", FileMode.Create)))
                {
                    bw.Write(cloudVer);
                }
            }
            catch
            {
                Directory.CreateDirectory(Application.StartupPath + "\\config");
                File.Create(Application.StartupPath + "\\config\\version.dat");
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\config\\version.dat", FileMode.Create)))
                {
                    bw.Write(cloudVer);
                }
            }
            Info("Download complete!");
            Process.Start(Application.StartupPath + "\\Bot1448.exe");
            this.Close();
        }

        public void Info(string text)
        {
            lblInfo.Text = text;
        }

        private void btnStart_Click(object sender, EventArgs ev)
        {
            #region Update
            if (File.Exists(Application.StartupPath + "\\Bot1448.exe"))
            {
                string cloudVer, currentVer;
                using (var br = new BinaryReader(new WebClient().OpenRead("http://1448.co.nf/ee/botversion.dat")))
                {
                    cloudVer = br.ReadString();
                }
                using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\config\\version.dat", FileMode.Open)))
                {
                    currentVer = br.ReadString();
                }
                if (cloudVer != currentVer)
                {
                    Info("Updating Bot1448 to v" + cloudVer);
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += (s, e) =>
                    {
                        Info(e.ProgressPercentage + "% complete");
                    };
                    webClient.DownloadFileCompleted += (s, e) =>
                    {
                        webClient.Dispose();
                        UpdateConfig(cloudVer);
                    };
                    webClient.DownloadFileAsync(new Uri("http://1448.co.nf/ee/bot.bin"), Application.StartupPath + "\\bot.bin");
                }
                else
                {
                    MessageBox.Show("Bot1448 is already at the latest version.", "Bot1448 > Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Info("That's some cutting edge technology you have there!");
                }
            }
            #endregion

            #region Install
            else
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Bot1448");
                }
                catch { }
                try
                {
                    WebClient wc = new WebClient();
                    Info("Downloading Bot1448...");
                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        Info("Downloading Bot1448... (" + e.ProgressPercentage + "% complete)");
                    };
                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        wc.Dispose();
                    };
                    wc.DownloadFileAsync(new Uri("http://1448.co.nf/ee/bot.bin"), Application.StartupPath + "\\Bot1448\\BOT_TEMP.bin");
                    var wc2 = new WebClient();
                    Info("Downloading PlayerIOClient...");
                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        Info("Downloading PlayerIOClient... (" + e.ProgressPercentage + "% complete)");
                    };
                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        wc2.Dispose();
                        CreateConfig();
                    };
                    wc2.DownloadFileAsync(new Uri("http://1448.co.nf/ee/PlayerIOClient.dll"), Application.StartupPath + "\\Bot1448\\PlayerIOClient.dll");
                }
                catch { MessageBox.Show("Oh noes! We're experiencing connectivity issues!\nCheck your internet connection.", "Bot1448 > Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            #endregion

            btnStart.Enabled = false;
            chkDark.Enabled = false;
        }
    }
}

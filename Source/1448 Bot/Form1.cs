using System;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using PlayerIOClient;
using System.Windows.Forms;
using Yonom.EE;

namespace _1448_Bot
{
    public partial class Bot : Form
    {
        public Bot()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region Public variables
        public static Dictionary<int, string> Players = new Dictionary<int, string>();
        public static Dictionary<string, string> Comments = new Dictionary<string, string>();
        public static Dictionary<string, int> Reports = new Dictionary<string, int>();
        public static Dictionary<uint, uint> CustomSnakes = new Dictionary<uint, uint>();
        public static Dictionary<string, Coordinates> Fill = new Dictionary<string, Coordinates>();
        public static List<Theme> Themes = new List<Theme>();
        public static Client client;
        public static Connection conn;
        public static Color Bg, Fg;
        public static bool connected, isOwner, canEdit, usingTheme;
        public static string botOwner, email, pass, worldID, stalked, currentVersion, godOn;
        public static double gravity;
        public static int botID;
        public static uint[, ,] RoomData;
        #endregion

        #region Methods

        #region Binary

        public void BinaryRead(BinaryItem bi)
        {
            #region Config
            if (bi == BinaryItem.Config || bi == BinaryItem.All)
            {
                try
                {
                    using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\config\\version.dat", FileMode.Open)))
                    {
                        currentVersion = br.ReadString();
                        this.Text = "Bot1448 v" + currentVersion;
                        Detail("Current version: " + currentVersion);
                    }
                }
                catch { }
                try
                {
                    using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\config\\theme.dat", FileMode.Open)))
                    {
                        usingTheme = true;
                        Detail("A theme file modifies the appearance of the bot.");
                        string themeName = br.ReadString();
                        this.Text += " - " + themeName.Trim('[', ']');
                        Detail("Theme: " + themeName);
                        Bg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        Fg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        var bgText = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        var fgText = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        var bgButton = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        var fgButton = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                        godOn = br.ReadString();
                        this.BackColor = Bg;
                        txtEmail.BackColor = bgText;
                        txtEmail.ForeColor = fgText;
                        this.ForeColor = Fg;
                        foreach (TabPage tab in new TabPage[] { tabHome, tabAdminBan, tabBuild, tabChat, tabReportComment, tabTheme })
                        {
                            tab.BackColor = Bg;
                            tab.ForeColor = Fg;
                            foreach (Control grp in tab.Controls)
                            {
                                if (grp.GetType() == typeof(GroupBox))
                                {
                                    grp.BackColor = Bg;
                                    grp.ForeColor = Fg;
                                    foreach (Control ctrl in grp.Controls)
                                    {
                                        if (ctrl.GetType() == typeof(Button))
                                        {
                                            ctrl.BackColor = bgButton;
                                            ctrl.ForeColor = fgButton;
                                        }
                                        else if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(RichTextBox) || ctrl.GetType() == typeof(ListBox) || ctrl.GetType() == typeof(NumericUpDown))
                                        {
                                            ctrl.BackColor = bgText;
                                            ctrl.ForeColor = fgText;
                                        }
                                        else
                                        {
                                            ctrl.ForeColor = Fg;
                                        }
                                    }
                                }
                            }
                        }
                        rtbChat.BackColor = bgText;
                        rtbChat.ForeColor = fgText;
                    }
                }
                catch (Exception e) { usingTheme = false; godOn = "https://vgy.me/EX2K6Y.png"; Detail("The theme.dat file is either missing or corrupted." + e.Message); }
            }
            #endregion

            if (!Directory.Exists(Application.StartupPath + "\\1448-data"))
            {
                ShowInfo("Welcome to Bot1448! For more information, queries, etc. on this bot, go check out the forum post for this bot.");
                Directory.CreateDirectory(Application.StartupPath + "\\1448-data");
                File.Create(Application.StartupPath + "\\1448-data\\settings.dat");
                File.Create(Application.StartupPath + "\\1448-data\\admins.dat");
                File.Create(Application.StartupPath + "\\1448-data\\bans.dat");
                File.Create(Application.StartupPath + "\\1448-data\\comments.dat");
                File.Create(Application.StartupPath + "\\1448-data\\snakes.dat");
            }
            else
            {
                if (bi == BinaryItem.All)
                {
                    #region Settings
                    using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\settings.dat", FileMode.Open)))
                    {
                        try
                        {
                            txtEmail.Text = br.ReadString();
                            txtPass.Text = br.ReadString();
                            txtWorld.Text = br.ReadString();
                            chkSnake.Checked = br.ReadBoolean();
                            chkBasicSnake.Checked = br.ReadBoolean();
                            chkBrickSnake.Checked = br.ReadBoolean();
                            chkGlassSnake.Checked = br.ReadBoolean();
                            chkMineralSnake.Checked = br.ReadBoolean();
                            chkCandySnake.Checked = br.ReadBoolean();
                            chkPlasticSnake.Checked = br.ReadBoolean();
                            chkSpaceSnake.Checked = br.ReadBoolean();
                            chkCheckerSnake.Checked = br.ReadBoolean();
                            chkMarbleSnake.Checked = br.ReadBoolean();
                            chkFairytaleSnake.Checked = br.ReadBoolean();
                            chkRainbowSnake.Checked = br.ReadBoolean();
                            numSnakeSpeed.Value = br.ReadDecimal();
                            chkWelcome.Checked = br.ReadBoolean();
                            txtJoinSayFirst.Text = br.ReadString();
                            txtJoinSayLast.Text = br.ReadString();
                            chkBye.Checked = br.ReadBoolean();
                            txtLeaveSayFirst.Text = br.ReadString();
                            txtLeaveSayLast.Text = br.ReadString();
                            chkPrefix.Checked = br.ReadBoolean();
                            txtPrefix.Text = br.ReadString();
                            chkPmPrefix.Checked = br.ReadBoolean();
                            txtPmPrefix.Text = br.ReadString();
                            chkAdminKick.Checked = br.ReadBoolean();
                            chkAdminKill.Checked = br.ReadBoolean();
                            chkAdminEdit.Checked = br.ReadBoolean();
                            chkAdminRedit.Checked = br.ReadBoolean();
                            chkAdminSnake.Checked = br.ReadBoolean();
                            chkAdminSave.Checked = br.ReadBoolean();
                            chkAdminLoad.Checked = br.ReadBoolean();
                            chkAdminClear.Checked = br.ReadBoolean();
                            chkAdminGod.Checked = br.ReadBoolean();
                            chkAdminUngod.Checked = br.ReadBoolean();
                            chkAdminJoinEdit.Checked = br.ReadBoolean();
                            chkAdminAdmin.Checked = br.ReadBoolean();
                            chkAdminBan.Checked = br.ReadBoolean();
                            chkReport.Checked = br.ReadBoolean();
                            numMaxReport.Value = br.ReadDecimal();
                            chkComments.Checked = br.ReadBoolean();
                            chkStalk.Checked = br.ReadBoolean();
                            txtStalk.Text = br.ReadString();
                            chkAdminStalk.Checked = br.ReadBoolean();
                            try
                            {
                                numFillSpeed.Value = br.ReadDecimal();
                            }
                            catch { }
                        }
                        catch
                        {
                            ShowError("There was an error while loading your settings.\nThis usually happens when you have updated from an ancient version of this bot to a newer version, or if you have tampered with the data file.\nThis error should be fixed the next time you launch the bot.");
                            Detail("Error: The settings.dat file is missing or corrupted.");
                        }
                    }
                #endregion

                    #region Admins
                    try
                    {
                        using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\admins.dat", FileMode.Open)))
                        {
                            int pos = 0;
                            int length = (int)br.BaseStream.Length;
                            while (pos < length)
                            {
                                string admin = br.ReadString();
                                lstAdmin.Items.Add(admin);
                                pos += admin.Length * sizeof(char);
                            }
                        }
                    }
                    catch { Detail("Error: The admins.dat file is missing or corrupted."); }
                    #endregion

                    #region Bans
                    try
                    {
                        using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\bans.dat", FileMode.Open)))
                        {
                            int pos = 0;
                            int length = (int)br.BaseStream.Length;
                            while (pos < length)
                            {
                                string ban = br.ReadString();
                                lstBan.Items.Add(ban);
                                pos += ban.Length * sizeof(char);
                            }
                        }
                    }
                    catch { Detail("Error: The bans.dat file is missing or corrupted."); }
                    #endregion

                    #region Comments
                    try
                    {
                        using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\comments.dat", FileMode.Open)))
                        {
                            int pos = 0;
                            int length = (int)br.BaseStream.Length;
                            while (pos < length)
                            {
                                string key = br.ReadString();
                                pos += key.Length * sizeof(char);
                                string value = br.ReadString();
                                pos += value.Length * sizeof(char);
                                Comments.Add(key, value);
                                lstComments.Items.Add(key + ": " + value);
                            }
                        }
                    }
                    catch { Detail("Error: The comments.dat file is missing or corrupted."); }
                    #endregion

                    #region Snakes
                    try
                    {
                        using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\snakes.dat", FileMode.Open)))
                        {
                            int pos = 0;
                            while (pos < (int)br.BaseStream.Length)
                            {
                                ParseSnake(br.ReadString());
                            }
                        }
                    }
                    catch { }
                }
                    #endregion

                #region Themes
                if (bi == BinaryItem.Themes || bi == BinaryItem.All)
                {
                    try
                    {
                        using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\1448-data\\themes.dat", FileMode.Open)))
                        {
                            lstThemes.Items.Clear();
                            lstThemes.Items.Add("[Default]");
                            Themes.Add(new Theme("[Default]", Color.FromArgb(240, 240, 240), Color.Black, Color.White, Color.Black, Color.FromArgb(240, 240, 240), Color.Black, "https://vgy.me/EX2K6Y.png"));
                            lstThemes.Items.Add("[Dark]");
                            Themes.Add(new Theme("[Dark]", Color.FromArgb(17, 17, 17), Color.FromArgb(255, 223, 0), Color.FromArgb(28, 28, 28), Color.FromArgb(107, 208, 255), Color.FromArgb(135, 0, 255), Color.FromArgb(255, 255, 255), "https://vgy.me/PmNl33.png"));
                            lstThemes.Items.Add("[Green]");
                            Themes.Add(new Theme("[Green]", Color.SeaGreen, Color.White, Color.GreenYellow, Color.DarkGreen, Color.SpringGreen, Color.DarkOliveGreen, "https://vgy.me/EX2K6Y.png"));
                            int pos = 0;
                            while (pos < br.BaseStream.Length)
                            {
                                string name = br.ReadString();
                                pos += name.Length * sizeof(char);

                                Color mbg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()), mfg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()), tbg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()), tfg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()), bbg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()), bfg = Color.FromArgb(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                                pos += 18 * sizeof(int);

                                string god = br.ReadString();
                                pos += god.Length * sizeof(char);

                                Themes.Add(new Theme(name, mbg, mfg, tbg, tfg, bbg, bfg, god));
                                lstThemes.Items.Add(name);
                            }
                        }
                    }
                    catch (Exception ex) { Detail("Error: The themes.dat file is either corrupted or missing. " + ex.Message); }
                #endregion

                }
            }
        }

        public void BinaryWrite(BinaryItem bi)
        {
            #region Admins
            if (bi == BinaryItem.Admins || bi == BinaryItem.All)
            {
                if (!Directory.Exists(Application.StartupPath + "\\1448-data"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\1448-data");
                }
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\admins.dat", FileMode.Create)))
                {
                    foreach (string admin in lstAdmin.Items)
                        bw.Write(admin);
                }
            }
            #endregion

            #region Bans
            if (bi == BinaryItem.Bans || bi == BinaryItem.All)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\bans.dat", FileMode.Create)))
                {
                    foreach (string ban in lstBan.Items)
                    {
                        bw.Write(ban);
                    }
                }
            }
            #endregion

            #region Comments
            if (bi == BinaryItem.Comments || bi == BinaryItem.All)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\comments.dat", FileMode.Create)))
                {
                    foreach (KeyValuePair<string, string> comment in Comments)
                    {
                        bw.Write(comment.Key);
                        bw.Write(comment.Value);
                    }
                }
            }
            #endregion

            #region Settings
            if (bi == BinaryItem.Settings || bi == BinaryItem.All)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\settings.dat", FileMode.Create)))
                {
                    if (email != null)
                    {
                        bw.Write(email);
                        bw.Write(pass);
                        bw.Write(worldID);
                    }
                    else
                    {
                        bw.Write("");
                        bw.Write("");
                        bw.Write("");
                    }
                    bw.Write(chkSnake.Checked);
                    bw.Write(chkBasicSnake.Checked);
                    bw.Write(chkBrickSnake.Checked);
                    bw.Write(chkGlassSnake.Checked);
                    bw.Write(chkMineralSnake.Checked);
                    bw.Write(chkCandySnake.Checked);
                    bw.Write(chkPlasticSnake.Checked);
                    bw.Write(chkSpaceSnake.Checked);
                    bw.Write(chkCheckerSnake.Checked);
                    bw.Write(chkMarbleSnake.Checked);
                    bw.Write(chkFairytaleSnake.Checked);
                    bw.Write(chkRainbowSnake.Checked);
                    bw.Write(numSnakeSpeed.Value);
                    bw.Write(chkWelcome.Checked);
                    bw.Write(txtJoinSayFirst.Text);
                    bw.Write(txtJoinSayLast.Text);
                    bw.Write(chkBye.Checked);
                    bw.Write(txtLeaveSayFirst.Text);
                    bw.Write(txtLeaveSayLast.Text);
                    bw.Write(chkPrefix.Checked);
                    bw.Write(txtPrefix.Text);
                    bw.Write(chkPmPrefix.Checked);
                    bw.Write(txtPmPrefix.Text);
                    bw.Write(chkAdminKick.Checked);
                    bw.Write(chkAdminKill.Checked);
                    bw.Write(chkAdminEdit.Checked);
                    bw.Write(chkAdminRedit.Checked);
                    bw.Write(chkAdminSnake.Checked);
                    bw.Write(chkAdminSave.Checked);
                    bw.Write(chkAdminLoad.Checked);
                    bw.Write(chkAdminClear.Checked);
                    bw.Write(chkAdminGod.Checked);
                    bw.Write(chkAdminUngod.Checked);
                    bw.Write(chkAdminJoinEdit.Checked);
                    bw.Write(chkAdminAdmin.Checked);
                    bw.Write(chkAdminBan.Checked);
                    bw.Write(chkReport.Checked);
                    bw.Write(numMaxReport.Value);
                    bw.Write(chkComments.Checked);
                    bw.Write(chkStalk.Checked);
                    bw.Write(txtStalk.Text);
                    bw.Write(chkAdminStalk.Checked);
                    bw.Write(numFillSpeed.Value);
                }
            }
            #endregion

            #region Snakes
            if (bi == BinaryItem.Snakes || bi == BinaryItem.All)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\snakes.dat", FileMode.Create)))
                {
                    foreach (string snake in lstCustomSnake.Items)
                    {
                        bw.Write(snake);
                    }
                }
            }
            #endregion

            #region Themes
            if (bi == BinaryItem.Themes || bi == BinaryItem.All)
            {
                foreach (var theme in Themes)
                {
                    using (var bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\themes.dat", FileMode.Create)))
                    {
                        if (!theme.Name.StartsWith("["))
                            theme.Save(bw);
                    }
                }
            }
            #endregion
        }

        public void UpdateCheck()
        {
            try
            {
                #region Check if user wants auto-updater
                if (!File.Exists(Application.StartupPath + "\\config\\UPDATEINFO"))
                {
                    File.Create(Application.StartupPath + "\\config\\UPDATEINFO");
                    if (MessageBox.Show("Do you want the bot to automatically check for updates?", "Bot1448 > Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        
                        File.WriteAllText(Application.StartupPath + "\\config\\UPDATEINFO", "do not update");
                    }
                }
                #endregion

                if (File.ReadAllText(Application.StartupPath + "\\config\\UPDATEINFO") != "do not update")
                {
                    string version, desc;
                    bool force, ask;
                    DialogResult? accept = null;

                    #region Fetch info

                    #region Cloud
                    using (var wc = new WebClient())
                    {
                        using (var br = new BinaryReader(wc.OpenRead("http://1448.co.nf/ee/botversion.dat")))
                        {
                            version = br.ReadString();
                            force = br.ReadBoolean();
                            desc = br.ReadString();
                        }
                    }
                    #endregion

                    #region Local
                    using (var br = new BinaryReader(File.Open(Application.StartupPath + "\\config\\version.dat", FileMode.Open)))
                    {
                        currentVersion = br.ReadString();
                        switch (File.ReadAllText(Application.StartupPath + "\\config\\UPDATEINFO"))
                        {
                            case "auto-update":
                                ask = false;
                                accept = DialogResult.Yes;
                                break;

                            case "do not ask":
                                ask = false;
                                accept = DialogResult.No;
                                break;

                            default:
                                ask = true;
                                break;
                        }
                    }
                    #endregion

                    #endregion

                    #region Force installer update (I'm sorry about this)

                    if (!File.Exists(Application.StartupPath + "\\config\\installer"))
                    {
                        ShowError("Your installer is not up to date. The bot will have to update the installer now. Sorry for the inconvenience.");
                        var wc = new WebClient();
                        wc.DownloadFileAsync(new Uri("http://1448.co.nf/ee/installer.bin"), Application.StartupPath + "\\update.exe");
                        wc.DownloadFileCompleted += (s, e) =>
                        {
                            wc.Dispose();
                            File.Create(Application.StartupPath + "\\config\\installer");
                            ShowInfo("Successfully updated installer.");
                        };
                    }

                    #endregion

                    #region Check version and update

                    if (currentVersion != version)
                    {
                        if (!force && ask)
                            accept = MessageBox.Show("A new update for this bot is available." + "\n\n---Update Details---\n" + desc + "\n\nUpdate now?\nThis will be the default setting for all new optional updates. To reset this, delete the UPDATEINFO file in the bot's config folder.", "Update < Bot1448", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        else if (force)
                            accept = MessageBox.Show("An important update for this bot is available." + "\n\n---Update Details---\n" + desc + "\n\nUpdate now?");

                        if (accept == DialogResult.Yes)
                        {
                            File.WriteAllText(Application.StartupPath + "\\config\\UPDATEINFO", "auto-update");
                            Process.Start(Application.StartupPath + "\\update.exe");
                            this.Close();
                        }
                        else
                        {
                            File.WriteAllText(Application.StartupPath + "\\config\\UPDATEINFO", "do not ask");
                        }
                    }

                    #endregion
                }
            }
            catch (WebException)
            {
                ImDead("There is no internet connection.");
            }
        }

        #endregion

        #region Say
        public void Say(string message)
        {
            conn.Send("say", (chkPrefix.Checked ? txtPrefix.Text + " " : "") + message);
        }

        public void Say(string message, PlayerIOClient.Message m, uint index)
        {
            conn.Send("say", "/pm " + Players[m.GetInt(index)] + " " + (chkPmPrefix.Checked ? txtPmPrefix.Text + " " : "") + message);
        }

        public void Say(string message, string receiver)
        {
            conn.Send("say", "/pm " + receiver + " " + txtPmPrefix.Text + message);
        }
        #endregion

        #region Other
        public bool ContainsArguments(string command, PlayerIOClient.Message e, uint index)
        {
            if (command.Contains(' '))
                return true;
            else
            {
                Say("You need arguments with that command", e, index);
                return false;
            }
        }

        public void Build(int layer, int x, int y, int blockid, int waitTime)
        {
            conn.Send("b", layer, x, y, blockid);
            W8(waitTime);
        }

        public void Build(int layer, int x, int y, int blockid)
        {
            conn.Send("b", layer, x, y, blockid);
        }

        public void ParseSnake(string parse)
        {
            string[] snakeArray = parse.Split(',');
            uint[] blockIDArray = new uint[snakeArray.Length + 1];
            if (snakeArray.Length > 1)
            {
                bool correct = true;
                int i = 0;
                uint snake;
                foreach (var snakeString in snakeArray)
                {
                    if (uint.TryParse(snakeString.Trim(), out snake))
                    {
                        if (!CustomSnakes.ContainsKey(snake) || snake == uint.Parse(snakeArray[snakeArray.Length - 1]))
                        {
                            blockIDArray[i] = snake;
                            i++;
                        }
                        else
                        {
                            ShowError("You have already declared a custom snake containing the block ID " + snake + ".\nYou have to either delete that snake, or use a different block in your snake.");
                            correct = false;
                            break;
                        }
                    }
                    else
                    {
                        ShowError("The item you specified at index " + (Array.IndexOf(snakeArray, snakeString) + 1) + " is not valid.");
                        correct = false;
                        break;
                    }
                }
                if (correct)
                {
                    int prev = -1;
                    for (int j = 0; j < blockIDArray.Length; j++)
                    {
                        try
                        {
                            if (prev >= 0)
                                CustomSnakes.Add((uint)prev, blockIDArray[j]);
                            prev = (int)blockIDArray[j];
                        }
                        catch { break; }
                    }
                    lstCustomSnake.Items.Add(parse);
                    BinaryWrite(BinaryItem.Snakes);
                }
            }
            else
                MessageBox.Show("Specify at least 2 block IDs to create a snake.", "Error < Bot1448", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowHelp(string info)
        {
            MessageBox.Show(info, "Bot1448 > Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Bot1448 > Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void W8(int time)
        {
            Thread.Sleep(time);
        }

        public void Async(Action function) {
            Task.Factory.StartNew(function);
        }

        public void ShowInfo(string info)
        {
            MessageBox.Show(info, "Bot1448 > Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ImDead(string fatalError)
        {
            MessageBox.Show(fatalError, "Bot1448 > Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Detail(string info)
        {
            rtbDetails.Text += Environment.NewLine + info;
        }
        #endregion

        #endregion

        #region Events

        #region PlayerIO
        public void OnMessage(object sender, PlayerIOClient.Message e)
        {
            switch (e.Type)
            {
                #region init
                case "init":
                    conn.Send("init2");
                    botID = e.GetInt(5);
                    gravity = e.GetDouble(20);
                    botOwner = e.GetString(13).ToLower();
                    Players.Add(botID, botOwner);
                    RoomData = new uint[2, e.GetInt(18), e.GetInt(19)];
                    var chunks = InitParse.Parse(e);
                    foreach (var chunk in chunks)
                        foreach (var pos in chunk.Locations)
                            RoomData[chunk.Layer, pos.X, pos.Y] = chunk.Type;

                    if (e.GetBoolean(15) && e.GetBoolean(14))
                    {
                        isOwner = true;
                        canEdit = true;
                    }
                    else
                    {
                        canEdit = false;
                    }
                    //15owner, 14edit
                    break;
                #endregion

                #region reset
                case "reset":
                    var chunks2 = InitParse.Parse(e);
                    foreach (var chunk in chunks2)
                        foreach (var pos in chunk.Locations)
                            RoomData[chunk.Layer, pos.X, pos.Y] = chunk.Type;
                    break;
                #endregion

                #region add
                case "add":
                    Players.Add(e.GetInt(0), e.GetString(1).ToLower());
                    try
                    {
                        lstOnline.Items.Add(e.GetString(1));
                    }
                    catch { }
                    if (chkWelcome.Checked)
                        Say(txtJoinSayFirst.Text + e.GetString(1) + txtJoinSayLast.Text);
                    if (lstBan.Items.Contains(e.GetString(1)))
                    {
                        conn.Send("say", "/kick " + e.GetString(1) + " You are banned from this world.");
                    }
                    if (lstAdmin.Items.Contains(e.GetString(1)) && chkAdminJoinEdit.Checked)
                    {
                        conn.Send("say", "/giveedit " + e.GetString(1));
                    }
                    break;
                #endregion

                #region left
                case "left":
                    int id = e.GetInt(0);
                    if (chkBye.Checked)
                        Say(txtLeaveSayFirst.Text + Players[e.GetInt(0)] + txtLeaveSayLast.Text);
                    lstOnline.Items.Remove(Players[e.GetInt(0)]);
                    Players.Remove(e.GetInt(0));
                    break;
                #endregion

                #region say
                case "say":
                    try
                    {
                        rtbChat.Text += Environment.NewLine + Players[e.GetInt(0)].ToUpper() + ": " + e.GetString(1);
                    }
                    catch { }

                    #region Commands
                    if (e.GetString(1).StartsWith("!") || e.GetString(1).StartsWith(".") || e.GetString(1).StartsWith("@"))
                    {
                        string[] full = e.GetString(1).Split(' ');
                        string command = full[0].Substring(1).ToLower();
                        switch (command)
                        {
                            #region help
                            case "help":
                                if (e.GetString(1).Contains(' '))
                                {
                                    switch (full[1])
                                    {
                                        #region admin help
                                        case "kick":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!kick <player> [reason] - Kicks the specified player and provides the specified reason.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "name":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!name <name> - Changes the name of the world.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "kill":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!kill <player> - Kills the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "edit":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!edit <player> - Gives edit permissions to the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "redit":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!redit <player> - Removes edit permissions from the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "stalk":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!stalk <player> - Tells the bot to follow the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "unstalk":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!unstalk - Tells the bot to stop stalking.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "snake":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!snake - Toggles snake.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "load":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!load - Loads the level from the saved state", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "admin":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!admin <player> - Gives admin rights to the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "unadmin":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!unadmin <player> - Removes admin rights form the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "ban":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!ban <player> - Ban the specified player from the world.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "unban":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!unban <player> - Lift the ban from the specified player.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "god":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!god <player> - Force the specified player into god mode.", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "ungod":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!ungod <player> - Forces the specified player into non-god player", e, 0);
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "clear":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!clear - Clears the world.");
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "bgcolor":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!bgcolor <hex> - Sets the background color of the world.");
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;

                                        case "save":
                                            if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                                Say("!save - Saves the world.");
                                            else
                                                Say("Not enough permissions to use this command", e, 0);
                                            break;
                                        #endregion

                                        #region player help
                                        case "dice":
                                            Say("!dice - Gives a random number between 0 and 6.", e, 0);
                                            break;
                                        case "ignoresnake":
                                            Say("!ignoresnake - Tells the snake tool to ignore you until you say this command again.", e, 0);
                                            break;
                                        case "download":
                                            Say("!download - Gives you the download link for the bot.", e, 0);
                                            break;
                                        case "comment":
                                            Say("!comment <comment> - View or create a comment for this level.", e, 0);
                                            break;
                                        case "report":
                                            Say("!report <player> - Reports a player to the bot if the owner has enabled this feature.", e, 0);
                                            break;
                                        case "fill":
                                            Say("!fill - Starts a new fill command.");
                                            break;
                                        case "botinfo":
                                            Say("!botinfo - Gives you information about the bot.");
                                            break;
                                        case "comments":
                                            Async(() =>
                                            {
                                                Say("!comments <player> - Shows you the comment posted by the player you specified.");
                                                W8(1000);
                                                Say("!comments - Gives you the list of players who have posted comments.");
                                            });
                                            break;
                                        #endregion

                                        default:
                                            Say("Unknown command.", e, 0);
                                            break;
                                    }
                                }
                                else
                                {
                                    Say("Basic commands: dice, ignoresnake, download, comment, comments, botinfo, report, fill, adminhelp", e, 0);
                                    Async(() =>
                                    {
                                        W8(1000);
                                        Say("Use !help <command> on more information on that command.", e, 0);
                                    });
                                }
                                break;
                            #endregion

                            #region kick
                            case "kick":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminKick.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        if (full[1].ToLower().Trim() != Players[e.GetInt(0)] && full[1].ToLower() != botOwner)
                                        {
                                            conn.Send("say", "/kick " + e.GetString(1).Substring(6).ToLower());
                                        }
                                        else
                                        {
                                            Say("Why would you want to do that?", e, 0);
                                        }
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region kicklol
                            case "kicklol":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminKick.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        if (full[1].ToLower().Trim() != Players[e.GetInt(0)] && full[1].ToLower() != botOwner)
                                        {
                                            conn.Send("say", "/kick " + e.GetString(1).Substring(6).ToLower());

                                        }
                                        else
                                        {
                                            Say("Why would you want to do that?", e, 0);
                                        }
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region kill
                            case "kill":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminKill.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        conn.Send("say", "/kill " + full[1]);
                                        Say(full[1] + " died.", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region bgcolor
                            case "bgcolor":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if (((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminBg.Checked) || Players[e.GetInt(0)] == botOwner) && isOwner)
                                    {
                                        conn.Send("say", "/bgcolor " + full[1]);
                                        Say("Set the bgcolor to " + full[1], e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region comment
                            case "comment":
                                if (chkComments.Checked)
                                {
                                    if (e.GetString(1).Contains(' '))
                                    {
                                        if (Comments.ContainsKey(Players[e.GetInt(0)]))
                                        {
                                            Comments[Players[e.GetInt(0)]] = e.GetString(1).Substring(9);
                                            lstComments.BeginUpdate();
                                            try
                                            {
                                                for (int i = lstComments.Items.Count - 1; i >= 0; i--)
                                                {
                                                    if (lstComments.Items[i].ToString().Split(':')[0] == Players[e.GetInt(0)])
                                                    {
                                                        lstComments.Items.RemoveAt(i);
                                                    }
                                                }
                                            }
                                            finally
                                            {
                                                lstComments.EndUpdate();
                                            }
                                        }
                                        else
                                            Comments.Add(Players[e.GetInt(0)], e.GetString(1).Substring(9));
                                        lstComments.Items.Add(Players[e.GetInt(0)] + ": " + e.GetString(1).Substring(9));
                                        Say("Your comment is now: " + e.GetString(1).Substring(9), e, 0);
                                        BinaryWrite(BinaryItem.Comments);
                                    }
                                    else
                                    {
                                        if (Comments.ContainsKey(Players[e.GetInt(0)]))
                                        {
                                            Say("You had commented: " + Comments[Players[e.GetInt(0)]].Substring(Comments[Players[e.GetInt(0)]].IndexOf(' ')), e, 0);
                                        }
                                        else
                                        {
                                            Say("You have not yet commented.", e, 0);
                                        }
                                    }
                                }
                                else
                                    Say("The owner of this bot has disabled this feature.", e, 0);
                                break;
                            #endregion

                            #region fill
                            case "fill":
                                if (((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && radAdmins.Checked) || radEverybody.Checked || Players[e.GetInt(0)] == botOwner))
                                {
                                    try
                                    {
                                        Fill.Add(Players[e.GetInt(0)], new Coordinates());
                                        Say("Started a new fill.", e, 0);
                                    }
                                    catch
                                    {
                                        Say("You're already doing a fill!", e, 0);
                                    }
                                }
                                else
                                    Say("You are not permitted to use that command.", e, 0);
                                break;
                            #endregion

                            #region name
                            case "name":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminName.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        conn.Send("name", e.GetString(1).Substring(5));
                                    }
                                    else
                                        Say("You are not permitted to use that command.", e, 0);
                                }
                                break;
                            #endregion

                            #region report
                            case "report":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if (chkReport.Checked)
                                    {
                                        if (full[1].ToLower() != Players[e.GetInt(0)] && full[1].ToLower() != botOwner)
                                        {
                                            if (Reports.ContainsKey(full[1].ToLower()))
                                            {
                                                if (!lstReports.Items.Contains(Players[e.GetInt(0)].ToLower() + " reported " + full[1].ToLower()))
                                                {
                                                    lstReports.Items.Add(Players[e.GetInt(0)].ToLower() + " reported " + full[1].ToLower());
                                                    Reports[full[1].ToLower()]++;
                                                    if (Reports[full[1].ToLower()] >= numMaxReport.Value)
                                                    {
                                                        lstBan.Items.Add(full[1].ToLower());
                                                        conn.Send("say", "/kick " + full[1] + " You have been reported " + Reports[full[1].ToLower()] + " times.");
                                                        BinaryWrite(BinaryItem.Bans);
                                                    }
                                                }
                                                else
                                                {
                                                    Say("You can report one player only once.", e, 0);
                                                }
                                            }
                                            else
                                            {
                                                Reports.Add(full[1].ToLower(), 1);
                                                lstReports.Items.Add(Players[e.GetInt(0)] + " reported " + full[1].ToLower());
                                                if (Reports[full[1].ToLower()] >= numMaxReport.Value)
                                                {
                                                    lstBan.Items.Add(full[1].ToLower());
                                                    conn.Send("say", "/kick " + full[1] + " You have been reported " + Reports[full[1].ToLower()] + " times.");
                                                    BinaryWrite(BinaryItem.Bans);
                                                }
                                            }
                                        }
                                        else
                                            Say("Why would you want to do that?", e, 0);
                                    }
                                    else
                                        Say("The owner of the bot has disabled that feature.", e, 0);
                                }
                                break;
                            #endregion

                            #region edit
                            case "edit":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if (((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminEdit.Checked) || Players[e.GetInt(0)] == botOwner) && isOwner)
                                    {
                                        conn.Send("say", "/giveedit " + full[1]);
                                        Say(full[1] + " now has edit.", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region redit
                            case "redit":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if (((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminRedit.Checked) || Players[e.GetInt(0)] == botOwner) && isOwner)
                                    {
                                        conn.Send("say", "/removeedit " + full[1]);
                                        Say(full[1] + " no longer has edit.", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region god
                            case "god":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminGod.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        conn.Send("say", "/givegod " + full[1]);
                                        Say(full[1] + " now has access to god mode.", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region ungod
                            case "ungod":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminUngod.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        conn.Send("say", "/removegod " + full[1]);
                                        Say(full[1] + " no longer has access to god mode.", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region admin
                            case "admin":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminAdmin.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        lstAdmin.Items.Add(full[1].ToLower());
                                        BinaryWrite(BinaryItem.Admins);
                                        Say(full[1].ToLower() + " is now an admin.", e, 0);
                                        Say("You are now an admin! :D", full[1]);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region unadmin
                            case "unadmin":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminAdmin.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        try
                                        {
                                            if (full[1].ToLower() != Players[e.GetInt(0)])
                                            {
                                                lstAdmin.Items.Remove(full[1].ToLower());
                                                BinaryWrite(BinaryItem.Admins);
                                                Say(full[1].ToLower() + " is no longer an admin.", e, 0);
                                                Say("You're no longer an admin.", full[1].ToLower());
                                            }
                                            else
                                            {
                                                Say("Why would you want to unadmin yourself?", e, 0);
                                            }

                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region ban
                            case "ban":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminBan.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        if (full[1].ToLower() != Players[e.GetInt(0)])
                                        {
                                            if (full[1].ToLower() != botOwner)
                                            {
                                                lstBan.Items.Add(full[1].ToLower());
                                                conn.Send("say", "/kick " + full[1] + " You are now banned.");
                                                Say(full[1] + " is now banned.", e, 0);
                                                BinaryWrite(BinaryItem.Bans);
                                            }
                                            else
                                            {
                                                Say("I wouldn't even try to ban the owner if I were you.", e, 0);
                                            }
                                        }
                                        else
                                        {
                                            Say("Why would you want to ban yourself?", e, 0);
                                        }
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region unban
                            case "unban":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminBan.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        try
                                        {
                                            lstBan.Items.Remove(full[1].ToLower());
                                            BinaryWrite(BinaryItem.Bans);
                                            Say(full[1].ToLower() + " is no longer banned.", e, 0);
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region stalk
                            case "stalk":
                                if (ContainsArguments(e.GetString(1), e, 0))
                                {
                                    if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminStalk.Checked) || Players[e.GetInt(0)] == botOwner)
                                    {
                                        chkStalk.Checked = true;
                                        txtStalk.Text = full[1].ToLower();
                                        stalked = txtStalk.Text;
                                        Say("Stalking " + stalked + " now!", e, 0);
                                        Say("I'm stalking you!", e, 0);
                                    }
                                    else
                                    {
                                        Say("You are not permitted to use that command.", e, 0);
                                    }
                                }
                                break;
                            #endregion

                            #region adminhelp
                            case "adminhelp":
                                if (lstAdmin.Items.Contains(Players[e.GetInt(0)]) || Players[e.GetInt(0)] == botOwner)
                                {
                                    Say("Page 1: kick, kill, edit, redit, snake, admin, unadmin, clear, name", e, 0);
                                    Async(() =>
                                    {
                                        W8(1000);
                                        Say("Page 2: god, ungod, ban, unban, bgcolor, save, load, stalk, unstalk", e, 0);
                                    });
                                }
                                else
                                {
                                    Say("Not enough permissions to use this command.", e, 0);
                                }
                                break;
                            #endregion

                            #region dice
                            case "dice":
                                Say("The dice shows " + new Random().Next(1, 6).ToString(), e, 0);
                                break;
                            #endregion

                            #region botinfo
                            case "botinfo":
                                Say("This is Bot1448 v" + currentVersion + ", developed by alkazam1448.");
                                break;
                            #endregion

                            #region coments
                            case "comments":
                                if (chkComments.Checked)
                                {
                                    if (e.GetString(1).Contains(' '))
                                    {
                                        foreach (string asdasd in lstComments.Items)
                                        {
                                            if (asdasd.Split(':')[0] == full[1])
                                                Say(asdasd, e, 0);
                                            else
                                                Say("That player has not commented yet.", e, 0);
                                        }
                                    }
                                    else
                                    {
                                        Async(() =>
                                        {
                                            var blas = new string[lstComments.Items.Count];
                                            string send = "";
                                            for (int i = 0; i < lstComments.Items.Count / 6; i++)
                                                blas[i] = (string)lstComments.Items[i];
                                            int j;
                                            for (j = 0; j < blas.Length - 1; j++)
                                                send += blas[j] + ", ";
                                            send += blas[j];
                                            Say("The people who have commented here are:", e, 0);
                                            W8(1000);
                                            Say(send, e, 0);
                                        });
                                    }
                                }
                                break;
                            #endregion

                            #region ignoresnake
                            case "ignoresnake":
                                if (lstIgnoreSnake.Items.Contains(Players[e.GetInt(0)]))
                                {
                                    lstIgnoreSnake.Items.Remove(Players[e.GetInt(0)]);
                                    Say("The snake tool will no longer ignore you.", e, 0);
                                }
                                else
                                {
                                    lstIgnoreSnake.Items.Add(Players[e.GetInt(0)]);
                                    Say("The snake tool will now ignore you.", e, 0);
                                }
                                break;
                            #endregion

                            #region download
                            case "download":
                                Say("Download and view the bot at http://forums.everybodyedits.com/viewtopic.php?pid=629482");
                                break;
                            #endregion

                            #region load
                            case "load":
                                if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminLoad.Checked) || Players[e.GetInt(0)] == botOwner)
                                {
                                    conn.Send("say", "/loadlevel");
                                    Say("Loaded the level.", e, 0);
                                }
                                else
                                {
                                    Say("You are not permitted to use that command.", e, 0);
                                }
                                break;
                            #endregion

                            #region save
                            case "save":
                                if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminSave.Checked) || Players[e.GetInt(0)] == botOwner)
                                {
                                    conn.Send("save");
                                    Say("Saved the level.", e, 0);
                                }
                                else
                                {
                                    Say("You are not permitted to use that command.", e, 0);
                                }
                                break;
                            #endregion

                            #region clear
                            case "clear":
                                if ((lstAdmin.Items.Contains(Players[e.GetInt(0)]) && chkAdminClear.Checked) || Players[e.GetInt(0)] == botOwner)
                                {
                                    conn.Send("clear");
                                    Say("Cleared the level.", e, 0);
                                }
                                else
                                {
                                    Say("You are not permitted to use that command.", e, 0);
                                }
                                break;
                            #endregion

                            #region unstalk
                            case "unstalk":
                                txtStalk.Text = "";
                                chkStalk.Checked = false;
                                break;
                            #endregion

                            #region snake
                            case "snake":
                                if (((chkAdminSnake.Checked && lstAdmin.Items.Contains(Players[e.GetInt(0)])) || Players[e.GetInt(0)] == botOwner) && canEdit)
                                {
                                    chkSnake.Checked = !chkSnake.Checked;
                                    Say("Snake is now " + (chkSnake.Checked ? "enabled" : "disabled"), e, 0);
                                }
                                else
                                {
                                    Say("You are not permitted to use that command.", e, 0);
                                }
                                break;
                            #endregion

                            default:
                                Say("Unknown command.", e, 0);
                                break;
                        }
                    }
                    #endregion

                    break;
                #endregion

                #region b
                case "b":
                    RoomData[e.GetInt(0), e.GetInt(1), e.GetInt(2)] = (uint) e.GetInt(3);
                    try
                    {
                        string player = Players[e.GetInt(4)];

                        #region Fill
                        if (Fill.ContainsKey(Players[e.GetInt(4)]) && e.GetInt(4) != botID)
                        {
                            if (Fill[player].X1 < 0)
                            {
                                Fill[player].Layer = e.GetInt(0);
                                Fill[player].X1 = e.GetInt(1);
                                Fill[player].Y1 = e.GetInt(2);
                                Fill[player].ID = e.GetInt(3);
                            }
                            else if (Fill[player].X2 < 0)
                            {
                                Fill[player].X2 = e.GetInt(1);
                                Fill[player].Y2 = e.GetInt(2);
                                Coordinates co = Fill[player];
                                Async(() =>
                                {
                                    for (int x = co.X1; (co.X1 > co.X2 ? x : co.X2) >= (co.X1 > co.X2 ? co.X2 : x); x += (co.X1 < co.X2 ? 1 : -1))
                                    {
                                        for (int y = co.Y1; (co.Y1 > co.Y2 ? y : co.Y2) >= (co.Y1 > co.Y2 ? co.Y2 : y); y += (co.Y1 < co.Y2 ? 1 : -1))
                                        {
                                            Build(co.Layer, x, y, co.ID, (int)numFillSpeed.Value);
                                        }
                                        for (int y = co.Y1; (co.Y1 > co.Y2 ? y : co.Y2) >= (co.Y1 > co.Y2 ? co.Y2 : y); y += (co.Y1 < co.Y2 ? 1 : -1))
                                        {
                                            Async(() =>
                                            {
                                                try
                                                {
                                                    while (RoomData[co.Layer, x, y] != co.ID)
                                                        Build(co.Layer, x, y, co.ID, (int)numFillSpeed.Value);
                                                }
                                                catch { }
                                            });
                                        }
                                    }
                                    Say("Completed fill.", e, 4);
                                    Fill.Remove(player);
                                });
                            }
                        }
                        #endregion

                        #region Snake
                        if (!lstIgnoreSnake.Items.Contains(player))
                        {
                            if (CustomSnakes.ContainsKey((uint)e.GetInt(3)))
                            {
                                Async(() =>
                                {
                                    try
                                    {
                                        W8((int)numSnakeSpeed.Value);
                                        Build(0, e.GetInt(1), e.GetInt(2), (int)CustomSnakes[(uint)e.GetInt(3)], (int)numSnakeSpeed.Value);
                                    }
                                    catch { }
                                });
                            }
                            else if (chkSnake.Checked)
                            {
                                Async(() =>
                                {
                                    switch (e.GetInt(3))
                                    {
                                        #region Placing blocks
                                        case 14:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBasicSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 12);
                                            break;
                                        case 19:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBrickSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 20);
                                            break;
                                        case 38:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBetaSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 40);
                                            break;
                                        case 1039:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkDomesticSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 1037);
                                            break;
                                        case 134:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkPlasticSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 129);
                                            break;
                                        case 56:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkGlassSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 51);
                                            break;

                                        case 64:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkCandySnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 62);
                                            break;
                                        case 174:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkSpaceSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 175);
                                            break;
                                        case 191:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkCheckerSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 189);
                                            break;
                                        case 1072:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkFairytaleSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 1074);
                                            break;
                                        case 209:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkMarbleSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 210);
                                            break;

                                        case 71:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 72);
                                            break;
                                        case 72:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 73);
                                            break;
                                        case 73:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 74);
                                            break;
                                        case 74:
                                            W8((int)numSnakeSpeed.Value);

                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 75);
                                            else if (chkMineralSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 70);

                                            break;
                                        case 75:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 76);
                                            break;
                                        case 76:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 70);
                                            break;
                                        #endregion

                                        #region Removing blocks
                                        case 12:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBasicSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 20:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBrickSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 40:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkBetaSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 1037:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkDomesticSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 129:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkPlasticSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 51:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkGlassSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 70:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkMineralSnake.Checked || chkRainbowSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 62:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkCandySnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 175:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkSpaceSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 189:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkCheckerSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 1074:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkFairytaleSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                        case 210:
                                            W8((int)numSnakeSpeed.Value);
                                            if (chkMarbleSnake.Checked)
                                                Build(0, e.GetInt(1), e.GetInt(2), 0);
                                            break;
                                            #endregion
                                    }
                                });
                            }
                        }
                        #endregion
                    }
                    catch { }
                    break;
                #endregion

                #region access
                case "access":
                    canEdit = true;
                    Say("Gained edit access! :D");
                    break;
                #endregion

                #region lostaccess
                case "lostaccess":
                    Say("Lost edit rights :(");
                    canEdit = false;
                    break;
                #endregion

                #region m
                case "m":
                    if (chkStalk.Checked && Players[e.GetInt(0)] == stalked && e.GetInt(0) != botID)
                    {
                        conn.Send("m", e[1], e[2], e[3], e[4], e[5], e[6], e[7], e[8], gravity, e[9], e[10], 0);
                    }
                    break;
                #endregion

                #region god
                case "god":
                    if (chkStalk.Checked && Players[e.GetInt(0)] == stalked && e.GetInt(0) != botID)
                    {
                        conn.Send("god", e.GetBoolean(1));
                        picGodMode.ImageLocation = (canEdit && e.GetBoolean(1) ? "https://vgy.me/j2JpvX.png" : "https://vgy.me/f2yjSd.png");
                    }
                    break;
                #endregion
            }
        }

        public void OnDisconnect(object sender, string s)
        {
            isOwner = false;
            connected = false;
            Reports = new Dictionary<string, int>();
            lstReports.Items.Clear();
            canEdit = false;
            lstOnline.Items.Clear();
            rtbChat.Text = "";
            btnConnect.Text = "Connect";
        }
        #endregion

        #region CheckedChanged
        private void chkRainbowSnake_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRainbowSnake.Checked)
                chkMineralSnake.Checked = false;
        }

        private void chkMineralSnake_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMineralSnake.Checked)
                chkRainbowSnake.Checked = false;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !(chkShowPass.Checked);
        }
        #endregion

        #region Click
        private void btnKick_Click(object sender, EventArgs e)
        {
            if (isOwner && connected)
                conn.Send("say", "/kick " + lstOnline.SelectedItem);
        }

        private void btnCustomSnakeHelp_Click(object sender, EventArgs e)
        {
            ShowHelp("Add custom snakes by typing in their block IDs and separating them by commas. For example, if you want a snake that changes a red brick block into an empty block, add \"20, 0\" to the custom snakes list.");
        }

        private void btnLaunchTheme_Click(object sender, EventArgs e)
        {
            new ThemeCreator().Show();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (isOwner && connected)
                conn.Send("say", "/kill " + lstOnline.SelectedItem);
        }

        private void btnRemoveEdit_Click(object sender, EventArgs e)
        {
            if (isOwner && connected)
                conn.Send("say", "/removeedit " + lstOnline.SelectedItem);
        }

        private void btnGiveEdit_Click(object sender, EventArgs e)
        {
            if (isOwner && connected)
                conn.Send("say", "/giveedit " + lstOnline.SelectedItem);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                    lstAdmin.Items.Add(lstOnline.SelectedItem);
            }
            catch { ShowError("You need to select a player first to give admin permissions."); }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                    lstBan.Items.Add(lstOnline.SelectedItem);
            }
            catch { ShowError("You need to select a player first to ban them."); }
        }

        private void btnAdminAdd_Click(object sender, EventArgs e)
        {
            lstAdmin.Items.Add(txtAdmin.Text.ToLower());
            txtAdmin.Text = "";
            BinaryWrite(BinaryItem.Admins);
        }

        private void btnReportHelp_Click(object sender, EventArgs e)
        {
            ShowHelp("Players can use the !report command to report players in the level. Each player can be reported by each other player once. Once a player reports another player, the reported player gets a report point.\nYou can set how many report points are needed to ban or kick a player.");
        }

        private void btnCommentsHelp_Click(object sender, EventArgs e)
        {
            ShowHelp("Each player can post a comment using the !comment command. However, he or she is limited to only one comment.\nComments aren't limited to a single session. They are saved and can be retrieved the next time you launch the bot.");
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            try
            {
                lstComments.Items.Remove(lstComments.SelectedItem);
            }
            catch
            {
                ShowError("You have to select a comment first to remove it.");
            }
        }

        private void btnRemoveReport_Click(object sender, EventArgs e)
        {
            try
            {
                Reports[lstReports.SelectedItem.ToString().Split(' ')[2]]--;
                lstReports.Items.Remove(lstReports.SelectedItem);
            }
            catch
            {
                ShowError("You should select an item first to remove it.");
            }
        }

        private void btnAdminRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdmin.Text == "")
                    lstAdmin.Items.Remove(lstAdmin.SelectedItem);
                else
                    lstAdmin.Items.Remove(txtAdmin.Text.ToLower());
            }
            catch { ShowError("Select an item first to remove it."); }
            txtAdmin.Text = "";
            BinaryWrite(BinaryItem.Admins);
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (connected)
                conn.Send("access", txtCode.Text);
        }

        private void btnStalk_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                stalked = txtStalk.Text;
                Say("I'm stalking you!", txtStalk.Text);
            }
        }

        private void btnAddBan_Click(object sender, EventArgs e)
        {
            lstBan.Items.Add(txtBan.Text.ToLower());
            txtBan.Text = "";
            BinaryWrite(BinaryItem.Bans);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBan.Text == "")
                    lstBan.Items.Remove(lstBan.SelectedItem);
                else
                    lstBan.Items.Remove(txtBan.Text.ToLower());
            }
            catch { ShowError("Select an item first to remove it."); }
            txtBan.Text = "";
            BinaryWrite(BinaryItem.Bans);
        }

        private void btnRemoveSnake_Click(object sender, EventArgs e)
        {
            if (lstCustomSnake.SelectedIndex >= 0)
            {
                string[] snakeArray = lstCustomSnake.SelectedItem.ToString().Split(',');
                for (int i = 0; i < snakeArray.Length - 1; i++)
                {
                    CustomSnakes.Remove(uint.Parse(snakeArray[i].Trim()));
                }
                lstCustomSnake.Items.RemoveAt(lstCustomSnake.SelectedIndex);
            }
            else
                ShowError("Select an item first to remove it.");
        }

        private void picGodMode_Click(object sender, EventArgs e)
        {
            if (connected && canEdit)
            {
                if (picGodMode.ImageLocation == "https://vgy.me/f2yjSd.png")
                {
                    conn.Send("god", true);
                    picGodMode.ImageLocation = godOn;
                }
                else
                {
                    conn.Send("god", false);
                    picGodMode.ImageLocation = "https://vgy.me/f2yjSd.png";
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                worldID = txtWorld.Text; email = txtEmail.Text; pass = txtPass.Text;
                try
                {
                    client = PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", email, pass, null);
                    conn = client.Multiplayer.CreateJoinRoom((worldID.ToLower().StartsWith("ow") ? worldID.Replace("-", "") : worldID), (worldID.ToLower().StartsWith("bw") ? "Beta" : "Everybodyedits") + client.BigDB.Load("config", "config")["version"], true, null, null);
                    conn.OnMessage += new MessageReceivedEventHandler(OnMessage);
                    conn.OnDisconnect += new DisconnectEventHandler(OnDisconnect);
                    W8(200);
                    conn.Send("init");
                    btnConnect.Text = "Disconnect";
                    connected = true;
                    BinaryWrite(BinaryItem.Settings);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            else
            {
                W8(100);
                conn.Disconnect();
                isOwner = false;
                connected = false;
                Reports = new Dictionary<string, int>();
                lstReports.Items.Clear();
                canEdit = false;
                lstOnline.Items.Clear();
                rtbChat.Text = "";
                btnConnect.Text = "Connect";
            }
        }

        private void btnLoginHelp_Click(object sender, EventArgs e)
        {
            ShowHelp("Enter your username, password and the world ID of the level to which you want to connect.\nThis bot does not collect emails and passwords (or even world IDs for that matter) in any way. You can be 100% sure that your account data is safe.");
        }

        private void btnAddSnake_Click(object sender, EventArgs e)
        {
            if (txtCustomSnake.Text != "")
            {
                ParseSnake(txtCustomSnake.Text);
                txtCustomSnake.Text = "";
            }
            else
            {
                ShowError("Write a custom snake first.");
            }
        }

        private void btnLoadTheme_Click(object sender, EventArgs e)
        {
            try
            {
                string themeName = (string)lstThemes.SelectedItem;
                Theme apply;
                foreach (var theme in Themes)
                {
                    if (theme.Name == themeName)
                    {
                        apply = theme;
                        using (var bw = new BinaryWriter(File.Open(Application.StartupPath + "\\config\\theme.dat", FileMode.Create)))
                        {
                            apply.Save(bw);
                        }
                        BinaryRead(BinaryItem.Config);
                        break;
                    }
                }
            }
            catch { ShowError("Select a theme first to load it."); }
        }

        private void btnRemoveTheme_Click(object sender, EventArgs e)
        {
            try
            {
                string themeName = (string)lstThemes.SelectedItem;
                foreach (var theme in Themes)
                {
                    if (theme.Name == themeName)
                    {
                        Themes.Remove(theme);
                        lstThemes.Items.Remove(themeName);
                        break;
                    }
                }
                BinaryWrite(BinaryItem.Themes);
            }
            catch { ShowError("Select an item first to remove it."); }
        }

        private void btnRefreshThemes_Click(object sender, EventArgs e)
        {
            BinaryRead(BinaryItem.Themes);
        }
        #endregion

        #region Others
        private void Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryWrite(BinaryItem.All);
        }

        private void Bot_Load(object sender, EventArgs e)
        {
            BinaryRead(BinaryItem.All);
            UpdateCheck();
        }

        private void txtSayMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && connected)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Say(txtSayMain.Text);
                txtSayMain.Text = "";
                rtbChat.SelectionStart = rtbChat.Text.Length;
                rtbChat.ScrollToCaret();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && connected)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                conn.Send("access", txtCode.Text);
            }
        }
        #endregion

        #endregion
    }

    public enum BinaryItem
    {
        Config,
        Admins,
        Bans,
        Comments,
        Settings,
        Snakes,
        Themes,
        All
    }
}

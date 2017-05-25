using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace _1448_Bot
{
    public partial class ThemeCreator : Form
    {
        public ThemeCreator()
        {
            InitializeComponent();
        }

        public Color Bg, Fg, BgTxt, FgTxt, BgBtn, FgBtn;
        public Dictionary<string, string> Auras = new Dictionary<string, string>();

        public static void WriteColour(BinaryWriter bw, Color c)
        {
            bw.Write((int)c.R);
            bw.Write((int)c.G);
            bw.Write((int)c.B);
        }

        private void btnMainBG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                Bg = colDialogue.Color;
                numMainR.Value = Bg.R;
                numMainG.Value = Bg.G;
                numMainB.Value = Bg.B;
                panMain.BackColor = Bg;
            }
        }

        private void btnMainFG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                Fg = colDialogue.Color;
                numForeR.Value = Fg.R;
                numForeG.Value = Fg.G;
                numForeB.Value = Fg.B;
                lblPreFg.ForeColor = Fg;
            }
        }

        private void btnTxtBG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                BgTxt = colDialogue.Color;
                numTxtBGR.Value = BgTxt.R;
                numTxtBGG.Value = BgTxt.G;
                numTxtBGB.Value = BgTxt.B;
                panTxt.BackColor = BgTxt;
            }
        }

        private void btnTxtFG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                FgTxt = colDialogue.Color;
                numTxtFGR.Value = FgTxt.R;
                numTxtFGG.Value = FgTxt.G;
                numTxtFGB.Value = FgTxt.B;
                lblPreFgTxt.ForeColor = FgTxt;
            }
        }

        private void btnBtnBG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                BgBtn = colDialogue.Color;
                numBtnBGR.Value = BgBtn.R;
                numBtnBGG.Value = BgBtn.G;
                numBtnBGB.Value = BgBtn.B;
                panBtn.BackColor = BgBtn;
            }
        }

        private void btnBtnFG_Click(object sender, EventArgs e)
        {
            var res = colDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                FgBtn = colDialogue.Color;
                numBtnFGR.Value = FgBtn.R;
                numBtnFGG.Value = FgBtn.G;
                numBtnFGB.Value = FgBtn.B;
                lblPreFgBtn.ForeColor = FgBtn;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.StartsWith("["))
            {
                using (var bw = new BinaryWriter(File.Open(Application.StartupPath + "\\1448-data\\themes.dat", FileMode.Open)))
                {
                    bw.Seek(0, SeekOrigin.End);
                    bw.Write(txtName.Text);
                    WriteColour(bw, Bg);
                    WriteColour(bw, Fg);
                    WriteColour(bw, BgTxt);
                    WriteColour(bw, FgTxt);
                    WriteColour(bw, BgBtn);
                    WriteColour(bw, FgBtn);
                    bw.Write(Auras[(string)comGodmode.SelectedItem]);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("You can't declare theme names starting with a '[' sign.\nThat right is reserved for default themes.", "Bot1448 > Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateColour(object sender, EventArgs e)
        {
            var num = (NumericUpDown)sender;
            switch ((string)num.Tag)
            {
                case "mainbg":
                    panMain.BackColor = Color.FromArgb((int)numMainR.Value, (int)numMainG.Value, (int)numMainB.Value);
                    picGod.BackColor = Color.FromArgb((int)numMainR.Value, (int)numMainG.Value, (int)numMainB.Value);
                    break;
                case "mainfg":
                    lblPreFg.ForeColor = Color.FromArgb((int)numForeR.Value, (int)numForeG.Value, (int)numForeB.Value);
                    break;
                case "txtbg":
                    panTxt.BackColor = Color.FromArgb((int)numTxtBGR.Value, (int)numTxtBGG.Value, (int)numTxtBGB.Value);
                    break;
                case "txtfg":
                    lblPreFgTxt.ForeColor = Color.FromArgb((int)numTxtFGR.Value, (int)numTxtFGG.Value, (int)numTxtFGB.Value);
                    break;
                case "btnbg":
                    panBtn.BackColor = Color.FromArgb((int)numBtnBGR.Value, (int)numBtnBGG.Value, (int)numBtnBGB.Value);
                    break;
                case "btnfg":
                    lblPreFgBtn.ForeColor = Color.FromArgb((int)numBtnFGR.Value, (int)numBtnFGG.Value, (int)numBtnFGB.Value);
                    break;
            }
        }

        private void ThemeCreator_Load(object sender, EventArgs e)
        {
            Auras.Add("White", "https://vgy.me/PmNl33.png");
            Auras.Add("Red", "https://vgy.me/R6VOBW.png");
            Auras.Add("Pink", "https://vgy.me/aAcSpv.png");
            Auras.Add("Cyan", "https://vgy.me/aBeSCs.png");
            Auras.Add("Gold", "https://vgy.me/EX2K6Y.png");
        }

        private void comGodmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                picGod.ImageLocation = Auras[(string)comGodmode.SelectedItem];
            }
            catch { MessageBox.Show((string)comGodmode.SelectedItem); }
        }
    }
}

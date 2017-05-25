using System;
using System.Drawing;
using System.IO;

namespace _1448_Bot
{
    public class Theme
    {
        public Theme(string name, Color mbg, Color mfg, Color tbg, Color tfg, Color bbg, Color bfg, string god)
        {
            Name = name;
            MainBG = mbg;
            MainFG = mfg;
            TextBG = tbg;
            TextFG = tfg;
            BtnBG = bbg;
            BtnFG = bfg;
            GodAura = god;
        }
        public string Name { get; protected set; }
        public Color MainBG { get; protected set; }
        public Color MainFG { get; protected set; }
        public Color TextBG { get; protected set; }
        public Color TextFG { get; protected set; }
        public Color BtnBG { get; protected set; }
        public Color BtnFG { get; protected set; }
        public string GodAura { get; protected set; }

        public void Save(BinaryWriter bw)
        {
            bw.Write(Name);
            ThemeCreator.WriteColour(bw, MainBG);
            ThemeCreator.WriteColour(bw, MainFG);
            ThemeCreator.WriteColour(bw, TextBG);
            ThemeCreator.WriteColour(bw, TextFG);
            ThemeCreator.WriteColour(bw, BtnBG);
            ThemeCreator.WriteColour(bw, BtnFG);
            bw.Write(GodAura);
        }
    }
}

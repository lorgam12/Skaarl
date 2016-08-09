using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Godlike_Draven
{
    class KMenu
    {
        public static Menu Main, Axe, Combo, Harass, Lane, Jungle, Steal, Misc, Settings;

        public static void Initialize()
        {
            // Main Menu
            Main = MainMenu.AddMenu("Godlike Draven", "KDMain");
            Main.AddGroupLabel("Thank you for choosing Godlike Draven!");
            Main.AddLabel("If you see a bug or have an idea, please post it on the forum thread!");
            Main.AddSeparator(1);
            Main.AddGroupLabel("Hit Chances");
            Main.Add("hitchanceE", new ComboBox("E Hitchance", 1, "High", "Medium", "Low"));
            Main.Add("hitchanceR", new ComboBox("R Hitchance", 1, "High", "Medium", "Low"));
            Main.AddSeparator(5);
            Main.AddLabel("Warning: If you set hitchances to high the spells will be used rarely. Medium is recommended!");

            // Axe Menu
            Axe = Main.AddSubMenu("Axe Settings", "KDAxe");
            Axe.Add("axeMode", new ComboBox("Axe Catch Mode", 0, "Always", "On Combo", "Never"));
            Axe.AddSeparator(1);
            Axe.Add("axeMaximum", new Slider("Maximum Axes", 2, 1, 3));
            Axe.Add("axeRange", new Slider("Axe Catch Range", 350, 200, 800));
            Axe.Add("axeDelay", new Slider("Axe Catch Delay", 250, 0, 500));
            Axe.AddSeparator(1);
            Axe.Add("axeLimit1", new CheckBox("Use W if Axe is too far"));
            Axe.Add("axeLimit2", new CheckBox("Don't catch Axe while under turret"));

            // Combo Menu
            Combo = Main.AddSubMenu("Combo", "KDCombo");
            Combo.AddGroupLabel("Skills");
            Combo.Add("KDcomboQ", new CheckBox("Use Q"));
            Combo.Add("KDcomboW", new CheckBox("Use W"));
            Combo.Add("KDcomboE", new CheckBox("Use E"));
            Combo.Add("KDcomboR", new CheckBox("Use R"));
            Combo.AddSeparator(1);
            Combo.AddGroupLabel("Additional Features");
            Combo.AddLabel("This champion doesen't have any additional feature for Combo mode (for now!).");

            // Harass Menu
            Harass = Main.AddSubMenu("Harass", "KDHarass");
            Harass.AddGroupLabel("Skills");
            Harass.Add("KDharassQ", new CheckBox("Use Q"));
            Harass.Add("KDharassW", new CheckBox("Use W"));
            Harass.Add("KDharassE", new CheckBox("Use E", false));
            Harass.AddSeparator(1);
            Harass.AddGroupLabel("Additional Features");
            Harass.Add("KDharassM", new Slider("Minimum mana for using skills (%)", 70, 0, 100));

            // Lane Clear Menu
            Lane = Main.AddSubMenu("Lane Clear", "KDLane");
            Lane.AddGroupLabel("Skills");
            Lane.Add("KDlaneQ", new CheckBox("Use Q"));
            Lane.Add("KDlaneW", new CheckBox("Use W", false));
            Lane.AddSeparator(1);
            Lane.AddGroupLabel("Additional Features");
            Lane.Add("KDlaneM", new Slider("Minimum mana for using skills (%)", 50, 0, 100));

            // Jungle Clear Menu
            Jungle = Main.AddSubMenu("Jungle Clear", "KDJungle");
            Jungle.AddGroupLabel("Skills");
            Jungle.Add("KDjungleQ", new CheckBox("Use Q"));
            Jungle.Add("KDjungleW", new CheckBox("Use W"));
            Jungle.AddSeparator(1);
            Jungle.AddGroupLabel("Additional Features");
            Jungle.Add("KDjungleM", new Slider("Minimum mana for using skills (%)", 50, 0, 100));

            // Kill Steal Menu
            Steal = Main.AddSubMenu("Kill Steal", "KDSteal");
            Steal.AddGroupLabel("Skills");
            Steal.Add("KDstealE", new CheckBox("Steal with E"));
            Steal.Add("KDstealR", new CheckBox("Steal with R"));
            Steal.Add("KDstealRlimit", new Slider("Maximumu range for kill steal with R", 2000, 500, 3000));

            // Misc Menu
            Misc = Main.AddSubMenu("Misc", "KDMisc");
            Misc.AddGroupLabel("Flee");
            Misc.Add("KDfleeW", new CheckBox("Use W"));
            Misc.Add("KDfleeE", new CheckBox("Use E"));
            Misc.AddSeparator(1);
            Misc.AddGroupLabel("Life Saver");
            //Misc.Add("KAmiscUseH", new CheckBox("Use Heal"));
            //Misc.Add("KAmiscUseB", new CheckBox("Use Barrier"));
            //Misc.Add("KAmiscUseQ", new CheckBox("Use QSS"));
            Misc.Add("KDInterrupt", new CheckBox("Interrupt important spells with E"));
            Misc.Add("KDGap", new CheckBox("Anti Gapclose with E"));

            // Settings Menu
            Settings = Main.AddSubMenu("Settings", "KDSettings");
            Settings.AddGroupLabel("Drawings");
            Settings.Add("KDDrawAA", new CheckBox("Draw AA"));
            Settings.Add("KDDrawE", new CheckBox("Draw E"));
            Settings.Add("KDDrawAxe", new CheckBox("Draw Axe"));
            Settings.Add("KDDrawAxeRange", new CheckBox("Draw Axe Catch Range"));
            Settings.AddSeparator(1);
            Settings.AddGroupLabel("Skin Changer");
            Settings.Add("skinEnable", new CheckBox("Enable"));
            Settings.Add("skinID", new ComboBox("Current Skin", 5, "Default Draven", "Soul Reaver Draven", "Gladiator Draven", "Primetime Draven", "Pool Party Draven", "Beast Hunter Draven", "Draven Draven"));
        }

        // Main Menu
        public static int hitchanceE { get { return Main["hitchanceE"].Cast<ComboBox>().CurrentValue; } }
        public static int hitchanceR { get { return Main["hitchanceR"].Cast<ComboBox>().CurrentValue; } }

        // Axe Menu
        public static int axeMode { get { return Axe["axeMode"].Cast<ComboBox>().CurrentValue; } }
        public static int axeMaximum { get { return Axe["axeMaximum"].Cast<Slider>().CurrentValue; } }
        public static int axeRange { get { return Axe["axeRange"].Cast<Slider>().CurrentValue; } }
        public static int axeDelay { get { return Axe["axeDelay"].Cast<Slider>().CurrentValue; } }
        public static bool axeLimit1 { get { return Axe["axeLimit1"].Cast<CheckBox>().CurrentValue; } }
        public static bool axeLimit2 { get { return Axe["axeLimit2"].Cast<CheckBox>().CurrentValue; } }

        // Combo Menu
        public static bool KDcomboQ { get { return Combo["KDcomboQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDcomboW { get { return Combo["KDcomboW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDcomboE { get { return Combo["KDcomboW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDcomboR { get { return Combo["KDcomboR"].Cast<CheckBox>().CurrentValue; } }

        // Harras Menu
        public static bool KDharassQ { get { return Harass["KDharassQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDharassW { get { return Harass["KDharassW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDharassE { get { return Harass["KDharassE"].Cast<CheckBox>().CurrentValue; } }
        public static int KDharassM { get { return Harass["KDharassM"].Cast<Slider>().CurrentValue; } }

        // Lane Clear Menu
        public static bool KDlaneQ { get { return Lane["KDlaneQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDlaneW { get { return Lane["KDlaneW"].Cast<CheckBox>().CurrentValue; } }
        public static int KDlaneM { get { return Lane["KDlaneM"].Cast<Slider>().CurrentValue; } }

        // Jungle Clear Menu
        public static bool KDjungleQ { get { return Jungle["KDjungleQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDjungleW { get { return Jungle["KDjungleW"].Cast<CheckBox>().CurrentValue; } }
        public static int KDjungleM { get { return Jungle["KDjungleM"].Cast<Slider>().CurrentValue; } }

        // Kill Steal Menu
        public static bool KDstealE { get { return Steal["KDstealE"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDstealR { get { return Steal["KDstealR"].Cast<CheckBox>().CurrentValue; } }
        public static int KDstealRlimit { get { return Steal["KDstealRlimit"].Cast<Slider>().CurrentValue; } }

        // Misc Menu
        public static bool KDfleeW { get { return Misc["KDfleeW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDfleeE { get { return Misc["KDfleeE"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDInterrupt { get { return Misc["KDInterrupt"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDGap { get { return Misc["KDGap"].Cast<CheckBox>().CurrentValue; } }

        // Settings Menu
        public static bool KDDrawAA { get { return Settings["KDDrawAA"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDDrawE { get { return Settings["KDDrawE"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDDrawAxe { get { return Settings["KDDrawAxe"].Cast<CheckBox>().CurrentValue; } }
        public static bool KDDrawAxeRange { get { return Settings["KDDrawAxeRange"].Cast<CheckBox>().CurrentValue; } }
        public static bool skinEnable { get { return Settings["skinEnable"].Cast<CheckBox>().CurrentValue; } }
        public static int skinID { get { return Settings["skinID"].Cast<ComboBox>().CurrentValue; } }
    }
}

using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Godlike_Ashe
{
    class KMenu
    {
        public static Menu Main, Combo, Harass, Lane, Jungle, Steal, Misc, Settings;

        public static void Initialize()
        {
            // Main Menu
            Main = MainMenu.AddMenu("Godlike Ashe", "KAMain");
            Main.AddGroupLabel("Thank you for choosing Godlike Ashe!");
            Main.AddLabel("If you see a bug or have an idea, please post it on the forum thread!");
            Main.AddSeparator(1);
            Main.AddGroupLabel("Hitchances");
            Main.Add("hitchanceW", new ComboBox("W Hitchance", 1, "High", "Medium", "Low"));
            Main.Add("hitchanceR", new ComboBox("R Hitchance", 1, "High", "Medium", "Low"));
            Main.AddLabel("Medium for both is recommended.");

            // Combo Menu
            Combo = Main.AddSubMenu("Combo", "KACombo");
            Combo.AddGroupLabel("Skills");
            Combo.Add("KAcomboQ", new CheckBox("Use Q"));
            Combo.Add("KAcomboW", new CheckBox("Use W"));
            Combo.Add("KAcomboR", new CheckBox("Use R"));
            Combo.Add("KAcomboSR", new CheckBox("Enable Smart R"));
            Combo.AddSeparator(1);
            Combo.AddGroupLabel("Additional Features");
            Combo.Add("KAcomboQlimit", new Slider("Minimum enemy for Q", 1, 1, 5));
            Combo.AddSeparator(1);
            Combo.Add("KAcomboBOTRK", new CheckBox("Use BOTRK and Bilgewater Cutlass"));
            Combo.Add("KAcomboYOUMUU", new CheckBox("Use Youmuu's Ghostblade"));
            Combo.Add("KAcomboYOUMUUlimit", new Slider("Minimum enemy for Youmuu's Ghostblade", 2, 1, 5));

            // Harras Menu
            Harass = Main.AddSubMenu("Harras", "KAHarras");
            Harass.AddGroupLabel("Skills");
            Harass.Add("KAharassQ", new CheckBox("Use Q"));
            Harass.Add("KAharassW", new CheckBox("Use W"));
            Harass.AddSeparator(1);
            Harass.AddGroupLabel("Additional Features");
            Harass.Add("KAharassM", new Slider("Minimum mana for using skills (%)", 70, 0, 100));
            Harass.Add("KAharassQlimit", new Slider("Minimum enemy for Q", 2, 1, 6));

            // Lane Clear Menu
            Lane = Main.AddSubMenu("Lane Clear", "KALane");
            Lane.AddGroupLabel("Skills");
            Lane.Add("KAlaneQ", new CheckBox("Use Q"));
            Lane.Add("KAlaneW", new CheckBox("Use W"));
            Lane.AddSeparator(1);
            Lane.AddGroupLabel("Additional Features");
            Lane.Add("KAlaneM", new Slider("Minimum mana for using skills (%)", 70, 0, 100));
            Lane.Add("KAlaneQlimit", new Slider("Minimum minion for Q", 4, 1, 40));
            Lane.Add("KAlaneWlimit", new Slider("Minimum minion for W", 3, 1, 40));

            // Jungle Clear Menu
            Jungle = Main.AddSubMenu("Jungle Clear", "KAJungle");
            Jungle.AddGroupLabel("Skills");
            Jungle.Add("KAjungleQ", new CheckBox("Use Q"));
            Jungle.Add("KAjungleW", new CheckBox("Use W"));
            Jungle.AddSeparator(1);
            Jungle.AddGroupLabel("Additional Features");
            Jungle.Add("KAjungleM", new Slider("Minimum mana for using skills (%)", 70, 0, 100));

            // Kill Steal Menu
            Steal = Main.AddSubMenu("Kill Steal", "KASteal");
            Steal.AddGroupLabel("Skills");
            Steal.Add("KAstealW", new CheckBox("Steal with W"));
            Steal.Add("KAstealR", new CheckBox("Steal with R"));
            Steal.Add("KAstealRlimit", new Slider("Maximumu range for kill steal with R", 1500, 500, 3000));
            
            // Misc Menu
            Misc = Main.AddSubMenu("Misc", "KAMisc");
            Misc.AddGroupLabel("Flee");
            Misc.Add("KAfleeW", new CheckBox("Use W"));
            Misc.AddSeparator(1);
            Misc.AddGroupLabel("Life Saver");
            Misc.Add("KAInterrupt", new CheckBox("Interrupt important spells with R"));
            Misc.Add("KAGap", new CheckBox("Anti Gapclose with W"));
            //Misc.Add("KAUseHEA", new CheckBox("Use Heal"));
            //Misc.Add("KAUseBAR", new CheckBox("Use Barrier"));
            //Misc.Add("KAUseQSS", new CheckBox("Use QSS"));
            Misc.AddSeparator(1);
            Misc.AddGroupLabel("Auto W Usage");
            Misc.Add("KAautoWE", new CheckBox("Enable"));
            Misc.Add("KAautoWlimit", new CheckBox("Disable while under enemy turret"));
            //Misc.Add("KAautoWlimit1", new CheckBox("Disable 'Auto W' while stealth"));
            Misc.Add("KAautoWM", new Slider("Minimum mana for automatic W usage (%)", 75, 0, 100));
            Misc.AddSeparator(1);
            Misc.AddGroupLabel("Hawkshot (E)");
            Misc.Add("hawkDragon", new KeyBind("Cast Hawkshot (E) to Dragon", false, KeyBind.BindTypes.HoldActive, 'U'));
            Misc.Add("hawkBaron", new KeyBind("Cast Hawkshot (E) to Baron", false, KeyBind.BindTypes.HoldActive, 'I'));
            Misc.Add("hawkEnable", new CheckBox("Enable"));


            // Settings Menu
            Settings = Main.AddSubMenu("Settings", "KASettings");
            Settings.AddGroupLabel("Drawings");
            Settings.Add("KADrawAA", new CheckBox("Draw AA"));
            Settings.Add("KADrawW", new CheckBox("Draw W"));
            Settings.AddSeparator(1);
            Settings.AddGroupLabel("Skin Changer");
            Settings.Add("skinEnable", new CheckBox("Enable"));
            Settings.Add("skinID", new ComboBox("Current Skin", 8, "Default Ashe", "Freljord Ashe", "Sherwood Forest Ashe", "Woad Ashe", "Queen Ashe", "Amethyst Ashe", "Heartseeker Ashe", "Marauder Ashe", "PROJECT: Ashe"));
        }

        // Main Menu
        public static int hitchanceW { get { return Main["hitchanceW"].Cast<ComboBox>().CurrentValue; } }
        public static int hitchanceR { get { return Main["hitchanceR"].Cast<ComboBox>().CurrentValue; } }

        // Combo Menu
        public static bool KAcomboQ { get { return Combo["KAcomboQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAcomboW { get { return Combo["KAcomboW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAcomboR { get { return Combo["KAcomboR"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAcomboSR { get { return Combo["KAcomboSR"].Cast<CheckBox>().CurrentValue; } }
        public static int KAcomboQlimit { get { return Combo["KAcomboQlimit"].Cast<Slider>().CurrentValue; } }
        public static bool KAcomboBOTRK { get { return Combo["KAcomboBOTRK"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAcomboYOUMUU { get { return Combo["KAcomboYOUMUU"].Cast<CheckBox>().CurrentValue; } }
        public static int KAcomboYOUMUUlimit { get { return Combo["KAcomboYOUMUUlimit"].Cast<Slider>().CurrentValue; } }

        // Harras Menu
        public static bool KAharassQ { get { return Harass["KAharassQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAharassW { get { return Harass["KAharassW"].Cast<CheckBox>().CurrentValue; } }
        public static int KAharassM { get { return Harass["KAharassM"].Cast<Slider>().CurrentValue; } }
        public static int KAharassQlimit { get { return Harass["KAharassQlimit"].Cast<Slider>().CurrentValue; } }
        
        // Lane Clear Menu
        public static bool KAlaneQ { get { return Lane["KAlaneQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAlaneW { get { return Lane["KAlaneW"].Cast<CheckBox>().CurrentValue; } }
        public static int KAlaneM { get { return Lane["KAlaneM"].Cast<Slider>().CurrentValue; } }
        public static int KAlaneQlimit { get { return Lane["KAlaneQlimit"].Cast<Slider>().CurrentValue; } }
        public static int KAlaneWlimit { get { return Lane["KAlaneWlimit"].Cast<Slider>().CurrentValue; } }

        // Jungle Clear Menu
        public static bool KAjungleQ { get { return Jungle["KAjungleQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAjungleW { get { return Jungle["KAjungleW"].Cast<CheckBox>().CurrentValue; } }
        public static int KAjungleM { get { return Jungle["KAjungleM"].Cast<Slider>().CurrentValue; } }

        // Kill Steal Menu
        public static bool KAstealW { get { return Steal["KAstealW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAstealR { get { return Steal["KAstealR"].Cast<CheckBox>().CurrentValue; } }
        public static int KAstealRlimit { get { return Steal["KAstealRlimit"].Cast<Slider>().CurrentValue; } }

        // Misc Menu
        public static bool KAfleeW { get { return Misc["KAfleeW"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAInterrupt{ get { return Misc["KAInterrupt"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAGap { get { return Misc["KAGap"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAautoWE { get { return Misc["KAautoWE"].Cast<CheckBox>().CurrentValue; } }
        public static bool KAautoWlimit { get { return Misc["KAautoWlimit"].Cast<CheckBox>().CurrentValue; } }
        //public static bool KAautoWlimit1 { get { return Misc["KAautoWlimit1"].Cast<CheckBox>().CurrentValue; } }
        public static int KAautoWM { get { return Misc["KAautoWM"].Cast<Slider>().CurrentValue; } }
        public static bool hawkEnable { get { return Misc["hawkEnable"].Cast<CheckBox>().CurrentValue; } }

        // Settings Menu
        public static bool KADrawAA { get { return Settings["KADrawAA"].Cast<CheckBox>().CurrentValue; } }
        public static bool KADrawW { get { return Settings["KADrawW"].Cast<CheckBox>().CurrentValue; } }
        public static bool skinEnable { get { return Settings["skinEnable"].Cast<CheckBox>().CurrentValue; } }
        public static int skinID { get { return Settings["skinID"].Cast<ComboBox>().CurrentValue; } }

    }
}

using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Godlike_Vel_Koz
{
    class Manager
    {
        public static Menu KVMain, KVCombo, KVHarras, KVUltimate, KVLaneClear, KVJungleClear, KVKillSteal, KVDrawings, KVMisc;

        public static void Initialize()
        {
            // Main menu.
            KVMain = MainMenu.AddMenu("Kled's Vel'Koz", "KVMain");
            KVMain.AddGroupLabel("Kled's Vel'Koz");
            KVMain.AddLabel("If you see a bug don't forget to report it!");
            KVMain.AddSeparator(1);
            KVMain.AddGroupLabel("Hit Chances");
            KVMain.Add("hitchanceQ", new ComboBox("Q Hitchance", 1, "High", "Medium", "Low"));
            KVMain.Add("hitchanceW", new ComboBox("W Hitchance", 0, "High", "Medium", "Low"));
            KVMain.Add("hitchanceE", new ComboBox("E Hitchance", 0, "High", "Medium", "Low"));
            KVMain.Add("hitchanceR", new ComboBox("R Hitchance", 0, "High", "Medium", "Low"));
            KVMain.AddLabel("Press F5 after changing hitchance values.");

            // Combo menu.
            KVCombo = KVMain.AddSubMenu("Combo", "KVCombo");
            KVCombo.AddGroupLabel("Combo");
            KVCombo.AddLabel("Skills");
            KVCombo.Add("comboQ", new CheckBox("Use Q"));
            KVCombo.Add("comboW", new CheckBox("Use W"));
            KVCombo.Add("comboE", new CheckBox("Use E"));
            KVCombo.Add("comboR", new CheckBox("Use R"));
            KVCombo.AddSeparator(1);
            KVCombo.AddLabel("Additional Features");
            KVCombo.Add("combolimitW", new CheckBox("Use W only if enemy is knocked.", false));
            KVCombo.Add("combolimitE", new CheckBox("Use E only if enemy is slowed.", false));
            KVCombo.Add("combolimitR", new CheckBox("Use R only if other spells are on cooldown.", false));
            KVCombo.Add("combolimitR1", new Slider("Minimum enemy to use R", 3, 1, 5));

            // Harras menu.
            KVHarras = KVMain.AddSubMenu("Harras", "KVHarras");
            KVHarras.AddGroupLabel("Harras");
            KVHarras.AddLabel("Skills");
            KVHarras.Add("harrasQ", new CheckBox("Use Q"));
            KVHarras.Add("harrasW", new CheckBox("Use W"));
            KVHarras.Add("harrasE", new CheckBox("Use E"));
            KVHarras.AddSeparator(1);
            KVHarras.AddLabel("Additional Features");
            KVHarras.Add("harrasM", new Slider("Minimum mana to use skills (%)", 25));
            KVHarras.Add("harraslimitW", new CheckBox("Use W only if enemy is knocked.", false));
            KVHarras.Add("harraslimitE", new CheckBox("Use E only if enemy is slowed.", false));

            // Ultimate menu.
            KVUltimate = KVMain.AddSubMenu("Ultimate", "KVUltimate");
            KVUltimate.AddGroupLabel("Ultimate");
            KVUltimate.AddLabel("Ultimate follower follows the selected target.");
            KVUltimate.Add("followR", new CheckBox("Enable Ultimate Follower"));
            KVUltimate.Add("followMinions", new CheckBox("Follow minions if there is no enemy.", false));

            // Lane Clear menu.
            KVLaneClear = KVMain.AddSubMenu("Lane Clear", "KVLaneClear");
            KVLaneClear.AddGroupLabel("Lane Clear");
            KVLaneClear.AddLabel("Skills");
            KVLaneClear.Add("laneclearQ", new CheckBox("Use Q"));
            KVLaneClear.Add("laneclearW", new CheckBox("Use W"));
            KVLaneClear.Add("laneclearE", new CheckBox("Use E"));
            KVLaneClear.AddSeparator(1);
            KVLaneClear.AddLabel("Additional Features");
            KVLaneClear.Add("laneclearM", new Slider("Minimum mana to use skills (%)", 25));
            KVLaneClear.Add("laneclearlimitW", new Slider("Minimum minion hits for W", 4, 1, 20));
            KVLaneClear.Add("laneclearlimitE", new Slider("Minimum minion hits for E", 3, 1, 20));

            // Jungle Clear menu.
            KVJungleClear = KVMain.AddSubMenu("Jungle Clear", "KVJungleClear");
            KVJungleClear.AddGroupLabel("Jungle Clear");
            KVJungleClear.AddLabel("Skills");
            KVJungleClear.Add("jungleclearQ", new CheckBox("Use Q"));
            KVJungleClear.Add("jungleclearW", new CheckBox("Use W"));
            KVJungleClear.Add("jungleclearE", new CheckBox("Use E"));
            KVJungleClear.AddSeparator(1);
            KVJungleClear.AddLabel("Additional Features");
            KVJungleClear.Add("jungleclearM", new Slider("Minimum mana to use skills (%)", 25));
            KVJungleClear.Add("jungleclearlimitW", new Slider("Minimum monster hits for W", 1, 1, 20));
            KVJungleClear.Add("jungleclearlimitE", new Slider("Minimum monster hits for E", 1, 1, 20));

            // Kill Steal menu.
            KVKillSteal = KVMain.AddSubMenu("Kill Steal", "KVKillSteal");
            KVKillSteal.AddGroupLabel("Kill Steal");
            KVKillSteal.Add("killstealEnable", new CheckBox("Enable Kill Steal"));
            KVKillSteal.AddLabel("Skills");
            KVKillSteal.Add("killstealQ", new CheckBox("Use Q"));
            KVKillSteal.Add("killstealW", new CheckBox("Use W"));
            KVKillSteal.Add("killstealE", new CheckBox("Use E"));
            KVKillSteal.Add("killstealR", new CheckBox("Use R"));
            KVKillSteal.AddSeparator(1);
            KVKillSteal.AddLabel("Additional Features");
            KVKillSteal.Add("killsteallimitR", new Slider("Minimum enemy to use R", 1, 1, 5));

            // Drawings menu.
            KVDrawings = KVMain.AddSubMenu("Drawings", "KVDrawings");
            KVDrawings.AddGroupLabel("Drawings");
            KVDrawings.AddLabel("Skills");
            KVDrawings.Add("drawingsQW", new CheckBox("Draw Q and W"));
            KVDrawings.Add("drawingsE", new CheckBox("Draw E"));
            KVDrawings.Add("drawingsR", new CheckBox("Draw R"));

            // Misc menu.
            KVMisc = KVMain.AddSubMenu("Misc", "KVMisc");
            KVMisc.AddGroupLabel("Misc");
            KVMisc.AddLabel("Skin Changer");
            KVMisc.Add("skinsEnable", new CheckBox("Enable Skin Changer"));
            KVMisc.Add("skinsNumber", new Slider("Skin Designer: ", 0, 0, 3));
            KVMisc.AddSeparator(1);
            KVMisc.AddLabel("Interrupter");
            KVMisc.Add("interrupterEnable", new CheckBox("Enable Interrupter with E"));
            KVMisc.AddSeparator(1);
            KVMisc.AddLabel("Gap Closer");
            KVMisc.Add("gapEnable", new CheckBox("Enable Gap Closer with E"));
            KVMisc.AddSeparator(1);
            KVMisc.AddLabel("OH DARN");
            KVMisc.Add("ohdarnEnable", new CheckBox("Enable OH DARN sound on kill", false));
        }

        // Hit Chances
        public static int hitchanceQ { get { return KVMain["hitchanceQ"].Cast<ComboBox>().CurrentValue; } }
        public static int hitchanceW { get { return KVMain["hitchanceW"].Cast<ComboBox>().CurrentValue; } }
        public static int hitchanceE { get { return KVMain["hitchanceE"].Cast<ComboBox>().CurrentValue; } }
        public static int hitchanceR { get { return KVMain["hitchanceR"].Cast<ComboBox>().CurrentValue; } }

        // Combo menu.
        public static bool comboQ { get { return KVCombo["comboQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool comboW { get { return KVCombo["comboW"].Cast<CheckBox>().CurrentValue; } }
        public static bool comboE { get { return KVCombo["comboE"].Cast<CheckBox>().CurrentValue; } }
        public static bool comboR { get { return KVCombo["comboR"].Cast<CheckBox>().CurrentValue; } }
        public static bool combolimitW { get { return KVCombo["combolimitW"].Cast<CheckBox>().CurrentValue; } }
        public static bool combolimitE { get { return KVCombo["combolimitE"].Cast<CheckBox>().CurrentValue; } }
        public static bool combolimitR { get { return KVCombo["combolimitR"].Cast<CheckBox>().CurrentValue; } }
        public static int combolimitR1 { get { return KVCombo["combolimitR1"].Cast<Slider>().CurrentValue; } }

        // Harras menu.
        public static bool harrasQ { get { return KVHarras["harrasQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool harrasW { get { return KVHarras["harrasW"].Cast<CheckBox>().CurrentValue; } }
        public static bool harrasE { get { return KVHarras["harrasE"].Cast<CheckBox>().CurrentValue; } }
        public static int harrasM { get { return KVHarras["harrasM"].Cast<Slider>().CurrentValue; } }
        public static bool harraslimitW { get { return KVHarras["harraslimitW"].Cast<CheckBox>().CurrentValue; } }
        public static bool harraslimitE { get { return KVHarras["harraslimitE"].Cast<CheckBox>().CurrentValue; } }

        // Lane Clear menu.
        public static bool laneclearQ { get { return KVLaneClear["laneclearQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool laneclearW { get { return KVLaneClear["laneclearW"].Cast<CheckBox>().CurrentValue; } }
        public static bool laneclearE { get { return KVLaneClear["laneclearE"].Cast<CheckBox>().CurrentValue; } }
        public static int laneclearM { get { return KVLaneClear["laneclearM"].Cast<Slider>().CurrentValue; } }
        public static int laneclearlimitW { get { return KVLaneClear["laneclearlimitW"].Cast<Slider>().CurrentValue; } }
        public static int laneclearlimitE { get { return KVLaneClear["laneclearlimitE"].Cast<Slider>().CurrentValue; } }

        // Jungle Clear menu.
        public static bool jungleclearQ { get { return KVJungleClear["jungleclearQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool jungleclearW { get { return KVJungleClear["jungleclearW"].Cast<CheckBox>().CurrentValue; } }
        public static bool jungleclearE { get { return KVJungleClear["jungleclearE"].Cast<CheckBox>().CurrentValue; } }
        public static int jungleclearM { get { return KVJungleClear["jungleclearM"].Cast<Slider>().CurrentValue; } }
        public static int jungleclearlimitW { get { return KVJungleClear["jungleclearlimitW"].Cast<Slider>().CurrentValue; } }
        public static int jungleclearlimitE { get { return KVJungleClear["jungleclearlimitE"].Cast<Slider>().CurrentValue; } }

        // Kill Steal menu.
        public static bool killstealEnable { get { return KVKillSteal["killstealEnable"].Cast<CheckBox>().CurrentValue; } }
        public static bool killstealQ { get { return KVKillSteal["killstealQ"].Cast<CheckBox>().CurrentValue; } }
        public static bool killstealW { get { return KVKillSteal["killstealW"].Cast<CheckBox>().CurrentValue; } }
        public static bool killstealE { get { return KVKillSteal["killstealE"].Cast<CheckBox>().CurrentValue; } }
        public static bool killstealR { get { return KVKillSteal["killstealR"].Cast<CheckBox>().CurrentValue; } }
        public static int killsteallimitR { get { return KVKillSteal["killsteallimitR"].Cast<Slider>().CurrentValue; } }

        // Ultimate menu.
        public static bool followR { get { return KVUltimate["followR"].Cast<CheckBox>().CurrentValue; } }
        public static bool followMinions { get { return KVUltimate["followMinions"].Cast<CheckBox>().CurrentValue; } }

        // Drawings menu.
        public static bool drawingsQW { get { return KVDrawings["drawingsQW"].Cast<CheckBox>().CurrentValue; } }
        public static bool drawingsE { get { return KVDrawings["drawingsE"].Cast<CheckBox>().CurrentValue; } }
        public static bool drawingsR { get { return KVDrawings["drawingsR"].Cast<CheckBox>().CurrentValue; } }

        // Misc menu.
        public static bool skinsEnable { get { return KVMisc["skinsEnable"].Cast<CheckBox>().CurrentValue; } }
        public static int skinsNumber { get { return KVMisc["skinsNumber"].Cast<Slider>().CurrentValue; } }
        public static bool interrupterEnable { get { return KVMisc["interrupterEnable"].Cast<CheckBox>().CurrentValue; } }
        public static bool gapEnable { get { return KVMisc["gapEnable"].Cast<CheckBox>().CurrentValue; } }
        public static bool ohdarnEnable { get { return KVMisc["ohdarnEnable"].Cast<CheckBox>().CurrentValue; } }
    }
}

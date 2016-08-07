using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
//using Color = System.Drawing.Color;
using System.Linq;
using System.Media;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK.Enumerations;
using Color = System.Drawing.Color;

namespace Godlike_Ashe
{
    class Program
    {
        public static AIHeroClient User { get { return Player.Instance; } }

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (User.ChampionName != "Ashe") return;

            Chat.Print("Godlike Ashe is loaded.");
            KMenu.Initialize();
            KSpells.Initialize();

            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Interrupter.OnInterruptableSpell += Angel.Interrupt;
            Gapcloser.OnGapcloser += Angel.Gap;
        }

        public static void Game_OnTick(EventArgs args)
        {
            if(KMenu.skinEnable) User.SetSkinId(KMenu.skinID);

            if (User.IsDead) return;

            // Other Modes
            if (KMenu.KAautoWE)
                KModes.AutoW();
            if (KMenu.KAstealW || KMenu.KAstealR)
                KModes.Steal();
            if (KMenu.hawkEnable)
                KModes.CastHowkshot();

            // Orbwalker Modes
            string currentModes = Orbwalker.ActiveModesFlags.ToString();
            if (currentModes.Contains(Orbwalker.ActiveModes.Combo.ToString()))
                KModes.Combo();
            if (currentModes.Contains(Orbwalker.ActiveModes.Harass.ToString()))
                KModes.Harass();
            if (currentModes.Contains(Orbwalker.ActiveModes.LaneClear.ToString()))
                KModes.Lane();
            if (currentModes.Contains(Orbwalker.ActiveModes.JungleClear.ToString()))
                KModes.Jungle();
            if (currentModes.Contains(Orbwalker.ActiveModes.Flee.ToString()))
                KModes.Flee();
        }

        public static void Drawing_OnDraw(EventArgs args)
        {
            if (Game.Time < 15) return;
            if (User.IsDead) return;


            if (KMenu.KADrawAA && KSpells.W.IsLearned)
                Drawing.DrawCircle(User.Position, User.GetAutoAttackRange(), Color.FromArgb(0, 230, 118));
            if (KMenu.KADrawW && KSpells.W.IsLearned)
                Drawing.DrawCircle(User.Position, KSpells.W.Range, Color.FromArgb(33, 150, 243));
        }
    }
}

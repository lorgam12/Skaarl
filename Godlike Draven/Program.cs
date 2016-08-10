using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using System.Linq;
using System.Media;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK.Enumerations;
using Color = System.Drawing.Color;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Godlike_Draven
{
    class Program
    {
        public static AIHeroClient User { get { return Player.Instance; } }

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Load;
        }

        public static void Load(EventArgs args)
        {
            if (User.ChampionName != "Draven") return;

            KMenu.Initialize();
            KSpells.Initialize();

            KModes.QReticles = new List<KModes.QRecticle>();
            Game.OnUpdate += Update;
            Interrupter.OnInterruptableSpell += Angel.Interrupt;
            Gapcloser.OnGapcloser += Angel.Gap;
            Drawing.OnDraw += Draw;
            GameObject.OnCreate += OnCreate;
            GameObject.OnDelete += OnDelete;
        }

        public static void Update(EventArgs args)
        {
            if (KMenu.skinEnable) User.SetSkinId(KMenu.skinID);
            if (User.IsDead) return;

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

            // Other Modes
            if (KMenu.KDstealE || KMenu.KDstealR)
                KModes.Steal();
            if (KMenu.axeMode != 2)
                KModes.Axes();

            //KModes.QReticles.RemoveAll(x => x.Object.IsDead);
        }

        public static void Draw(EventArgs args)
        {
            if (Game.Time < 15 || User.IsDead) return;

            if (KMenu.KDDrawAA)
                Circle.Draw(SharpDX.Color.GreenYellow, User.GetAutoAttackRange(), User.Position);
            if (KMenu.KDDrawE && KSpells.E.IsLearned)
                Circle.Draw(KSpells.E.IsReady() ? SharpDX.Color.GreenYellow : SharpDX.Color.Firebrick, KSpells.E.Range, User.Position);
            if (KMenu.KDDrawAxeRange)
                Circle.Draw(SharpDX.Color.Aquamarine, KMenu.axeRange, Game.CursorPos);
            if (KMenu.KDDrawAxe)
            {
                foreach (var Axe in ObjectManager.Get<GameObject>().Where(x => x.Name.Equals("Draven_Base_Q_reticle_self.troy") && !x.IsDead))
                {
                    Circle.Draw(Axe.IsInRange(Game.CursorPos, KMenu.axeRange) || Axe.Distance(User.Position) < 100 ? SharpDX.Color.GreenYellow : SharpDX.Color.Firebrick, 140, Axe.Position);
                }
            }
        }

        public static void OnCreate(GameObject sender, EventArgs args)
        {
            if (!sender.Name.Contains("Draven_Base_Q_reticle_self.troy")) return;

            KModes.QReticles.Add(new KModes.QRecticle(sender, Environment.TickCount + 1800));
            Core.DelayAction(() => KModes.QReticles.RemoveAll(x => x.Object.NetworkId == sender.NetworkId), 1800);
        }
        public static void OnDelete(GameObject sender, EventArgs args)
        {
            if (!sender.Name.Contains("Draven_Base_Q_reticle_self.troy")) { return; }

            KModes.QReticles.RemoveAll(x => x.Object.NetworkId == sender.NetworkId);
        }
    }
}

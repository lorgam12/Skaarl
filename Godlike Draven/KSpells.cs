using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Diagnostics.CodeAnalysis;

namespace Godlike_Draven
{
    public static class KSpells
    {
        public static AIHeroClient User = Program.User;

        public static Spell.Active Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        public static void Initialize()
        {
            Q = new Spell.Active(SpellSlot.Q, (uint)User.GetAutoAttackRange());
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Skillshot(SpellSlot.E, 1050, SkillShotType.Linear, 250, null, 130);
            R = new Spell.Skillshot(SpellSlot.R, 30000, SkillShotType.Linear, 250, null, 160);
        }

        public static HitChance GetHitChance(string skill)
        {
            int hitchanceValue;

            if (skill == "E")
                hitchanceValue = KMenu.hitchanceE;
            else if (skill == "R")
                hitchanceValue = KMenu.hitchanceR;
            else
                hitchanceValue = 0;

            if (hitchanceValue == 0)
                return HitChance.High;
            else if (hitchanceValue == 1)
                return HitChance.Medium;
            else if (hitchanceValue == 2)
                return HitChance.Low;
            else
                return HitChance.High;
        }

        public static void CastQ()
        {
            if (Q.IsReady())
                Q.Cast();
        }
        public static void CastW()
        {
            if (W.IsReady())
                W.Cast();
        }
        public static void CastE(Obj_AI_Base target)
        {
            if (target == null || target.IsInvulnerable || !target.IsValidTarget() || target.IsDead) return;
            E.MinimumHitChance = GetHitChance("E");
            if (E.IsReady())
                E.Cast(target);
        }
        public static void CastR(Obj_AI_Base target)
        {
            if (target == null || target.IsInvulnerable || !target.IsValidTarget() || target.IsDead) return;
            R.MinimumHitChance = GetHitChance("R");
            if (R.IsReady())
                R.Cast(target);
        }

        public static int QCount
        {
            get
            {
                return (User.HasBuff("dravenspinning") ? 1 : 0)
                       + (User.HasBuff("dravenspinningleft") ? 1 : 0) + KModes.QReticles.Count;
            }
        }
    }
}

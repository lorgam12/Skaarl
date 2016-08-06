using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Godlike_Ashe
{
    public static class KSpells
    {
        public static AIHeroClient User = Program.User;

        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }
        public static Spell.Active HEAL { get; private set; }
        public static Spell.Active BARRIER { get; private set; }

        public static void Initialize()
        {
            Q = new Spell.Active(SpellSlot.Q);
            //W = new Spell.Skillshot(SpellSlot.W, 1200, SkillShotType.Linear, 0, int.MaxValue, 60);
            W = new Spell.Skillshot(SpellSlot.W, 1200, SkillShotType.Cone, 0, 32768, 20)
            {
                AllowedCollisionCount = 1
            };
            E = new Spell.Skillshot(SpellSlot.E, 15000, SkillShotType.Linear, 0, int.MaxValue, 0);
            R = new Spell.Skillshot(SpellSlot.R, 15000, SkillShotType.Linear, 500, 1000, 250);

            var HEALSLOT = User.GetSpellSlotFromName("summonerheal");
            if(HEALSLOT != SpellSlot.Unknown)
                HEAL = new Spell.Active(HEALSLOT, 850);

            var BARRIERSLOT = User.GetSpellSlotFromName("summonerbarrier");
            if (BARRIERSLOT != SpellSlot.Unknown)
                BARRIER = new Spell.Active(BARRIERSLOT, 0);
        }

        public static float WDamage()
        {
            return new float[] { 0, 20, 35, 50, 65, 80 }[W.Level] + 1 * User.FlatPhysicalDamageMod;
        }

        public static float RDamage()
        {
            return new float[] { 0, 250, 425, 600 }[R.Level] + 1 * User.FlatMagicDamageMod;
        }

        public static HitChance GetHitChance(string skill)
        {
            int hitchanceValue;

            if (skill == "W")
                hitchanceValue = KMenu.hitchanceW;
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
            foreach(var Buff in User.Buffs)
            {
                if(Buff.Name == "asheqcastready")
                    if(Q.IsReady())
                        Q.Cast();
            }           
        }
        public static void CastW(Obj_AI_Base target)
        {
            if (target == null || target.IsInvulnerable && !target.IsValidTarget()) return;
            W.MinimumHitChance = GetHitChance("W");
            if (W.IsReady())
                W.Cast(target);
        }
        public static void CastE(Obj_AI_Base target)
        {
            if (target == null) return;
            if (E.IsReady())
                E.Cast(target);
        }
        public static void CastR(Obj_AI_Base target)
        {
            if (target == null) return;
            W.MinimumHitChance = GetHitChance("R");
            if (R.IsReady())
                R.Cast(target);
        }
        public static void CastYoumuu()
        {
            if (User.IsDead || !User.CanCast || User.IsInvulnerable || !User.IsTargetable || User.IsZombie || User.IsInShopRange()) return;

            InventorySlot youmuuSlot = GetItemSlot(ItemId.Youmuus_Ghostblade);
            if (youmuuSlot!= null && youmuuSlot.CanUseItem())
                youmuuSlot.Cast();
        }
        public static void CastBOTRK()
        {
            if (User.IsDead || !User.CanCast || User.IsInvulnerable || !User.IsTargetable || User.IsZombie || User.IsInShopRange()) return;
            var targetEnemy = TargetSelector.GetTarget(550, DamageType.Magical);
            if (targetEnemy == null) return;

            InventorySlot BOTRKSlot = GetItemSlot(ItemId.Blade_of_the_Ruined_King);
            if (BOTRKSlot != null && BOTRKSlot.CanUseItem())
            {
                BOTRKSlot.Cast(targetEnemy);
            }
            else
                CastBilgewater();
        }
        public static void CastBilgewater()
        {
            if (User.IsDead || !User.CanCast || User.IsInvulnerable || !User.IsTargetable || User.IsZombie || User.IsInShopRange()) return;
            var targetEnemy = TargetSelector.GetTarget(550, DamageType.Magical);
            if (targetEnemy == null) return;

            InventorySlot BilgewaterSlot = GetItemSlot(ItemId.Bilgewater_Cutlass);
            if (BilgewaterSlot != null && BilgewaterSlot.CanUseItem())
            {
                BilgewaterSlot.Cast(targetEnemy);
            }
        }

        public static InventorySlot GetItemSlot(ItemId itemId)
        {
            InventorySlot[] inventory = User.InventoryItems;
            foreach (var itemSlot in inventory)
            {
                if ((itemSlot.Id == itemId) && itemSlot.CanUseItem())
                {
                    return itemSlot;                  
                }
            }
                return null;
        }
    }
}

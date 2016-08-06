using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using System.Linq;
using EloBuddy.SDK.Enumerations;
namespace Godlike_Ashe
{
    class KModes
    {
        public static AIHeroClient User = Program.User;

        public static void Combo()
        {
            if (KMenu.KAcomboQ && KSpells.Q.IsReady())
            {
                if (User.CountEnemiesInRange(800) >= KMenu.KAcomboQlimit)
                    KSpells.CastQ();
            }
            if (KMenu.KAcomboW && KSpells.W.IsReady())
            {
                Obj_AI_Base targetEnemy = TargetSelector.GetTarget(KSpells.W.Range, DamageType.Physical);
                if (targetEnemy != null)
                    KSpells.CastW(targetEnemy);
            }
            if (KMenu.KAcomboR && KSpells.R.IsReady())
            {
                var targetEnemy = TargetSelector.GetTarget(2000, DamageType.Physical);
                if (targetEnemy != null)
                {
                    if (!KMenu.KAcomboSR)
                    {
                        KSpells.R.Cast(targetEnemy);
                    }
                    else
                    {
                        if (!KSpells.W.IsReady() && User.CountEnemiesInRange(600) == 0 || User.HealthPercent < 25)
                        {
                            KSpells.R.Cast(targetEnemy);
                        }
                    }
                }
            }
            if (KMenu.KAcomboYOUMUU)
            {
                if (User.CountEnemiesInRange(1000) >= KMenu.KAcomboYOUMUUlimit)
                    KSpells.CastYoumuu();
            }
            if (KMenu.KAcomboBOTRK)
            {
                KSpells.CastBOTRK();
            }
        }


        public static void AutoW()
        {
            if (KMenu.KAautoWM >= User.ManaPercent || !KSpells.W.IsReady() || User.IsRecalling() || (KMenu.KAautoWlimit && User.IsUnderEnemyturret())) return;

            Obj_AI_Base targetEnemy = TargetSelector.GetTarget(KSpells.W.Range, DamageType.Physical);
            if (targetEnemy != null)
                KSpells.CastW(targetEnemy);
        }

        public static void Harass()
        {
            if (KMenu.KAharassM >= User.ManaPercent) return;

            if (KMenu.KAharassQ && KSpells.Q.IsReady())
            {
                if (User.CountEnemiesInRange(800) >= KMenu.KAharassQlimit)
                    KSpells.CastQ();
            }
            if (KMenu.KAharassW && KSpells.W.IsReady())
            {
                Obj_AI_Base targetEnemy = TargetSelector.GetTarget(KSpells.W.Range, DamageType.Physical);
                if (targetEnemy != null)
                    KSpells.CastW(targetEnemy);
            }
        }

        public static void Lane()
        {
            if (KMenu.KAlaneM >= User.ManaPercent) return;

            if (KMenu.KAlaneQ && KSpells.Q.IsReady())
            {
                if (User.CountEnemyMinionsInRange(800) >= KMenu.KAlaneQlimit)
                    KSpells.CastQ();

            }
            if (KMenu.KAlaneW && KSpells.W.IsReady())
            {
                if (User.CountEnemyMinionsInRange(KSpells.W.Range) >= KMenu.KAlaneWlimit)
                {
                    Obj_AI_Base targetMinion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(X => X.IsInRange(Player.Instance.Position, KSpells.W.Range) && X.IsValid && !X.IsDead && !X.IsInvulnerable).OrderBy(X => X.CountEnemyMinionsInRange(KSpells.W.Range)).LastOrDefault();
                    KSpells.CastW(targetMinion);
                }
            }
        }

        public static void Jungle()
        {
            if (KMenu.KAjungleM >= User.ManaPercent) return;

            Obj_AI_Base targetMonster = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, KSpells.W.Range).Where(X => X.IsValid && !X.IsDead && !X.IsInvulnerable).OrderBy(X => X.MaxHealth).LastOrDefault();
            if (targetMonster == null) return;

            if (KMenu.KAjungleQ && KSpells.Q.IsReady())
            {
                KSpells.CastQ();
            }
            if (KMenu.KAjungleW && KSpells.W.IsReady())
            {
                KSpells.CastW(targetMonster);
            }
        }

        public static void Steal()
        {
            if (KMenu.KAstealW && KSpells.W.IsReady())
            {
                foreach (var X in EntityManager.Heroes.Enemies.Where(X => X.IsInRange(Player.Instance, KSpells.W.Range) && !X.IsInvulnerable && X.IsTargetable && !X.IsZombie && X.Health < DamageLibrary.GetSpellDamage(Player.Instance, X, SpellSlot.W)))
                {
                    if (KSpells.W.GetPrediction(X).HitChance >= HitChance.Medium)
                    {
                        KSpells.W.Cast(KSpells.W.GetPrediction(X).CastPosition);
                    }
                }
            }
            if (KMenu.KAstealR && KSpells.W.IsReady())
            {
                foreach (var X in EntityManager.Heroes.Enemies.Where(X => X.IsInRange(Player.Instance, KMenu.KAstealRlimit) && !X.IsInvulnerable && X.IsTargetable && !X.IsZombie && X.Health < DamageLibrary.GetSpellDamage(Player.Instance, X, SpellSlot.R)))
                {
                    if (KSpells.R.GetPrediction(X).HitChance >= HitChance.High)
                    {
                        KSpells.R.Cast(KSpells.R.GetPrediction(X).CastPosition);
                    }
                }
            }
        }
    }
}

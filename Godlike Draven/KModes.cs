using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using System.Linq;
using EloBuddy.SDK.Enumerations;
using System;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using SharpDX;

namespace Godlike_Draven
{
    class KModes
    {
        public static AIHeroClient User = Program.User;

        public static void Combo()
        {
            if (KMenu.KDcomboQ && KSpells.QCount < KMenu.axeMaximum-1  && User.CountEnemiesInRange(User.GetAutoAttackRange()) > 0 && !User.Spellbook.IsAutoAttacking)
            {
                KSpells.CastQ();
            }
            if (KMenu.KDcomboW && User.CountEnemiesInRange(User.GetAutoAttackRange()) > 0)
            {
                KSpells.CastW();
            }
            if (KMenu.KDcomboE)
            {
                var targetEnemy = TargetSelector.GetTarget(KSpells.E.Range, DamageType.Physical);
                KSpells.CastE(targetEnemy);
            }
            if(KMenu.KDcomboR)
            {
                var targetEnemy =
                EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(2000)).FirstOrDefault(x => User.GetSpellDamage(x, SpellSlot.R) * 2 > x.Health && (x.Distance(User.Position) > User.GetAutoAttackRange() || User.CountEnemiesInRange(KSpells.E.Range) > 2));
                if (targetEnemy != null)
                {
                    KSpells.CastR(targetEnemy);
                }
            }
        }
        public static void Harass()
        {
            if (KMenu.KDharassM >= User.ManaPercent) return;

            if (KMenu.KDharassQ && KSpells.QCount < KMenu.axeMaximum - 1 && User.CountEnemiesInRange(User.GetAutoAttackRange()) > 0 && !User.Spellbook.IsAutoAttacking)
            {
                KSpells.CastQ();
            }
            if (KMenu.KDharassW && User.CountEnemiesInRange(User.GetAutoAttackRange()) > 0)
            {
                KSpells.CastW();
            }
            if (KMenu.KDharassE)
            {
                var targetEnemy = TargetSelector.GetTarget(KSpells.E.Range, DamageType.Physical);
                KSpells.CastE(targetEnemy);
            }
        }
        public static void Lane()
        {
            if (KMenu.KDlaneM >= User.ManaPercent) return;

            if (KMenu.KDlaneQ && KSpells.QCount < KMenu.axeMaximum - 1 && User.CountEnemyMinionsInRange(User.GetAutoAttackRange()) > 0 && !User.Spellbook.IsAutoAttacking)
            {
                KSpells.CastQ();
            }
            if (KMenu.KDlaneW)
            {
                KSpells.CastW();
            }
        }
        public static void Jungle()
        {
            if (KMenu.KDjungleM >= User.ManaPercent) return;

            Obj_AI_Base targetMonster = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position,User.GetAutoAttackRange()).Where(X => X.IsValid && !X.IsDead && !X.IsInvulnerable).OrderBy(X => X.MaxHealth).LastOrDefault();
            if (targetMonster == null) return;

            if (KMenu.KDjungleQ && KSpells.QCount < KMenu.axeMaximum - 1 && !User.Spellbook.IsAutoAttacking)
            {
                KSpells.CastQ();
            }
            if (KMenu.KDlaneW)
            {
                KSpells.CastW();
            }
        }
        public static void Flee()
        {
            if (KMenu.KDfleeW)
            {
                KSpells.CastW();
            }
            if (KMenu.KDfleeE)
            {
                var targetEnemy = TargetSelector.GetTarget(KSpells.E.Range, DamageType.Physical);
                KSpells.CastE(targetEnemy);
            }
        }
        public static void Steal()
        {
            if (KMenu.KDstealE)
            {
                var targetEnemy =
                EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(KSpells.E.Range)).FirstOrDefault(x => User.GetSpellDamage(x, SpellSlot.E) * 2 > x.Health && (x.Distance(User.Position) > User.GetAutoAttackRange() || User.CountEnemiesInRange(KSpells.E.Range) > 2));
                if (targetEnemy != null)
                {
                    KSpells.CastR(targetEnemy);
                }
            }
            if (KMenu.KDstealR)
            {
                var targetEnemy =
                EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(KMenu.KDstealRlimit)).FirstOrDefault(x => User.GetSpellDamage(x, SpellSlot.R) * 2 > x.Health && (x.Distance(User.Position) > User.GetAutoAttackRange() || User.CountEnemiesInRange(KSpells.E.Range) > 2));
                if (targetEnemy != null)
                {
                    KSpells.CastR(targetEnemy);
                }
            }
        }

        public static List<QRecticle> QReticles { get; set; }
        public static int LastAxeMoveTime { get; set; }
        public static Vector3 bestreticlepos = Vector3.Zero;

        public static Orbwalker.OrbwalkPositionDelegate GetReticlePosDelegate()
        {
            return () => bestreticlepos;
        }

        public static Orbwalker.OrbwalkPositionDelegate GetMousePos()
        {
            return () => Game.CursorPos;
        }

        public static void Axes()
        {
            if (KMenu.axeMode == 0 || (KMenu.axeMode == 1 && Orbwalker.ActiveModesFlags.ToString().Contains(Orbwalker.ActiveModes.Combo.ToString())))
            {
                var bestReticle =
                    QReticles.Where(
                        x =>
                        x.Object.Position.Distance(Game.CursorPos) < KMenu.axeRange)
                        .OrderBy(x => x.Position.Distance(User.ServerPosition))
                        .ThenBy(x => x.Position.Distance(Game.CursorPos))
                        .ThenBy(x => x.ExpireTime)
                        .FirstOrDefault();

                if (bestReticle != null && bestReticle.Object.Position.Distance(ObjectManager.Player.ServerPosition) > 100)
                {
                    bestreticlepos = bestReticle.Position;
                    var eta = 1000 * (ObjectManager.Player.Distance(bestReticle.Position) / ObjectManager.Player.MoveSpeed);
                    var expireTime = bestReticle.ExpireTime - Environment.TickCount;

                    if (eta >= expireTime && KMenu.axeLimit1)
                    {
                        Player.CastSpell(SpellSlot.W);
                    }

                    if (KMenu.axeLimit2)
                    {
                        if (ObjectManager.Player.IsUnderEnemyturret() && bestReticle.Object.Position.IsUnderTurret())
                        {
                            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.None)
                            {
                                Player.IssueOrder(GameObjectOrder.MoveTo, bestReticle.Position);
                            }
                            else
                            {
                                Orbwalker.OverrideOrbwalkPosition = GetReticlePosDelegate();
                            }
                        }
                        else if (!bestReticle.Position.IsUnderTurret())
                        {
                            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.None)
                            {
                                Player.IssueOrder(GameObjectOrder.MoveTo, bestReticle.Position);
                            }
                            else
                            {
                                Orbwalker.OverrideOrbwalkPosition = GetReticlePosDelegate();
                            }
                        }
                    }
                    else
                    {
                        if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.None)
                        {
                            Player.IssueOrder(GameObjectOrder.MoveTo, bestReticle.Position);
                        }
                        else
                        {
                            Orbwalker.OverrideOrbwalkPosition = GetReticlePosDelegate();
                        }
                    }
                }
                else
                {
                    Orbwalker.OverrideOrbwalkPosition = GetMousePos();
                }
            }
            else
            {
                Orbwalker.OverrideOrbwalkPosition = GetMousePos();
            }
        }

        internal class QRecticle
        {

            public QRecticle(GameObject rectice, int expireTime)
            {
                Object = rectice;
                ExpireTime = expireTime;
            }

            public int ExpireTime { get; set; }
            public GameObject Object { get; set; }
            public Vector3 Position { get { return Object.Position; } }
        }
    }
}

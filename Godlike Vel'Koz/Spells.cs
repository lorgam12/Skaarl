using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Godlike_Vel_Koz
{
    class Spells
    {
        public static Spell.Skillshot Q { get; set; }
        public static Spell.Skillshot W { get; set; }
        public static Spell.Skillshot E { get; set; }
        public static Spell.Skillshot R { get; set; }
        public static Spell.Skillshot TEST { get; set; }

        public static MissileClient Qmiss = null;

        public const int MissileSpeed = 2100;
        public const int CastDelay = 250;
        public const int SpellWidth = 45;
        public const int SpellRange = 1100;

        public static MissileClient Handle { get; set; }
        public static Vector2 Direction { get; set; }
        public static List<Vector2> Perpendiculars { get; set; }

        // Clone Character Object
        public static AIHeroClient Champion = Program.Champion;

        // Tear Timestamp
        public static float StackerStamp = 0;

        public static void Initialize()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1050, SkillShotType.Linear, 250, 1300, 50)
            {
                MinimumHitChance = GetHitChance("Q"),
                AllowedCollisionCount = 0
            };
            W = new Spell.Skillshot(SpellSlot.W, 1050, SkillShotType.Linear, 250, 1700, 80)
            {
                MinimumHitChance = GetHitChance("W"),
                AllowedCollisionCount = int.MaxValue
            };
            E = new Spell.Skillshot(SpellSlot.E, 850, SkillShotType.Circular, 500, 1500, 120)
            {
                MinimumHitChance = GetHitChance("E"),
                AllowedCollisionCount = int.MaxValue
            };
            R = new Spell.Skillshot(SpellSlot.R, 1550, SkillShotType.Linear, 250, 0, 60)
            {
                
                MinimumHitChance = GetHitChance("R"),
                AllowedCollisionCount = int.MaxValue
            };
        }

        public static HitChance GetHitChance(string skill)
        {
            int hitchanceValue;

            if (skill == "Q")
                hitchanceValue = Manager.hitchanceQ;
            else if (skill == "W")
                hitchanceValue = Manager.hitchanceW;
            else if (skill == "E")
                hitchanceValue = Manager.hitchanceE;
            else if (skill == "R")
                hitchanceValue = Manager.hitchanceR;
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
        // Champion Specified Abilities
        public static float QDamage()
        {
            return new float[] { 0, 80, 120, 150, 200, 240 }[Q.Level] + 0.6f * Champion.FlatMagicDamageMod;
        }

        public static float WDamage()
        {
            return new float[] { 0, 75, 125, 175, 225, 275 }[W.Level] + 0.625f * Champion.FlatMagicDamageMod;
        }

        public static float EDamage()
        {
            return new float[] { 0, 70, 100, 130, 160, 190 }[E.Level] + 0.5f * Champion.FlatMagicDamageMod;
        }

        public static float RDamage()
        {
            return new float[] { 0, 500, 700, 900 }[R.Level] + 0.5f * Champion.FlatMagicDamageMod;
        }

        // Cast Methods
        public static void CastQ(Obj_AI_Base target)
        {
            if (target == null) return;
            Q.MinimumHitChance = GetHitChance("Q");
            if (Q.IsReady())
                Q.Cast(target);
        }
        public static void CastSharpQ(SharpDX.Vector3 target)
        {
            if (target == null) return;
            Q.MinimumHitChance = GetHitChance("Q");
            if (Q.IsReady())
                Q.Cast(target);
        }
        public static void CastW(Obj_AI_Base target)
        {
            if (target == null) return;
            W.MinimumHitChance = GetHitChance("W");
            if (W.IsReady())
                W.Cast(target);
        }
        public static void CastSharpW(SharpDX.Vector3 target)
        {
            if (target == null) return;
            W.MinimumHitChance = GetHitChance("W");
            if (W.IsReady())
                W.Cast(target);
        }
        public static void CastE(Obj_AI_Base target)
        {
            if (target == null) return;
            E.MinimumHitChance = GetHitChance("E");
            if (E.IsReady())
                E.Cast(target);
        }
        public static void CastSharpE(SharpDX.Vector3 target)
        {
            if (target == null) return;
            E.MinimumHitChance = GetHitChance("E");
            if (E.IsReady())
                E.Cast(target);
        }
        public static bool castingR = false;
        public static void CastR(Obj_AI_Base target)
        {
            if (target == null) return;
            R.MinimumHitChance = GetHitChance("R");
            if (R.IsReady() && !castingR)
                R.Cast(target); castingR = true; Core.DelayAction(() => castingR = false, 2500);
        }
        public static void CastSharpR(SharpDX.Vector3 target)
        {
            if (target == null) return;
            R.MinimumHitChance = GetHitChance("R");
            if (R.IsReady() && !castingR)
                R.Cast(target); castingR = true; Core.DelayAction(() => castingR = false, 2500);
        }
        public static void OnCreate(GameObject sender, EventArgs args)
        {
            // Check if the sender is a MissleClient
            var missile = sender as MissileClient;
            if (missile != null && missile.SpellCaster.IsMe && missile.SData.Name == "VelkozQMissile")
            {
                // Apply the needed values
                Handle = missile;
                Direction = (missile.EndPosition.To2D() - missile.StartPosition.To2D()).Normalized();
                Perpendiculars.Add(Direction.Perpendicular());
                Perpendiculars.Add(Direction.Perpendicular2());
            }
        }

        public static void QSplit(EventArgs args)
        {
            // Check if the missile is active
            if (Handle != null && Q.IsReady() && Q.Name == "velkozqsplitactivate")
            {
                foreach (var perpendicular in Perpendiculars)
                {
                    if (Handle != null)
                    {
                        var startPos = Handle.Position.To2D();
                        var endPos = Handle.Position.To2D() + SpellRange * perpendicular;

                        var collisionObjects = ObjectManager.Get<Obj_AI_Base>()
                            .Where(o => o.IsEnemy && !o.IsDead && !o.IsStructure() && !o.IsWard() && !o.IsInvulnerable
                                    && o.Distance(Champion, true) < (SpellRange + 200).Pow()
                                    && o.ServerPosition.To2D().Distance(startPos, endPos, true, true) <= (SpellWidth * 2 + o.BoundingRadius).Pow());

                        var colliding = collisionObjects
                            .Where(o => o.Type == GameObjectType.AIHeroClient && o.IsValidTarget()
                                    && Prediction.Position.Collision.LinearMissileCollision(o, startPos, endPos, MissileSpeed, SpellWidth, CastDelay, (int)o.BoundingRadius))
                                .OrderBy(o => o.Distance(Champion, true)).FirstOrDefault();

                        if (colliding != null)
                        {
                            Player.CastSpell(SpellSlot.Q);
                            Handle = null;
                        }
                    }
                }
            }
            else
                Handle = null;
        }
    }
}

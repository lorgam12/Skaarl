using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using System.Linq;

namespace Godlike_Ashe
{
    class Angel
    {
        public static void Interrupt(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (!KMenu.KAInterrupt) return;

            if (sender != null)
            {
                Obj_AI_Base targetEnemy = TargetSelector.GetTarget(KSpells.R.Range, DamageType.Magical);
                if (targetEnemy != null)
                    KSpells.CastR(targetEnemy);
            }
        }

        public static void Gap(Obj_AI_Base sender, Gapcloser.GapcloserEventArgs args)
        {
            if (!KMenu.KAGap) return;

            if (sender != null)
            {
                Obj_AI_Base targetEnemy = TargetSelector.GetTarget(KSpells.W.Range, DamageType.Physical);
                if (targetEnemy != null)
                    KSpells.CastW(targetEnemy);
            }
        }
    }
}

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using System.Linq;

namespace Godlike_Draven
{
    class Angel
    {
        public static void Interrupt(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (!KMenu.KDInterrupt) return;

            if (sender != null)
            {
                if (args.DangerLevel == EloBuddy.SDK.Enumerations.DangerLevel.Medium || args.DangerLevel == EloBuddy.SDK.Enumerations.DangerLevel.High)
                    KSpells.CastE(sender);
            }
        }
        public static void Gap(Obj_AI_Base sender, Gapcloser.GapcloserEventArgs args)
        {
            if (!KMenu.KDGap) return;

            if (sender != null)
            {
                KSpells.CastE(sender);
            }
        }
    }
}

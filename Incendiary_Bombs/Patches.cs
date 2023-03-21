using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace Incendiary_Bombs
{
    public class Patches
    {
        [HarmonyPatch(typeof(Projectile), nameof(Projectile.OnHit))]
        public static class OnHitPatch
        {
            public static void Prefix(Projectile __instance)
            {
                if (__instance.gameObject.name.StartsWith("sticky_projectile"))
                {
                    __instance.m_aoe = 1;
                }
            }
            public static void Postfix(Projectile __instance)
            {
                if (__instance.gameObject.name.StartsWith("sticky_projectile"))
                {
                    __instance.m_rotateVisual = 0;
                    var transformLocalScale = __instance.m_visual.transform.localScale * (float)1.5;
                    __instance.m_visual.transform.localScale = transformLocalScale;
                }   
            }
        }
    }
}
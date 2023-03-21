using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace Incendiary_Bombs
{
    public class Patches
    {
        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
        public static class ObjectDB_StatthingerPatch
        {
            [HarmonyPostfix]
            [UsedImplicitly]
            public static void Postfix(ObjectDB __instance)
            {
                var go1 = __instance.GetItemPrefab("BombIncendiary");
                var damtype = __instance.m_items.Find(x=>x.gameObject == go1).GetComponent<ItemDrop>().m_itemData.m_shared.m_damages;
                damtype.m_damage =0;
                damtype.m_blunt =0;
                damtype.m_slash =0;
                damtype.m_pierce =0;
                damtype.m_chop =0;
                damtype.m_pickaxe =0;
                damtype.m_fire =0;
                damtype.m_frost =0;
                damtype.m_lightning =0;
                damtype.m_poison =0;
                damtype.m_spirit =0;
                __instance.m_items.Find(x => x.gameObject == go1).GetComponent<ItemDrop>().m_itemData.m_shared
                    .m_damages = damtype;
                var go2 = __instance.GetItemPrefab("BombIncendiary_Sticky");
                var damtype1 = __instance.m_items.Find(x=>x.gameObject == go2).GetComponent<ItemDrop>().m_itemData.m_shared.m_damages;
                damtype1.m_damage =0;
                damtype1.m_blunt =0;
                damtype1.m_slash =0;
                damtype1.m_pierce =0;
                damtype1.m_chop =0;
                damtype1.m_pickaxe =0;
                damtype1.m_fire =0;
                damtype1.m_frost =0;
                damtype1.m_lightning =0;
                damtype1.m_poison =0;
                damtype1.m_spirit =0;
                __instance.m_items.Find(x => x.gameObject == go2).GetComponent<ItemDrop>().m_itemData.m_shared
                    .m_damages = damtype1;

            }
        }
    }
}
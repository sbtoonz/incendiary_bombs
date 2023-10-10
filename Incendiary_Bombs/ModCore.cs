using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using ItemManager;
using ServerSync;

namespace Incendiary_Bombs
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class IncendiaryBombs : BaseUnityPlugin
    {
        private const string ModName = "IncendiaryBombs";
        internal const string ModVersion = "1.0.2";
        private const string ModGUID = "com.littleroomdev.IncendiaryBombs";
        private static Harmony harmony = null!;
        private ConfigEntry<int> TimeToWait;
        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony = new(ModGUID);
            harmony.PatchAll(assembly);
            
            Item boomb = new("boombs", "BombIncendiary", "assets");
            boomb.Name.English("Incendiary Bomb");
            boomb.Description.English("A curious explosive device...");
            boomb.Crafting.Add(CraftingTable.Workbench, 3);
            boomb.RequiredItems.Add("ElderBark", 3);
            boomb.RequiredItems.Add("Iron", 1);
            boomb.RequiredItems.Add("SurtlingCore", 5);
            boomb.CraftAmount = 10;

            Item stick_boomb = new("boombs", "BombIncendiary_Sticky");
            stick_boomb.Name.English("Sticky Bomb");
            stick_boomb.Description.English("A sticky explosive device...");
            stick_boomb.Crafting.Add(CraftingTable.Workbench,3);
            stick_boomb.RequiredItems.Add("ElderBark", 3);
            stick_boomb.RequiredItems.Add("Iron", 1);
            stick_boomb.RequiredItems.Add("SurtlingCore", 5);
            stick_boomb.RequiredItems.Add("Resin", 2);
            stick_boomb.CraftAmount = 10;
            
            PrefabManager.RegisterPrefab("boombs", "incendiary_explosion");
            PrefabManager.RegisterPrefab("boombs", "incendiary_projectile");
            
            PrefabManager.RegisterPrefab("boombs", "sticky_projectile");
            PrefabManager.RegisterPrefab("boombs", "Lit_bomb");
            PrefabManager.RegisterPrefab("boombs", "_terraform");

        }
    }
}

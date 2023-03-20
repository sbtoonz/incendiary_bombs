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
        internal const string ModVersion = "0.0.1";
        private const string ModGUID = "com.littleroomdev.IncendiaryBombs";
        private static Harmony harmony = null!;
        /*ConfigSync configSync = new(ModGUID) 
            { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion};
        internal static ConfigEntry<bool> ServerConfigLocked = null!;
        ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description, bool synchronizedSetting = true)
        {
            ConfigEntry<T> configEntry = Config.Bind(group, name, value, description);

            SyncedConfigEntry<T> syncedConfigEntry = configSync.AddConfigEntry(configEntry);
            syncedConfigEntry.SynchronizedConfig = synchronizedSetting;

            return configEntry;
        }*/
        //ConfigEntry<T> config<T>(string group, string name, T value, string description, bool synchronizedSetting = true) => config(group, name, value, new ConfigDescription(description), synchronizedSetting);
        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony = new(ModGUID);
            harmony.PatchAll(assembly);
            /*ServerConfigLocked = config("1 - General", "Lock Configuration", true, "If on, the configuration is locked and can be changed by server admins only.");
            configSync.AddLockingConfigEntry(ServerConfigLocked);*/

            Item boomb = new("boombs", "BombIncendiary", "assets");
            boomb.Name.English("Incendiary Bomb");
            boomb.Description.English("A curious explosive device...");
            boomb.Crafting.Add(CraftingTable.Workbench, 0);
            boomb.RequiredItems.Add("Wood", 1);
            boomb.CraftAmount = 10;

            Item stick_boomb = new("boombs", "BombIncendiary_Sticky");
            stick_boomb.Name.English("Sticky Bomb");
            stick_boomb.Description.English("A sticky explosive device...");
            stick_boomb.Crafting.Add(CraftingTable.Workbench,0);
            stick_boomb.RequiredItems.Add("Wood", 1);
            stick_boomb.CraftAmount = 10;
            
            PrefabManager.RegisterPrefab("boombs", "incendiary_explosion");
            PrefabManager.RegisterPrefab("boombs", "incendiary_projectile");
            
            PrefabManager.RegisterPrefab("boombs", "sticky_projectile");
            PrefabManager.RegisterPrefab("boombs", "Lit_bomb");
        }
    }
}

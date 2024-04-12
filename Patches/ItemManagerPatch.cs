using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

[HarmonyPatch(typeof(ItemManager), nameof(ItemManager.Init))]
internal static class ItemManagerPatch
{
    internal static void Postfix(ItemManager __instance)
    {
        var items = DataHelper.items;

        //--------------------------------------------------------------------+
        // Welcome screens
        //--------------------------------------------------------------------+
        var unlockedWelcomeList = items.FindAll((Func<IData, bool>)ModManager.IsWelcome);

        ModManager.WelcomeExchangeIndexes.RemoveWhere(
            idx => unlockedWelcomeList.Exists(
                (Func<IData, bool>)(data => ModManager.CheckDataIndex(data, idx))
            )
        );

        foreach (var lockedExchangeWelcomeIndex in ModManager.WelcomeExchangeIndexes)
            __instance.AddItem("welcome", lockedExchangeWelcomeIndex, 5);
    }
}
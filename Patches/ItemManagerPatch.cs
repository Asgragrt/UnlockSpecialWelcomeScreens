using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

using static ModManager;

[HarmonyPatch(typeof(ItemManager), nameof(ItemManager.Init))]
internal static class ItemManagerPatch
{
    internal static void Postfix(ItemManager __instance)
    {
        var items = DataHelper.items;

        //--------------------------------------------------------------------+
        // Welcome screens
        //--------------------------------------------------------------------+
        var unlockedWelcomeList = items.FindAll((Func<IData, bool>)IsWelcome);

        WelcomeExchangeIndexes.RemoveWhere(
            idx => unlockedWelcomeList.Exists(
                (Func<IData, bool>)(data => CheckDataIndex(data, idx))
            )
        );

        foreach (var lockedExchangeWelcomeIndex in WelcomeExchangeIndexes)
            __instance.AddItem("welcome", lockedExchangeWelcomeIndex, 5);

        //--------------------------------------------------------------------+
        // Welcome screens
        //--------------------------------------------------------------------+
        var unlockedLoadingList = items.FindAll((Func<IData, bool>)IsLoading);

        LoadingExchangeIndexes.RemoveWhere(
            idx => unlockedLoadingList.Exists(
                (Func<IData, bool>)(data => CheckDataIndex(data, idx))
            )
        );

        foreach (var lockedExchangeLoadingIndex in LoadingExchangeIndexes)
            __instance.AddItem("loading", lockedExchangeLoadingIndex, 5);
    }
}
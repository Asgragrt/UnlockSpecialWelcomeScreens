using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

using static ModManager;

[HarmonyPatch]
internal static class DBPatch
{
    //--------------------------------------------------------------------+
    // Welcome screens
    //--------------------------------------------------------------------+
    [HarmonyPatch(typeof(DBConfigWelcome), nameof(DBConfigWelcome.GetWelcomeInfoByIndex))]
    [HarmonyPostfix]
    internal static void WelcomePostfix(int index, WelcomeInfo __result)
    {
        if (!__result.exchange) return;

        WelcomeUnlocker.AddToSet(index);
    }

    //--------------------------------------------------------------------+
    // Loading screens
    //--------------------------------------------------------------------+
    [HarmonyPatch(typeof(DBConfigLoading), nameof(DBConfigLoading.GetLoadingInfoByIndex))]
    [HarmonyPostfix]
    internal static void LoadingPostfix(int index, LoadingInfo __result)
    {
        if (!__result.exchange) return;

        LoadingUnlocker.AddToSet(index);
    }
}
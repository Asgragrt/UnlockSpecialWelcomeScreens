using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

//--------------------------------------------------------------------+
// Welcome screens
//--------------------------------------------------------------------+
[HarmonyPatch(typeof(DBConfigWelcome), nameof(DBConfigWelcome.GetWelcomeInfoByIndex))]
internal static class DBPatch
{
    internal static void Postfix(int index, WelcomeInfo __result)
    {
        if (!ModManager.WelcomeIndexes.Contains(index)) return;
        __result.exchange = false;
    }
}

//--------------------------------------------------------------------+
// Loading screens
//--------------------------------------------------------------------+
[HarmonyPatch(typeof(DBConfigLoading), nameof(DBConfigLoading.GetLoadingInfoByIndex))]
internal static class DBPatch2
{
    internal static void Postfix(LoadingInfo __result)
    {
        __result.exchange = false;
    }
}
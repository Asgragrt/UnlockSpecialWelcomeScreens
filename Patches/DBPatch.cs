using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

using static ModManager;

//--------------------------------------------------------------------+
// Welcome screens
//--------------------------------------------------------------------+
[HarmonyPatch(typeof(DBConfigWelcome), nameof(DBConfigWelcome.GetWelcomeInfoByIndex))]
internal static class DBPatch
{
    internal static void Postfix(int index, WelcomeInfo __result)
    {
        if (!__result.exchange) return;
        
        WelcomeExchangeIndexes.Add(index);
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
using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

[HarmonyPatch(typeof(DBConfigWelcome), nameof(DBConfigWelcome.GetWelcomeInfoByIndex))]
internal static class DBPatch
{
    internal static void Postfix(int index, WelcomeInfo __result)
    {
        if (!ModManager.WelcomeIndexes.Contains(index)) return;
        __result.exchange = false;
    }
}
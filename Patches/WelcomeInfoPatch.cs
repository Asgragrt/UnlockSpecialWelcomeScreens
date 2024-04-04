using HarmonyLib;
using Il2CppAssets.Scripts.Database;

namespace UnlockSpecialWelcomeScreens.Patches;

[HarmonyPatch(typeof(DBConfigWelcome), nameof(DBConfigWelcome.GetWelcomeInfoByIndex))]
internal static class WelcomeInfoPatch
{
    internal static void Postfix(WelcomeInfo __result)
    {
        __result.exchange = false;
    }
}
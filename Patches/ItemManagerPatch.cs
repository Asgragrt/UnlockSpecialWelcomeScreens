using HarmonyLib;
using Il2CppAssets.Scripts.GameCore.Managers;
using UnlockSpecialWelcomeScreens.Managers;

namespace UnlockSpecialWelcomeScreens.Patches;

using static ModManager;

[HarmonyPatch(typeof(ItemManager), nameof(ItemManager.Init))]
internal static class ItemManagerPatch
{
    internal static void Postfix(ItemManager __instance)
    {
        UnlockExchangeWelcome(__instance);
        UnlockExchangeLoading(__instance);
    }
}
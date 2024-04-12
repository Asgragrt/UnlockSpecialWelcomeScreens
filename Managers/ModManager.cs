using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using UnlockSpecialWelcomeScreens.Models;

namespace UnlockSpecialWelcomeScreens.Managers;

internal static class ModManager
{
    internal static readonly LoadingExchangeUnlocker LoadingUnlocker = new();

    internal static readonly WelcomeExchangeUnlocker WelcomeUnlocker = new();
    
}
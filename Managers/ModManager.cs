using UnlockSpecialWelcomeScreens.Models;

namespace UnlockSpecialWelcomeScreens.Managers;

internal static class ModManager
{
    internal static readonly LoadingExchangeUnlocker LoadingUnlocker = new();

    internal static readonly WelcomeExchangeUnlocker WelcomeUnlocker = new();
}
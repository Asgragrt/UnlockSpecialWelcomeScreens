using Il2CppAssets.Scripts.PeroTools.Nice.Interface;

namespace UnlockSpecialWelcomeScreens.Managers;

internal static class ModManager
{
    internal static readonly HashSet<int> WelcomeExchangeIndexes = [];

    internal static bool IsWelcome(IData data) => string.Equals(data["type"].GetResult<string>(), "welcome");

    internal static bool CheckDataIndex(IData data, int index) => data["index"].GetResult<int>() == index;
}
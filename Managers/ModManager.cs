using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;

namespace UnlockSpecialWelcomeScreens.Managers;

internal static class ModManager
{
    internal static readonly HashSet<int> WelcomeExchangeIndexes = [];

    internal static readonly HashSet<int> LoadingExchangeIndexes = [];

    private static bool IsWelcome(IData data) => string.Equals(data["type"].GetResult<string>(), "welcome");

    private static bool IsLoading(IData data) => string.Equals(data["type"].GetResult<string>(), "loading");

    private static bool CheckDataIndex(IData data, int index) => data["index"].GetResult<int>() == index;

    private static void UnlockExchange(ItemManager itemManager, Func<IData, bool> filter, HashSet<int> exchangeIndexes,
        string type)
    {
        var unlockedItems = itemManager.items.FindAll(filter);

        exchangeIndexes.RemoveWhere(
            idx => unlockedItems.Exists(
                (Func<IData, bool>)(data => CheckDataIndex(data, idx))
            )
        );

        foreach (var lockedExchangeIndex in exchangeIndexes)
            itemManager.AddItem(type, lockedExchangeIndex, 5);
    }

    internal static void UnlockExchangeWelcome(ItemManager itemManager)
    {
        UnlockExchange(itemManager, IsWelcome, WelcomeExchangeIndexes, "welcome");
    }

    internal static void UnlockExchangeLoading(ItemManager itemManager)
    {
        UnlockExchange(itemManager, IsLoading, LoadingExchangeIndexes, "loading");
    }
}
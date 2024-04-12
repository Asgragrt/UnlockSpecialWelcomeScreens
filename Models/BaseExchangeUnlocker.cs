using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;

namespace UnlockSpecialWelcomeScreens.Models;

internal abstract class BaseExchangeUnlocker(string unlockType)
{
    private readonly HashSet<int> _exchangeIndexes = [];

    private bool IsType(IData data) => string.Equals(data["type"].GetResult<string>(), unlockType);

    private static bool CheckDataIndex(IData data, int index) => data["index"].GetResult<int>() == index;

    internal void AddToSet(int index)
    {
        _exchangeIndexes.Add(index);
    }

    internal void UnlockExchange(ItemManager itemManager)
    {
        var unlockedItems = itemManager.items.FindAll((Func<IData, bool>)IsType);

        _exchangeIndexes.RemoveWhere(
            idx => unlockedItems.Exists(
                (Func<IData, bool>)(data => CheckDataIndex(data, idx))
            )
        );

        foreach (var lockedExchangeIndex in _exchangeIndexes)
            itemManager.AddItem(unlockType, lockedExchangeIndex, 5);
    }
}
using MelonLoader;
using UnlockSpecialWelcomeScreens.Properties;

namespace UnlockSpecialWelcomeScreens;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}
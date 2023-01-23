using Content.Client.Alerts;
using Content.Client.Gameplay;
using Content.Client.Tattle;
using Content.Client.UserInterface.Systems.TattleSystem.Widgets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.TattleSystem;

public sealed class TattleSystemUIController : UIController, IOnSystemChanged<ClientTattleSystem>
{
    [UISystemDependency] private readonly ClientTattleSystem? _alertsSystem = default;
    private TattleSystemBar? UI => UIManager.GetActiveUIWidgetOrNull<TattleSystemBar>();

    private void Test2(object? sender, EntityUid e)
    {
        Logger.Info("Test alert" + e.ToString());
    }

    public void OnSystemLoaded(ClientTattleSystem system)
    {
        system.Test2 += Test2;
    }

    public void OnSystemUnloaded(ClientTattleSystem system)
    {
        system.Test2 += Test2;
    }
}

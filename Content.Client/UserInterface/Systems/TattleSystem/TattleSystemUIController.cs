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

    private void CreateNewTattle(object? sender, EntityUid e)
    {
        UI?.Test(e);
    }

    public void OnSystemLoaded(ClientTattleSystem system)
    {
        system.CreateNewTattleEvent += CreateNewTattle;
    }

    public void OnSystemUnloaded(ClientTattleSystem system)
    {
        system.CreateNewTattleEvent += CreateNewTattle;
    }
}

using Content.Client.Tattle;
using Content.Client.UserInterface.Systems.TattleSystem.Widgets;
using Content.Shared.Tattle;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.TattleSystem;

public sealed class TattleSystemUIController : UIController, IOnSystemChanged<ClientTattleSystem>
{
    private TattleSystemBar? UI => UIManager.GetActiveUIWidgetOrNull<TattleSystemBar>();

    private void SyncTattles(object? sender, TattleComponent tattleComponent)
    {
        UI?.SyncTattlesUI(tattleComponent);
    }

    public void OnSystemLoaded(ClientTattleSystem system)
    {
        system.SyncTattlesEvent += SyncTattles;
    }

    public void OnSystemUnloaded(ClientTattleSystem system)
    {
        system.SyncTattlesEvent -= SyncTattles;
    }
}

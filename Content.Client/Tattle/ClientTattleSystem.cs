using Content.Client.UserInterface.Systems.TattleSystem.Widgets;
using Content.Shared.Tattle;
using Robust.Shared.GameStates;

namespace Content.Client.Tattle;

public sealed class ClientTattleSystem : SharedTattleSystem
{
    public event EventHandler<TattleComponent>? SyncTattlesEvent;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TattleComponent, ComponentHandleState>(ClientTattleHandleState);
    }

    public void ClientTattleHandleState(EntityUid euid, TattleComponent tattleComponent, ref ComponentHandleState args)
    {
        if (args.Current is not TattleComponentState state)
            return;

        tattleComponent.Tattles = state.Tattles;

        Logger.Info(tattleComponent.Tattles.Count.ToString());

        SyncTattlesEvent?.Invoke(this, tattleComponent);

    }
}

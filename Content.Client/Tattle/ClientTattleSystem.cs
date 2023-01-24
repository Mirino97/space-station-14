using Content.Client.UserInterface.Systems.TattleSystem.Widgets;
using Content.Shared.Tattle;
using Robust.Shared.GameStates;

namespace Content.Client.Tattle;

public sealed class ClientTattleSystem : SharedTattleSystem
{
    public event EventHandler<EntityUid>? CreateNewTattleEvent;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TattleComponent, ComponentHandleState>(ClientTattleHandleState);
    }

    public void ClientTattleHandleState(EntityUid euid, TattleComponent tattleComponent, ref ComponentHandleState args)
    {
        if (args.Current is not TattleComponentState state
            || state.Actor is null)
            return;

        tattleComponent.Tattles.Add(1, state.Actor.Value);
        CreateNewTattleEvent?.Invoke(this, euid);
        //var test1 = IoCManager.Resolve<TattleSystemBar>();
        //test1.Test(state.Actor.Value);

        Logger.Info(tattleComponent.Tattles.Keys.Count.ToString());
    }
}

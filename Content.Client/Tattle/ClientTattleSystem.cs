using Content.Client.UserInterface.Systems.TattleSystem.Widgets;
using Content.Shared.Tattle;
using Robust.Shared.GameStates;

namespace Content.Client.Tattle;

public sealed class ClientTattleSystem : SharedTattleSystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TattleComponent, ComponentHandleState>(ClientTattleHandleState);
    }

    public void ClientTattleHandleState(EntityUid euid, TattleComponent tattleComponent, ref ComponentHandleState args)
    {
        Logger.Info("Handled on client system");

        if (args.Current is not TattleComponentState state) return;

        if (state.Actor is not null)
            tattleComponent.Tattles.Add(1, state.Actor.Value);


        TattleSystemBar.Test();

        Logger.Info(tattleComponent.Tattles.Keys.Count.ToString());
    }
}

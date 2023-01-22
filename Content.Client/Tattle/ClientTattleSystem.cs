using Content.Shared.Tattle;
using Robust.Shared.GameStates;

namespace Content.Client.Tattle;

public sealed class ClientTattleSystem : SharedTattleSystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TattleComponent, ComponentHandleState>(ClientAlertsHandleState);
    }

    public void ClientAlertsHandleState(EntityUid euid, TattleComponent tattleComponent, ref ComponentHandleState args)
    {
        Logger.Info("Handled on client system");
    }
}

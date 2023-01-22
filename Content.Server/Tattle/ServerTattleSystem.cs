using Content.Shared.Tattle;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Server.Tattle;

public sealed class ServerTattleSystem : SharedTattleSystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<TattleComponent, ComponentGetState>(GetCompState);
    }

    public void GetCompState(EntityUid uid, TattleComponent tattleComponent, ref ComponentGetState args)
    {
        Logger.Debug("Message received:");
        args.State = new TattleComponentState
        {
            Actor = uid
        };
    }

    public void ShowAlert(EntityUid euid)
    {
        Logger.Debug("Attempting to send tattle message");

        if (!EntityManager.TryGetComponent(euid, out TattleComponent? tattleComponent))
            return;

        tattleComponent.Tattles.Add(1, euid);

        Dirty(tattleComponent);
    }
}

using Content.Shared.Administration;
using Robust.Shared.Console;
using Robust.Shared.GameStates;
using Robust.Shared.Players;
using Robust.Shared.Serialization;

namespace Content.Shared.Tattle;

public sealed class TattleSystem : EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<TattleComponent, ComponentGetState>(GetCompState);
        SubscribeLocalEvent<TattleComponent, ComponentHandleState>(HandleCompState);
    }

    public void GetCompState(EntityUid uid, TattleComponent tattleComponent, ref ComponentGetState args)
    {
        Logger.Debug("Message received:");
        args.State = new TattleComponentState
        {
            Actor = uid
        };
    }

    public void HandleCompState(EntityUid uid, TattleComponent tattleComponent, ref ComponentHandleState args)
    {
        Logger.Debug("Handled");
        Logger.Debug(uid.ToString());
    }

    public void ShowAlert(EntityUid? euid)
    {
        Logger.Debug("Attempting to send tattle message");
        if (EntityManager.TryGetComponent(euid, out TattleComponent? tattleComponent))
            Dirty(tattleComponent);
    }

    [Serializable, NetSerializable]
    public sealed class TattleComponentState : ComponentState
    {
        public EntityUid? Actor { get; set; }

    }
}

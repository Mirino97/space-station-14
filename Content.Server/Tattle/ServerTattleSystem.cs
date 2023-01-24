using Content.Shared.Tattle;
using Robust.Shared.GameStates;


namespace Content.Server.Tattle;

public sealed class ServerTattleSystem : SharedTattleSystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<TattleComponent, ComponentGetState>(GetCompState);
    }

    public void GetCompState(EntityUid uid, TattleComponent tattleComponent, ref ComponentGetState args)
    {
        args.State = new TattleComponentState
        {
            Tattles = tattleComponent.Tattles
        };
    }

    public void ShowAlert(EntityUid euid)
    {

        if (!EntityManager.TryGetComponent(euid, out TattleComponent? tattleComponent))
            return;

        var tattle = new TattleComponent.Tattle();

        tattle.Uid = euid;

        tattleComponent.Tattles.Add(tattle);

        //tattleComponent.Tattles.Add((euid, null, null, null));

        Dirty(tattleComponent);
    }
}

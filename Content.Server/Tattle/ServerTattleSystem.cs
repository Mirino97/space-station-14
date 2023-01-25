using Content.Shared.Tattle;
using Robust.Shared.GameStates;
using Robust.Shared.Utility;


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

    public void ShowAlert(string coordinates, EntityUid? euid = null, SpriteSpecifier? spriteSpecifier = null, string? description = null)
    {

        if (!EntityManager.TryGetComponent(euid, out TattleComponent? tattleComponent))
            return;

        var tattle = new TattleComponent.Tattle().WithCoordinates(coordinates);

        tattleComponent.Tattles.Add(tattle);

        Dirty(tattleComponent);
    }
}

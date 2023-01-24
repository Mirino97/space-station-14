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

    public void ShowAlert(EntityUid euid, SpriteSpecifier? spriteSpecifier, string? coordinates, string? description)
    {

        if (!EntityManager.TryGetComponent(euid, out TattleComponent? tattleComponent))
            return;

        //TODO: mirino find a way to move this to the component
        /*var test = (spriteSpecifier != null)
            ? spriteSpecifier
            : new SpriteSpecifier.Rsi(new ResourcePath("Objects/Weapons/Bombs/c4.rsi"), "primed");*/

        var tattle = new TattleComponent.Tattle
        {
            Uid = euid,
            SpriteSpecifier = spriteSpecifier,
            Coordinates = coordinates,
            Description = description
        };

        tattleComponent.Tattles.Add(tattle);

        Dirty(tattleComponent);
    }
}

using Content.Shared.Tattle;
using Robust.Shared.GameStates;
using Robust.Shared.Timing;
using Robust.Shared.Utility;


namespace Content.Server.Tattle;

public sealed class ServerTattleSystem : SharedTattleSystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
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

        for (var i = tattleComponent.Tattles.Count - 1; i >= 0; i--)
        {
            if(tattleComponent.Tattles[i].DeletionTime < _timing.CurTime)
                tattleComponent.Tattles.RemoveAt(i);
        }

        var newTattle = new TattleComponent.Tattle(coordinates, _timing.CurTime.Add(new TimeSpan(0,0,0,5)));

        tattleComponent.Tattles.Add(newTattle);

        Dirty(tattleComponent);

    }
}

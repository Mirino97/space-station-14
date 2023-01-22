using Content.Shared.Administration;
using Robust.Shared.Console;
using Robust.Shared.GameStates;
using Robust.Shared.Players;
using Robust.Shared.Serialization;

namespace Content.Shared.Tattle;

public class SharedTattleSystem : EntitySystem
{
    [Serializable, NetSerializable]
    public sealed class TattleComponentState : ComponentState
    {
        public EntityUid? Actor { get; set; }

    }
}

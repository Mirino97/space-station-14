using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Utility;

namespace Content.Shared.Tattle;

[RegisterComponent]
[NetworkedComponent]
public sealed class TattleComponent : Component
{

    [ViewVariables] public readonly List<Tattle> Tattles = new();

    [Serializable, NetSerializable]
    public struct Tattle
    {
        public EntityUid Uid;
        public SpriteSpecifier? SpriteSpecifier;
        public string? Coordinates;
        public string? Description;
    }

}

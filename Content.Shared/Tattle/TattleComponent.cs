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
        public ResourcePath DefaultPath = new ResourcePath("Objects/Weapons/Bombs/c4.rsi");
        public string DefaultRsiState = "primed";
        public EntityUid Uid;
        //TODO: mirino find a cool default. Probably something like a "!"?
        public SpriteSpecifier? SpriteSpecifier;
        //TODO: mirino make Coordinates NOT nullable since the whole point of these buttons is to make people go to specific places
        public string? Coordinates;
        public string? Description;

        public Tattle()
        {

        }

    }

}

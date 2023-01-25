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
        // TODO: mirino find a cool default. Probably something like a "!"?
        public SpriteSpecifier SpriteSpecifier = new SpriteSpecifier.Rsi(new ResourcePath("Objects/Weapons/Bombs/c4.rsi"), "primed");
        // TODO: mirino make Coordinates NOT nullable since the whole point of these buttons is to make people go to specific places
        public string Coordinates = "0,0";
        public string Description = "Something interesting is happening! Click here to go there!";

        public Tattle() {}

        private Tattle(EntityUid uid)
        {
            Uid = uid;
        }

        private Tattle(EntityUid uid, SpriteSpecifier spriteSpecifier)
        {
            Uid = uid;
            SpriteSpecifier = spriteSpecifier;
        }

        private Tattle(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates)
        {
            Uid = uid;
            SpriteSpecifier = spriteSpecifier;
            Coordinates = coordinates;
        }
        private Tattle(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates, string description)
        {
            Uid = uid;
            SpriteSpecifier = spriteSpecifier;
            Coordinates = coordinates;
            Description = description;
        }

        public Tattle WithCoordinates(string coordinates)
        {
            var me = this;
            me.Coordinates = coordinates;

            return me;
        }
        public Tattle WithSprite(SpriteSpecifier spriteSpecifier, string coordinates)
        {
            var me = this;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;

            return me;
        }

        public Tattle WithSpriteAndDescription(SpriteSpecifier spriteSpecifier, string coordinates, string description)
        {
            var me = this;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;
            me.Description = description;

            return me;
        }

        public Tattle FullyCustomized(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates, string description)
        {
            var me = this;
            me.Uid = uid;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;
            me.Description = description;

            return me;
        }

    }

}

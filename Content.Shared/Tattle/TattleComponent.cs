using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Utility;

namespace Content.Shared.Tattle;

[RegisterComponent]
[NetworkedComponent]
public sealed class TattleComponent : Component
{

    [ViewVariables] public List<Tattle> Tattles = new();

    [Serializable, NetSerializable]
    public struct Tattle
    {
        public EntityUid Uid;
        // TODO: mirino find a cool default. Probably something like a "!"?
        public SpriteSpecifier SpriteSpecifier = new SpriteSpecifier.Rsi(new ResourcePath("Objects/Weapons/Bombs/c4.rsi"), "primed");
        // TODO: mirino make Coordinates NOT nullable since the whole point of these buttons is to make people go to specific places
        public string Coordinates = "0,0";
        // TODO: mirino localize this
        public string Description = "Something interesting is happening! Click here to go there!";
        public TimeSpan DeletionTime;

        public Tattle() {}

        public Tattle(string coordinates, TimeSpan deletionTime)
        {
            Coordinates = coordinates;
            DeletionTime = deletionTime;
        }
        public Tattle(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates, TimeSpan deletionTime)
        {
            Uid = uid;
            SpriteSpecifier = spriteSpecifier;
            Coordinates = coordinates;
            DeletionTime = deletionTime;
        }
        public Tattle(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates, string description, TimeSpan deletionTime)
        {
            Uid = uid;
            SpriteSpecifier = spriteSpecifier;
            Coordinates = coordinates;
            Description = description;
            DeletionTime = deletionTime;
        }

        // TODO: mirino All of this is probably unnecessary since the idea is for people to instantiate ServerTattleSystem
        // and call ShowTattle() instead of making a Tattle from zero
        /*public Tattle WithCoordinates(string coordinates, TimeSpan creationTime)
        {
            var me = this;
            me.Coordinates = coordinates;
            me.CreationTime = creationTime;

            return me;
        }
        public Tattle WithSprite(SpriteSpecifier spriteSpecifier, string coordinates)
        {
            var me = this;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;
            me.CreationTime = creationTime;

            return me;
        }

        public Tattle WithSpriteAndDescription(SpriteSpecifier spriteSpecifier, string coordinates, string description)
        {
            var me = this;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;
            me.Description = description;
            me.CreationTime = creationTime;

            return me;
        }

        public Tattle FullyCustomized(EntityUid uid, SpriteSpecifier spriteSpecifier, string coordinates, string description)
        {
            var me = this;
            me.Uid = uid;
            me.SpriteSpecifier = spriteSpecifier;
            me.Coordinates = coordinates;
            me.Description = description;
            me.CreationTime = creationTime;

            return me;
        }*/

    }

}

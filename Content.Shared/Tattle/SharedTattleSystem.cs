using Robust.Shared.Serialization;

namespace Content.Shared.Tattle;

public class SharedTattleSystem : EntitySystem
{
    [Serializable, NetSerializable]
    public sealed class TattleComponentState : ComponentState
    {
        public List<TattleComponent.Tattle> Tattles { get; set; } = new();

    }
}

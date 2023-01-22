using Robust.Shared.GameStates;

namespace Content.Shared.Tattle;

[RegisterComponent]
[NetworkedComponent]
public sealed class TattleComponent : Component
{
    [ViewVariables] public Dictionary<int, EntityUid> Tattles = new();

}

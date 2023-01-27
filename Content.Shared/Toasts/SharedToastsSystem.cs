using Robust.Shared.Serialization;

namespace Content.Shared.Toasts;

public class SharedToastsSystem : EntitySystem
{
    [Serializable, NetSerializable]
    public sealed class ToastsTestMessage : EntityEventArgs
    {
        public readonly string Test;

        public ToastsTestMessage(string test)
        {
            Test = test;
        }
    }
}

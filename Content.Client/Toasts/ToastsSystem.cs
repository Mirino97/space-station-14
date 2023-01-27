using Content.Shared.Toasts;

namespace Content.Client.Toasts;

public sealed class ToastsSystem : SharedToastsSystem
{
    public override void Initialize()
    {
        SubscribeNetworkEvent<ToastsTestMessage>(OnToastTestMessage);
    }

    public void OnToastTestMessage(ToastsTestMessage msg)
    {
        Logger.Info("Hit client!");
        Logger.Info(msg.Test);
    }
}

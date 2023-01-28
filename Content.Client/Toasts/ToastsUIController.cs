using Content.Shared.Toasts;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.Toasts;

public sealed class ToastsUIController : UIController
{
    public override void Initialize()
    {
        SubscribeNetworkEvent<SharedToastsSystem.ToastsTestMessage>(OnToastTestMessage);
    }

    public void OnToastTestMessage(SharedToastsSystem.ToastsTestMessage msg, EntitySessionEventArgs args)
    {
        Logger.Info("Hit client!");
        Logger.Info(msg.Test);
    }
}

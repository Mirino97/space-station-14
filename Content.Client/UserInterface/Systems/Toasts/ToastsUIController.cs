using Content.Shared.Toasts;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.Toasts;

public sealed class ToastsUIController : UIController
{
    public override void Initialize()
    {
        SubscribeNetworkEvent<SharedToastsSystem.ToastsTestMessage>(OnToastTestMessage);
    }

    public void OnToastTestMessage(SharedToastsSystem.ToastsTestMessage msg, EntitySessionEventArgs args)
    {
        Logger.Info("Hit client!");
        switch (msg.Test)
        {
            case "Normal":
                CreateNormalToast();
                break;

            case "Second":
                CreateSecondToast();
                break;
        }
    }

    public void CreateNormalToast()
    {
        Logger.Info("Creating Normal Toast");
    }

    public void CreateSecondToast()
    {
        Logger.Info("Creating Second Toast");
    }
}

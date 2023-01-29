using Content.Client.UserInterface.Systems.Toasts.UI;
using Content.Shared.Toasts;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.Toasts;

// TODO: mirino Probably move Toasts from UserInterface to Content.Client??
public sealed class ToastsUIController : UIController
{
    // TODO: mirino I'm pretty sure this isn't right
    /*private ToastsUI? UI => UIManager.GetFirstWindow<ToastsUI>();*/
    public override void Initialize()
    {
        // TODO: mirino Jesus so many TODOs. Figure out if this is correct.
        UIManager.CreateWindow<ToastsUI>();
        // TODO: mirino Ask if subbing to Shared message like this is acceptable.
        SubscribeNetworkEvent<SharedToastsSystem.ToastsTestMessage>(OnToastTestMessage);
    }

    public void OnToastTestMessage(SharedToastsSystem.ToastsTestMessage msg, EntitySessionEventArgs args)
    {
        Logger.Info("Hit client!");
        switch (msg.Test)
        {
            case "Normal":
                CreateNormalToast(msg.Test);
                break;

            case "Second":
                CreateSecondToast(msg.Test);
                break;
        }
    }

    public void CreateNormalToast(string test)
    {
        Logger.Info("Creating Normal Toast");

        /*UI?.Test();*/
        if(UIManager.TryGetFirstWindow(out ToastsUI? toastsUI))
            toastsUI?.Test();
        else
            Logger.Info("Not Found");

    }

    public void CreateSecondToast(string test)
    {
        Logger.Info("Creating Second Toast");

        /*UI?.Test();*/
        if(UIManager.TryGetFirstWindow(out ToastsUI? toastsUI))
            toastsUI?.Test();
        else
            Logger.Info("Not Found");
    }
}

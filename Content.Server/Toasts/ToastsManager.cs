using Content.Shared.Toasts;

namespace Content.Server.Toasts;

public sealed class ToastsManager : SharedToastsSystem
{
    public void Test(string test)
    {
        Logger.Info("Inside Test in server.");
        RaiseNetworkEvent(new ToastsTestMessage(test));
    }
}

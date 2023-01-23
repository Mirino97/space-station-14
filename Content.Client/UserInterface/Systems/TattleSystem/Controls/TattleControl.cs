using Robust.Client.UserInterface.Controls;

namespace Content.Client.UserInterface.Systems.TattleSystem.Controls;

public sealed class TattleControl : BaseButton
{
    /// <summary>
    /// Creates an alert control reflecting the indicated alert + state
    /// </summary>
    /// <param name="alert">alert to display</param>
    /// <param name="severity">severity of alert, null if alert doesn't have severity levels</param>
    public TattleControl(EntityUid uid)
    {
        var test = new Label();
        test.Text = uid.ToString();

        Children.Add(test);
    }
}

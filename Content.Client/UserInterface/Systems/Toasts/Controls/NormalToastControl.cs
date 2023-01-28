using Robust.Client.Graphics;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;

namespace Content.Client.UserInterface.Systems.Toasts.Controls;

public sealed class NormalToastControl : BaseButton
{
    public NormalToastControl(string test)
    {
        MinSize = new Vector2(20, 20);
        ToolTip = "Test";

        var icon = new AnimatedTextureRect
        {
            DisplayRect =
            {
                TextureScale = (2, 2),
            }
        };

        icon.SetFromSpriteSpecifier(new SpriteSpecifier.Rsi(new ResourcePath("Objects/Weapons/Bombs/c4.rsi"), "primed"));

        // TODO: mirino make this UI prettier
        var panel = new PanelContainer()
        {
            MinSize = new Vector2(20, 20),
            PanelOverride = new StyleBoxFlat
            {
                BackgroundColor = new Color(32, 32, 40),
                BorderThickness = new Thickness(1),
                BorderColor = new Color(199, 166, 0)
            },
            Children =
            {
                new BoxContainer
                {
                    Children =
                    {
                        icon
                    }
                }
            }
        };

        Children.Add(panel);
    }
}

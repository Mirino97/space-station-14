using Content.Shared.Tattle;
using Robust.Client.Graphics;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;

namespace Content.Client.UserInterface.Systems.TattleSystem.Controls;

public sealed class TattleControl : BaseButton
{
    public TattleControl(TattleComponent.Tattle tattle)
    {
        MinSize = new Vector2(20, 20);
        ToolTip = tattle.Uid.ToString();

        var icon = new AnimatedTextureRect
        {
            DisplayRect =
            {
                TextureScale = (2, 2),
            }
        };

        // TODO: mirino Allow whoever's calling to set this to whatever they want, but have a fallback default
        var specifier = new SpriteSpecifier.Rsi(new ResourcePath("Objects/Weapons/Bombs/c4.rsi"), "primed");

        icon.SetFromSpriteSpecifier(specifier);

        // TODO: mirino make this prettier
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

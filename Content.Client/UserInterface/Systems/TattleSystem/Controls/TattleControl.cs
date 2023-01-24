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

        // TODO: mirino This should just be a SetFromSpriteSpecifier(tattle.SpriteSpecifier). The comp itself should know when
        // the SpriteSpec is null and return a default, but I can't figure it out rn. Fix this later maybe?
        // Maybe change struct to class?
        icon.SetFromSpriteSpecifier(tattle.SpriteSpecifier ?? new SpriteSpecifier.Rsi(tattle.DefaultPath, tattle.DefaultRsiState));

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

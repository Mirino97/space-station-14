namespace Content.Client.Tattle;

public sealed class TattleSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        //SubscribeNetworkEvent<Shared.Tattle.TattleSystem.TattleMessage>();

    }
}

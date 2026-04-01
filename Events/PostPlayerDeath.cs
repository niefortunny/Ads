using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;

public partial class Ads
{
    [GameEventHandler(HookMode.Post)]
    public HookResult OnPlayerDeathPost(EventPlayerDeath @event, GameEventInfo info)
    {
        var gameRules = GetGameRules();
        if (gameRules == null || gameRules.WarmupPeriod || string.IsNullOrEmpty(SelectedAd))
            return HookResult.Continue;

        var player = @event.Userid;
        if (player == null || !player.IsValid || player.IsBot)
            return HookResult.Continue;

        PlayersHash.Add(player);

        AddTimer(Config.Delay, () =>
        {
            if (player.IsValid)
                PlayersHash.Remove(player);
        });

        return HookResult.Continue;
    }
}

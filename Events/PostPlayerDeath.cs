using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Utils;

public partial class Ads
{
    [GameEventHandler(HookMode.Post)]
    public HookResult OnPlayerDeathPost(EventPlayerDeath @event, GameEventInfo info)
    {
        var gameRules = GetGameRules();
        if (gameRules == null || gameRules.WarmupPeriod)
            return HookResult.Continue;

        var player = @event.Userid;
        if (player == null || !player.IsValid || player.IsBot)
            return HookResult.Continue;

        var random = new Random();
        var adIndex = random.Next(0, Config.Ads.Count);
        var adMessage = Config.Ads[adIndex];

        Server.NextFrame(() =>
        {
            player.PrintToCenter(Localizer.ForPlayer(player, adMessage));
            RecipientFilter filter = [player];
            player.EmitSound(Config.Sound, filter);
        });

        return HookResult.Continue;
    }
}

using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

public partial class Ads
{
    [GameEventHandler(HookMode.Pre)]
    public HookResult OnRoundStartPre(EventRoundStart @event, GameEventInfo info)
    {
        PlayersHash.Clear();

        var gameRules = GetGameRules();
        if (gameRules == null || gameRules.WarmupPeriod)
            return HookResult.Continue;

        var random = new Random();
        var adIndex = random.Next(0, Config.Ads.Count);
        SelectedAd = Config.Ads[adIndex];

        return HookResult.Continue;
    }
}

using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Utils;

public partial class Ads
{
    [GameEventHandler(HookMode.Post)]
    public HookResult PreRoundFreezeEnd(EventRoundFreezeEnd @event, GameEventInfo info)
    {
        var gameRules = GetGameRules();
        if (gameRules == null || gameRules.WarmupPeriod)
            return HookResult.Continue;

        var totalScore = GetCSTeamScore(CsTeam.Terrorist) + GetCSTeamScore(CsTeam.CounterTerrorist);
        if (totalScore % Config.Interval != 0 || totalScore == 0)
            return HookResult.Continue;

        var random = new Random();
        var adIndex = random.Next(0, Config.Ads.Count);
        var adMessage = Config.Ads[adIndex];

        foreach (
            var player in Utilities.GetPlayers().Where(p => p is not null && p.IsValid && !p.IsBot)
        )
        {
            player.PrintToChat(Localizer.ForPlayer(player, adMessage));
            RecipientFilter filter = [player];
            player.EmitSound(Config.Sound, filter);
        }

        return HookResult.Continue;
    }
}

using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

public partial class Ads
{
    internal static CCSGameRules? GetGameRules() =>
    Utilities
        .FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules")
        .FirstOrDefault()
        ?.GameRules;

    internal static int GetCSTeamScore(CsTeam team)
    {
        var teamManagers = Utilities.FindAllEntitiesByDesignerName<CCSTeam>("cs_team_manager");

        foreach (var teamManager in teamManagers)
        {
            if ((int)team == teamManager.TeamNum)
            {
                return teamManager.Score;
            }
        }

        return 0;
    }
}
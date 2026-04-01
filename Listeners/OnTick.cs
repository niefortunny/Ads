using CounterStrikeSharp.API.Core.Translations;
using CS2MenuManager.API.Class;

public partial class Ads
{
    private void OnTick()
    {
        if (string.IsNullOrEmpty(SelectedAd))
            return;

        foreach (var player in PlayersHash)
        {
            if (player?.IsValid != true) continue;
            if (MenuManager.GetActiveMenu(player) != null) continue;

            player.PrintToCenterHtml(Localizer.ForPlayer(player, SelectedAd));
        }
    }
}
using CounterStrikeSharp.API.Core;

public partial class Ads
{
    public override void Load(bool hotReload)
    {
        if (hotReload)
            PlayersHash.Clear();

        RegisterListener<Listeners.OnTick>(OnTick);
    }
}
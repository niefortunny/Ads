using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

public class Config : BasePluginConfig
{
    [JsonPropertyName("Sound")]
    public string Sound { get; set; } = "tr.Popup";

    [JsonPropertyName("Ads")]
    public List<string> Ads { get; set; } = [];
}

public partial class Ads
{
    public Config Config { get; set; } = new();

    public void OnConfigParsed(Config config)
    {
        Config = config;
    }
}

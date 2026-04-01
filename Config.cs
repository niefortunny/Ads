using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

public class Config : BasePluginConfig
{
    [JsonPropertyName("Delay")]
    public float Delay { get; set; } = 7f;

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

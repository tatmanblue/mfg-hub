namespace MfgHubLib;

public class BuildOfMaterial
{
    public Component Component { get; set; } = null;
    public double Quantity { get; set; } = 0;
    public double BatchSize { get; set; } = 0;
    public int BatchCount { get; set; } = 0;
}
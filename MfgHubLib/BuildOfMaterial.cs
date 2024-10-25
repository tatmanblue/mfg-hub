namespace MfgHubLib;

/// <summary>
/// used by order as the data for computing materials needed to complete an order 
/// </summary>
public class BuildOfMaterial
{
    public Component Component { get; set; } = null;
    public double Quantity { get; set; } = 0;
    public double BatchSize { get; set; } = 0;
    public int BatchCount { get; set; } = 0;
}
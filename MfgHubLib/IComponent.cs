namespace MfgHubLib;

public interface IComponent
{
    string Name { get; set; }
    double BatchSize { get; set; }
    int UnitCost { get; set; }
    bool IsCrafted { get; set; }
}

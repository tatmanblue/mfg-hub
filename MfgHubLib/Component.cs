using System;
using System.Collections.Generic;
using System.Text;

namespace MfgHubLib;
 
/// <summary>
/// Recipe is a class that represents a recipe for manufacturing a product.  It contains a name, a list of ingredients,
/// which may be pure or recipe, and a batch size.
/// </summary>
public class Component : IComponent, IEquatable<Component>
{
    public string Name { get; set; } = "";
    public Dictionary<IComponent, double> Ingredients { get; set; } = new();
    public bool IsCrafted { get; set; } = true;
    public double BatchSize { get; set; } = 0;
    public int UnitCost { get; set; } = 0;
    
    #region overrides
    public override string ToString()
    {
        return $"{Name}";
    }
    #endregion
    
    #region IEquatable
    public override bool Equals(object obj)
    {
        if (obj is Component other)
        {
            return Equals(other);
        }
        return false;
    }

    public bool Equals(Component other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }    
    #endregion
}

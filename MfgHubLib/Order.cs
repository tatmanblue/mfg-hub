namespace MfgHubLib;

public class Order
{
    public Component Component { get; set; } = null;
    public double Quantity { get; set; } = 0;
    
    public Dictionary<Component, BuildOfMaterial> FinalBOM { get; set; } = new();

    public void BuildBOM()
    {
        BuildBOM(FinalBOM, Component, Quantity);
    }

    private void BuildBOM(Dictionary<Component, BuildOfMaterial> bom, Component component, double quantity)
    {
        // build Component using the ingredients of component, adding the quantity of each
        // ingredient to the BOM.  Since an ingredient can be a component or a raw material,
        // we need to check if the ingredient is crafted or not.  If it is crafted, we need
        // to call BuildBOM() on that ingredient to get its BOM.
        // repeat for each Quantity
        Console.WriteLine($"\r\nBuilding BOM for {component.Name} x {quantity}");
        double built = 0;
        while (built < Quantity)
        {
            BuildOfMaterial workingBom = GetOrAdd(bom, component);
            workingBom.Quantity += quantity;
            while (workingBom.Quantity > workingBom.BatchSize)
            {
                // we do not have enough in the batch to match quantity, so we build another batch
                // using the ingredients of the component and repeat until we have enough
                foreach (var componentIngredient in component.Ingredients)
                {
                    Component ingredient = componentIngredient.Key as Component;
                    BuildOfMaterial bomItem = GetOrAdd(bom, ingredient);
                    Console.WriteLine($"Evaluating ingredient {ingredient.Name}");
                    if (ingredient.IsCrafted)
                    {
                        Console.WriteLine($"Ingredient {ingredient.Name} is crafted, making BOM for {componentIngredient.Value} items");
                        BuildBOM(bom, ingredient, componentIngredient.Value);
                    }
                    else
                    {
                        Console.WriteLine($"Ingredient {ingredient.Name} is raw material, adding {componentIngredient.Value}");
                        bomItem.Quantity += componentIngredient.Value;
                    }
                    
                }
                
                // we have created a batch, so we need to increment the count
                Console.WriteLine($"Bumping BatchSize for {workingBom.Component.Name} to {component.BatchSize} ({workingBom.Component.BatchSize})");
                workingBom.BatchSize += component.BatchSize;
                workingBom.BatchCount++;
            }

            built += workingBom.BatchSize;
        }
    }

    private BuildOfMaterial GetOrAdd(Dictionary<Component, BuildOfMaterial> bom, Component com)
    {
        BuildOfMaterial item = null;
        if (!bom.TryGetValue(com, out item))
        {
            Console.WriteLine($"Adding new BuildOfMaterial {com.Name}");
            item = new BuildOfMaterial()
            {
                Component = com,
                Quantity = 0,
                BatchSize = 0,
                BatchCount = 0
            };
            
            bom.Add(com, item);
        }
        
        return item;
    }
}
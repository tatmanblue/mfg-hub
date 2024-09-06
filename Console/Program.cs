// See https://aka.ms/new-console-template for more information

using System;
using MfgHubLib;

Console.WriteLine("\r\n--------------------------------------------\r\n");
Console.WriteLine("Dual Universe Manufacturing Hub 1.0 \r\n");

Component iron = new Component()
{
    Name = "Iron",
    BatchSize = 45,
    IsCrafted = false,
    UnitCost = 10
};

Component carbon = new Component()
{
    Name = "Carbon",
    BatchSize = 45,
    IsCrafted = false,
    UnitCost = 10
};

Component steel = new Component()
{
    Name = "Steel",
    BatchSize = 86.25
};

steel.Ingredients.Add(iron, 100);  // Uses 100 units of iron to produce 86.25 units of steel
steel.Ingredients.Add(carbon, 50); // Uses 50 units of carbon to produce 86.25 units of steel

Component frame = new Component()
{
    Name = "Basic Standard Frame S",
    BatchSize = 1
};

// A frame uses 11 units of steel
frame.Ingredients.Add(steel, 11);

Order order = new Order()
{
    Component = frame,
    Quantity = 7
};

order.BuildBOM();

Console.WriteLine("\r\n--------------------------------------------\r\n");
Console.WriteLine($"Build of Material for Order: {order.Component.Name} x {order.Quantity} \r\n");
Console.WriteLine("{0,-40} {1,10}   {2,10}", "Item", "Quantity", "Total Made");
Console.WriteLine("{0,-40} {1,10}   {2,10}", "----", "--------", "---------");


foreach (var material in order.FinalBOM)
{
    Console.WriteLine("{0,-40} {1,10}   {2,10}", material.Key.Name, material.Value.Quantity, material.Value.BatchSize);
}


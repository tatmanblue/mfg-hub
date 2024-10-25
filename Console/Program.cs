// See https://aka.ms/new-console-template for more information

using System;
using MfgHubLib;

Console.WriteLine("\r\n--------------------------------------------\r\n");
Console.WriteLine("Dual Universe Manufacturing Hub 1.0 \r\n");

Func<Component> factory = () => new Component();
string dataPath = @"..\data";
IComponentLoader loader = new ComponentJsonFileLoader(dataPath);

Component iron = loader.LoadComponent("iron", factory);

Component carbon = loader.LoadComponent("carbon", factory);

Component steel =  loader.LoadComponent("steel", factory);

Component frame = loader.LoadComponent("Basic Standard Frame S", factory);

/*
ComponentJsonFileWriter.Write(@"..\data", carbon);
ComponentJsonFileWriter.Write(@"..\data", iron);
ComponentJsonFileWriter.Write(@"..\data", steel);
ComponentJsonFileWriter.Write(@"..\data", frame);
*/

Order order = new Order()
{
    Component = frame,
    Quantity = 7
};

order.BuildBOM();

Console.WriteLine("\r\n--------------------------------------------\r\n");
Console.WriteLine($"Build of Material for Order: {order.Component.Name} x {order.Quantity} \r\n");
Console.WriteLine("{0,-40} {1,10}   {2,10}", "Item", "Quantity", "Total Made");
Console.WriteLine("{0,-40} {1,10}   {2,10}", "----", "--------", "----------");


foreach (var material in order.FinalBOM)
{
    Console.WriteLine("{0,-40} {1,10}   {2,10}", material.Key.Name, material.Value.Quantity, material.Value.BatchSize);
}


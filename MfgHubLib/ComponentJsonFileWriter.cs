using Newtonsoft.Json;

namespace MfgHubLib;

/// <summary>
/// Helper class for building some of the json and not  meant to be used in the project beyond that function
/// </summary>
public static class ComponentJsonFileWriter
{
    public static void Write(string jsonFilePath, IComponent component)
    {
        string json = JsonConvert.SerializeObject(component);
        
        string fileName = Path.Combine(jsonFilePath, $"{component.Name}.json");
        
        Console.WriteLine($"Writing component to {fileName}");
        System.IO.File.WriteAllText(fileName, json);
    }
}
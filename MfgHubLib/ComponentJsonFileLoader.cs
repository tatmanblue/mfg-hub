using Newtonsoft.Json;

namespace MfgHubLib;

public class ComponentJsonFileLoader(string jsonFilePath) : IComponentLoader
{
    /// <summary>
    /// every component is saved in its own json file so this function will look
    /// for that file and return the IComponent
    /// </summary>
    /// <param name="componentName"></param>
    /// <param name="factory"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadComponent<T>(string componentName, Func<T> factory) where T : IComponent
    {
        string fileName = Path.Combine(jsonFilePath, $"{componentName}.json");
        Console.WriteLine($"Loading component: {fileName}");
        
        string json = File.ReadAllText(fileName);

        T component = factory();
        JsonConvert.PopulateObject(json, component);
        return component;
    }
}
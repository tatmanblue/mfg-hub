namespace MfgHubLib;

public interface IComponentLoader
{
    T LoadComponent<T>(string json, Func<T> factory) where T : IComponent;
}
using Newtonsoft.Json;

namespace MfgHubLib;

public class IngredientsJsonTypeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Dictionary<IComponent, double>);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var ingredients = new Dictionary<IComponent, double>();

        if (reader.TokenType == JsonToken.StartObject)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var componentName = reader.Value.ToString();
                    Func<Component> factory = () => new Component();
                    string dataPath = @"..\data";
                    IComponentLoader loader = new ComponentJsonFileLoader(dataPath);

                    IComponent component = loader.LoadComponent(componentName, factory);
                    reader.Read();
                    ingredients.Add(component, (double) reader.Value);
                }
            }
        }

        return ingredients;
    }
}
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LearnCSharp
{
    /// <summary>
    /// Json converter is used to set as attribute to map interface with concrete class
    /// So that Json can serialize or deserialize will work using the concrete class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class InterfaceToClassJsonConverter<T> : JsonConverter<T>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            JsonSerializer.Serialize(writer, value, type, options);
        }
    }
}

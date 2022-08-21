using System.Text.Json;

namespace EDiaristas.Core.Extensions;

public static class HttpContentExtensions
{
    public static T Deserialize<T>(
        this HttpContent content,
        JsonSerializerOptions? jsonSerializerOptions) where T : new()
    {
        return content.ReadFromJsonAsync<T>(jsonSerializerOptions).Result ?? new T();
    }
}
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EDiaristas.Admin.Common.Extensions;

public static class ITempDictionaryExtensions
{
    public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        tempData[key] = JsonSerializer.Serialize(value);
    }

    public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        object? value;
        tempData.TryGetValue(key, out value);
        return value == null ? null : JsonSerializer.Deserialize<T>((string)value);
    }
}
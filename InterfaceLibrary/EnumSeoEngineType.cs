using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SympliSEOSolution.InterfaceLibrary
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumSeoEngineType
    {
        Google,
        Bing
    }
}

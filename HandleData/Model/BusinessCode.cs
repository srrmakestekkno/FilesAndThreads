using System.Text.Json.Serialization;

namespace HandleData.Model
{
    public class BusinessCode
    {
        [JsonPropertyName("kode")]
        public string? Code { get; set; }
    }
}

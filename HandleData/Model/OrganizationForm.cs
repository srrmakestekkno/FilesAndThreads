using System.Text.Json.Serialization;

namespace HandleData.Model
{
    public class OrganizationForm
    {
        [JsonPropertyName("kode")]
        public string? Code { get; set; }
    }
}

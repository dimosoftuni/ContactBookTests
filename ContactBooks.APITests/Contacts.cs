using System.Text.Json.Serialization;

namespace ContactBooks.APITests
{
    public class Contacts
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }
    }
}
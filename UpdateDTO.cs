using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DaBot
{
    [Serializable]
    public class UpdateDTO
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("object")]
        public JObject Object { get; set; }

        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}

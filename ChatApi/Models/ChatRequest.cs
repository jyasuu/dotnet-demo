using Newtonsoft.Json;

namespace ChatApi.Models
{
    public class ChatRequest
    {
        [JsonProperty("messages")]
        public Message[] Messages { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("stream")]
        public bool Stream { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }
    }

    public class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}

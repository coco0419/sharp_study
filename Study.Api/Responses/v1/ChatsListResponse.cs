namespace Study.Api.Responses.v1
{
    using Newtonsoft.Json;
    using Study.Common.Database.Entities;

    public class ChatsListResponse
    {
        [JsonProperty("chat")]
        public Chat Chat { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
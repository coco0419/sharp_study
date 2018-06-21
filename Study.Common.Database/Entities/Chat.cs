namespace Study.Common.Database.Entities
{
    using Newtonsoft.Json;

    public class Chat
    {
        [JsonProperty("id")]
        public virtual long? Id { get; set; }

        [JsonProperty("message")]
        public virtual string Message { get; set; }

        [JsonProperty("user_id")]
        public virtual long? UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}

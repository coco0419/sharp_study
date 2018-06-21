namespace Study.Common.Database.Entities
{
    using BCrypt.Net;
    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty("id")]
        public virtual long? Id { get; set; }

        [JsonProperty("loginId")]
        public virtual string LoginId { get; set; }

        [JsonProperty("nickname")]
        public virtual string Nickname { get; set; }

        [JsonIgnore]
        public virtual string Password { get; set; }

        public virtual bool Verify(string password)
        {
            return BCrypt.Verify(password, Password);
        }
    }
}

namespace Study.Common.Database.Entities
{
    using JWT;
    using JWT.Algorithms;
    using JWT.Serializers;
    using Newtonsoft.Json;
    using System;
    using System.Text;

    public class Token
    {
        [JsonProperty("id")]
        public virtual long? Id { get; set; }

        [JsonProperty("value")]
        public virtual string Value { get; set; }

        [JsonIgnore]
        public virtual string Secret { get; set; }

        [JsonProperty("expired_at")]
        public virtual DateTime? ExpiredAt { get; set; }

        public virtual User Payload()
        {
            var decoder = new JwtDecoder(new JsonNetSerializer(), new JwtValidator(new JsonNetSerializer(), new UtcDateTimeProvider()), new JwtBase64UrlEncoder());

            return decoder.DecodeToObject<User>(Value, Secret, true);
        }

        public static Token Build(User payload)
        {
            var secret = GenerateSecret(18);
            var encoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());
            var value = encoder.Encode(payload, secret);

            return new Token()
            {
                Value = value,
                Secret = secret,
                ExpiredAt = DateTime.Now.AddMinutes(30)
            };
        }

        private static string GenerateSecret(int length)
        {
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var builder = new StringBuilder(length);
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                var pos = random.Next(chars.Length);

                builder.Append(chars[pos]);
            }

            return builder.ToString();
        }
    }
}

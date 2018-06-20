namespace Study.Common.Database.Entities
{
    public class Chat
    {
        public long? Id { get; set; }

        public string Message { get; set; }

        public long? UserId { get; set; }
    }
}

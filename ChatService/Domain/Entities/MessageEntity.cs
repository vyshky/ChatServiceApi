namespace ChatService.Domain.Entities
{
    public class MessageEntity
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
        public Guid chanel_id { get; set; }
        public string content { get; set; }
        public DateTime dateTime { get; set; }

        public MessageEntity()
        {
            id = Guid.NewGuid();
        }
    }
}

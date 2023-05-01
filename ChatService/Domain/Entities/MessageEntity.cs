namespace ChatService.Domain.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChanelId { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }

        public MessageEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}

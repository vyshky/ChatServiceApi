namespace ChatService.Domain.Entities
{
    public class UserLastSeenEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChanelId { get; set; }
        public DateTime DateTime { get; set; }

        public UserLastSeenEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}

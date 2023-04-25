namespace ChatService.Domain.Entities
{
    public class UserLastSeenEntity
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
        public Guid chanel_id { get; set; }
        public DateTime dateTime { get; set; }

        public UserLastSeenEntity()
        {
            id = Guid.NewGuid();
        }
    }
}

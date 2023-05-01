using ChatService.Domain;
using ChatService.Domain.Entities;
using ChatService.Domain.Models;

namespace ChatService.Services.Message
{
    public class MessageService : IMessageService
    {
        ApplicationDbContext applicationDbContext;
        public MessageService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void SendMessage(Guid userId, MessageModel message)
        {
            applicationDbContext.Message.Add(new MessageEntity()
            {
                UserId = userId,
                ChanelId = message.ChanelCode,
                Content = message.Content,
                SendTime = DateTime.UtcNow
            });
            applicationDbContext.SaveChanges();
        }
        public List<MessageEntity> FindMessagesByChanelId(Guid chanelId)
        {
            return applicationDbContext.Message.Where(x => x.ChanelId == chanelId).ToList();

        }
        public Guid CreateGroup()
        {
            Guid groupId = Guid.NewGuid();
            applicationDbContext.Group.Add(new GroupEntity() { Id = groupId });
            applicationDbContext.SaveChanges();
            return groupId;
        }

        public bool ContainsByGroup(Guid group)
        {
            return applicationDbContext.Group.Contains(new GroupEntity() { Id = group });
        }
    }
}

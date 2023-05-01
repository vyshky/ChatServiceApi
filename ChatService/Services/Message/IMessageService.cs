using ChatService.Domain.Entities;
using ChatService.Domain.Models;

namespace ChatService.Services.Message
{
    public interface IMessageService
    {
        public void SendMessage(Guid userId, MessageModel message);
        public List<MessageEntity> FindMessagesByChanelId(Guid chanelId);
        public Guid CreateGroup();
        public bool ContainsByGroup(Guid group);
    }
}

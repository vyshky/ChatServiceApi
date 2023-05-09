using ChatService.Domain.Entities;
using ChatService.Domain.Models;

namespace ChatService.Services.Message
{
    public interface IMessageService
    {
        public void SendMessage(Guid userId,string senderName, MessageModel message);
        public List<MessageEntity> FindMessagesByTagName(string tagName);
        public List<MessageEntity> FindMessagesByChanelId(Guid chanelId);
        public Guid CreateGroup();
        public bool ContainsByGroup(Guid group);
    }
}

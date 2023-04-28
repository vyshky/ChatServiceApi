using ChatService.Domain.Models;

namespace ChatService.Services.Message
{
    public interface IMessageService
    {
        public void Send(MessageModel message);
    }
}

using System.ComponentModel.DataAnnotations;

namespace ChatService.Domain.Models
{
    public class MessageModel
    {
        [Required]
        public Guid ChanelCode { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        [RegularExpression(@"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$")]
        public string RecipientName { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Значение {0} не может превышать {1} символов. и быть короче {2}")]
        public string Content { get; set; }
    }
}

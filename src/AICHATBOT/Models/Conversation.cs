using AICHATBOT.Enums;

namespace AICHATBOT.Models;

public class Conversation
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public List<Message> Messages { get; set; } = new();
    public ConversationStatus Status { get; set; } = ConversationStatus.Active;
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
}

using AICHATBOT.Models;

namespace AICHATBOT.Interfaces;

public interface IEscalationService
{
    SupportTicket Escalate(Conversation conversation, string reason);
}

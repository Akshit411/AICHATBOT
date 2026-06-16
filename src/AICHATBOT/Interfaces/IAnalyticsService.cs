using AICHATBOT.Models;

namespace AICHATBOT.Interfaces;

public interface IAnalyticsService
{
    AnalyticsRecord GenerateRecord(Conversation conversation, bool resolvedByBot, double satisfactionScore);
}

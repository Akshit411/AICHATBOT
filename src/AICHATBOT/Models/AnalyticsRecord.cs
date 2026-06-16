namespace AICHATBOT.Models;

public class AnalyticsRecord
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public int MessageCount { get; set; }
    public bool ResolvedByBot { get; set; }
    public double SatisfactionScore { get; set; }
}

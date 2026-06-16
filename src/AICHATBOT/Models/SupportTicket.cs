namespace AICHATBOT.Models;

public class SupportTicket
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string IssueSummary { get; set; } = string.Empty;
    public bool IsEscalated { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

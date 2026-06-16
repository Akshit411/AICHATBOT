using AICHATBOT.Enums;
using AICHATBOT.Interfaces;
using AICHATBOT.Models;

namespace AICHATBOT.Services;

public class ChatbotEngine
{
    private readonly IIntentRecognizer _intentRecognizer;
    private readonly IKnowledgeBaseService _knowledgeBaseService;
    private readonly IEscalationService _escalationService;
    private readonly IAnalyticsService _analyticsService;

    public ChatbotEngine(
        IIntentRecognizer intentRecognizer,
        IKnowledgeBaseService knowledgeBaseService,
        IEscalationService escalationService,
        IAnalyticsService analyticsService)
    {
        _intentRecognizer = intentRecognizer;
        _knowledgeBaseService = knowledgeBaseService;
        _escalationService = escalationService;
        _analyticsService = analyticsService;
    }

    public string HandleMessage(Conversation conversation, string userInput)
    {
        conversation.Messages.Add(new Message
        {
            Id = Guid.NewGuid(),
            Sender = "Customer",
            Content = userInput,
            Timestamp = DateTime.UtcNow
        });

        var intent = _intentRecognizer.Recognize(userInput);
        var article = _knowledgeBaseService.Search(intent.Name);

        if (article is not null)
        {
            var response = article.Content;
            conversation.Messages.Add(new Message
            {
                Id = Guid.NewGuid(),
                Sender = "Bot",
                Content = response,
                Timestamp = DateTime.UtcNow
            });
            return response;
        }

        conversation.Status = ConversationStatus.Escalated;
        _escalationService.Escalate(conversation, "No matching knowledge article found.");
        return "I’m unable to resolve this right now. I’ve escalated your issue to a support agent.";
    }

    public AnalyticsRecord CloseConversation(Conversation conversation, bool resolvedByBot, double satisfactionScore)
    {
        conversation.Status = ConversationStatus.Closed;
        return _analyticsService.GenerateRecord(conversation, resolvedByBot, satisfactionScore);
    }
}

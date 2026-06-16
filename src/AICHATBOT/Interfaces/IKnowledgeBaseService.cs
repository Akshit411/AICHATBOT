using AICHATBOT.Models;

namespace AICHATBOT.Interfaces;

public interface IKnowledgeBaseService
{
    KnowledgeArticle? Search(string query);
}

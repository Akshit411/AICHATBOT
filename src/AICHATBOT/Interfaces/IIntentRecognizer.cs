using AICHATBOT.Models;

namespace AICHATBOT.Interfaces;

public interface IIntentRecognizer
{
    Intent Recognize(string userInput);
}

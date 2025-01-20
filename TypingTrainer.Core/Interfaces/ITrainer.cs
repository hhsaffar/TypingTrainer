using TypingTrainer.Core.Models;

namespace TypingTrainer.Core.Interfaces;

public interface ITrainer
{
    TrainerResponse ReceiveKeyStroke(char keyChar);
    char GiveNextChallenge();
}

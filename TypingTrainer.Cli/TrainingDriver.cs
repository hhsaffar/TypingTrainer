using TypingTrainer.Core.Interfaces;
using TypingTrainer.Core.Models;

internal class TrainingDriver : ITrainingDriver
{
    private ITrainer _trainer;

    public TrainingDriver(ITrainer trainer)
    {
        _trainer = trainer ?? throw new ArgumentNullException(nameof(trainer));
    }
    public void Run()
    {
        while (true)
        {
            var nextChallenge = _trainer.GiveNextChallenge();

            ShowNextChallenge(nextChallenge);

            var key = Console.ReadKey(intercept: true);

            if (IsTerminationSignal(key))
            {
                ShowExitMessage();
                break;
            }
            Console.WriteLine($"\nYou pressed: {key.KeyChar}");

            var trainerResponse = _trainer.ReceiveKeyStroke(key.KeyChar);

            PrintTrainerResponseMessage(trainerResponse);

        }
    }

    private void ShowNextChallenge(char nextChallenge)
    {
        Console.WriteLine($"Type this: {nextChallenge}");
    }

    private void ShowExitMessage()
    {
        Console.WriteLine("\nSee you next time!");
    }

    private bool IsTerminationSignal(ConsoleKeyInfo key)
    {
        return key.Key == ConsoleKey.Escape;
    }

    private void PrintTrainerResponseMessage(TrainerResponse trainerResponse)
    {
        Console.WriteLine(trainerResponse.Content);
    }

    

    
}

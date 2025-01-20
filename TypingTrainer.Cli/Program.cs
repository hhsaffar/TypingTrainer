
using TypingTrainer.Core.Interfaces;
using TypingTrainer.Core.Trainers;

public class Program
{
    public static void Main(string[] args)
    {
        ITrainer trainer = new RandomTrainer();

        ITrainingDriver trainingDriver = new TrainingDriver(trainer);

        trainingDriver.Run();
    }
}

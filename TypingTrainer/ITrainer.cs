internal interface ITrainer
{
    TrainerResponse ReceiveKeyStroke(char keyChar);
    char GiveNextChallenge();
}

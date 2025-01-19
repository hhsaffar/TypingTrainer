internal class RandomTrainer : ITrainer
{
    private readonly char[] _allKeys;
    private char _lastChallenge;
    private readonly Random _random = new Random();

    public RandomTrainer()
    {
        _allKeys = Enumerable.Range(33, 126 - 33 + 1).Select(x => (char)x).ToArray();
    }

    public char GiveNextChallenge()
    {
        int randomIndex = _random.Next(_allKeys.Length);
        _lastChallenge = _allKeys[randomIndex];
        return _lastChallenge;
    }

    public TrainerResponse ReceiveKeyStroke(char keyChar)
    {
        if (_lastChallenge == '\0')
            return new TrainerResponse(ResponseMessageType.Error, "No challenge has been given yet.");

        if (keyChar == _lastChallenge)
            return new TrainerResponse(ResponseMessageType.Correct, "You typed it correctly!");
        else
            return new TrainerResponse(ResponseMessageType.Error, "Wrong key!");
    }
}
using System;
using TypingTrainer.Core.Models;
using TypingTrainer.Core.Trainers;

namespace TypingTrainer.Tests;

public class RandomTrainerTests
{
    [Fact]
    public void GiveNextChallenge_ShouldReturnValidCharacter()
    {
        var trainer = new RandomTrainer();

        char c = trainer.GiveNextChallenge();

        Assert.InRange(c, (char)33, (char)126);
    }

    [Fact]
    public void ReceiveKeyStroke_ShouldReturnCorrect_WhenKeyStrokeMatchesTheChallenge()
    {
        var trainer = new RandomTrainer();

        char c = trainer.GiveNextChallenge();
        var resp = trainer.ReceiveKeyStroke(c);

        
        Assert.Equal(Core.Models.ResponseMessageType.Correct, resp.ResponseType);
    }

    [Fact]
    public void ReceiveKeyStroke_ShouldReturnError_WhenKeyStrokeDoesntMatchTheChallenge()
    {
        var trainer = new RandomTrainer();

        char c = trainer.GiveNextChallenge();

        char input = (c=='x')?'y':'x';

        var resp = trainer.ReceiveKeyStroke(input);

        Assert.Equal(ResponseMessageType.Error, resp.ResponseType);
    }
}

using NUnit.Framework;
public class ObserveGameStateChanges : IObserver<int>
{
    public void UpdatePropriety(int value)
    {
        var gameStateService = GameStateService.Get();
        var gameState = gameStateService.State;

        Assert.That(gameState.Coins, Is.EqualTo(value));
    }
}

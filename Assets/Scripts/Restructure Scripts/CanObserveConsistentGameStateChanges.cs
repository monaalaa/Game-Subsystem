using NUnit.Framework;
using System.Collections.Generic;
//Observe MultiDAtaChanges
public class CanObserveConsistentGameStateChanges : IObserver<List<int>>
{
    public bool stateObserverCalled = false;

    public void UpdatePropriety(List<int> proprietyValue)
    {
        var gameStateService = GameStateService.Get();
        stateObserverCalled = true;
        var gameState = gameStateService.State;

        Assert.That(gameState.Stars, Is.EqualTo(proprietyValue[0]));
        Assert.That(gameState.Coins, Is.EqualTo(proprietyValue[1]));
    }
}

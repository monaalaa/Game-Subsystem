using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class TestSuite
    {
        [Test]
        public void CanInitGameState()
        {
            var gameStateService = GameStateService.Get();
            gameStateService.Init(10,0);

            var gameState = gameStateService.State;
        
            Assert.That(gameState.Coins, Is.EqualTo(10));
            Assert.That(gameState.Stars, Is.EqualTo(0));
        }

        [Test]
        public void CanObserveGameStateChanges()
        {
            var gameStateService = GameStateService.Get();
            gameStateService.Init(10, 0);
           
            var gameState = gameStateService.State;
            var stateObserverCalled = false;

            gameState.CoinsChanged += () =>
            {
                stateObserverCalled = true;

                ObserveGameStateChanges gameStateChanges = new ObserveGameStateChanges();
                ObserverController.Get().observableInt.Register(gameStateChanges);
                ObserverController.Get().observableInt.Propriety = 8;

            };
            ShopService.Get().UseCoins(2);

            //Note:-Assume That game state is in a consistent state.
            ObserverController.Get().observableInt.Notify();
            Assert.That(stateObserverCalled, "Obsever not called");

        }

        [Test]
        public void CanObserveConsistentGameStateChanges()
        {
            var gameStateService = GameStateService.Get();
            gameStateService.Init(10, 0);
            var stateObserverCalled = false;

            void StateValidator()
            {
                CanObserveConsistentGameStateChanges stateChanges = new CanObserveConsistentGameStateChanges();
                stateObserverCalled = true;
                ObserverController.Get().observableProperity.Register(stateChanges);
                ObserverController.Get().observableProperity.Propriety = new List<int> { 1, 9 };
            }

            gameStateService.State.CoinsChanged += StateValidator;
            gameStateService.State.StarsChanged += StateValidator;

            var shopService = ShopService.Get();
            shopService.BuyStars(1, 1);
            ObserverController.Get().observableProperity.Notify();

            Assert.That(stateObserverCalled, "Obsever not called");
        }
    }
}
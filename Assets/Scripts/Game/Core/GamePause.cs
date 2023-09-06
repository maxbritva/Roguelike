using Game.Core.LevelSystem;
using Game.Core.Loot;
using UnityEngine;
using Zenject;

namespace Game.Core
{
    public class GamePause : MonoBehaviour
    {
        private LevelSystem.LevelSystem _levelSystem;
        private GameTimer _gameTimer;
        private LootBoxSpawner _lootBoxSpawner;
        private bool _isStopped;
        public bool IsStopped => _isStopped;

        public void SetPause(bool value)
        {
            if(value)
                PauseOn();
            else
                PauseOff();
        }

        private void PauseOn()
        {
            _gameTimer.Deactivate();
            _levelSystem.Deactivate();
            _lootBoxSpawner.Deactivate();
            _isStopped = true;
        }

        private void PauseOff()
        {
            _gameTimer.Activate();
            _levelSystem.Activate();
            _lootBoxSpawner.Activate();
            _isStopped = false;
        }
        [Inject] private void Construct(GameTimer timer, LevelSystem.LevelSystem level, LootBoxSpawner lootBox)
        {
            _gameTimer = timer;
            _levelSystem = level;
            _lootBoxSpawner = lootBox;
        }
    }
}
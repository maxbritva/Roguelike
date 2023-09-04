using System;
using UnityEngine;
using Zenject;

namespace Game.Core.Upgrades
{
    public class UpgradeWindow : MonoBehaviour
    {
        private GamePause _gamePause;
        private void OnEnable() => _gamePause.SetPause(true);

        private void OnDisable() => _gamePause.SetPause(false);

        [Inject] private void Construct(GamePause gamePause) => _gamePause = gamePause;
    }
}
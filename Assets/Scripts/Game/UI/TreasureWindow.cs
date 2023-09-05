using Game.Core;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.UI
{
	public class TreasureWindow : MonoBehaviour
	{
		private GamePause _gamePause;
		private PlayerUpgrade _playerUpgrade;
		
		private void OnEnable() => _gamePause.SetPause(true);

		private void OnDisable() => _gamePause.SetPause(false);
		
		[Inject] private void Construct(GamePause gamePause, PlayerUpgrade playerUpgrade)
		{
			_gamePause = gamePause;
			_playerUpgrade = playerUpgrade;
		}
	}
}
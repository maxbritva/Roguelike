using System.Collections;
using Game.Core;
using Game.FX.CountUpAnimator;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.UI
{
	public class TreasureWindow : MonoBehaviour
	{
		[SerializeField] private Button _button;
		private GamePause _gamePause;
		private int _randomCoins;
		[SerializeField] private TextMeshProUGUI _coinsText;
		private CountUp _countUp;
		private PlayerData _playerData;
		private CoinsUpdater _coinsUpdater;
		private WaitForSeconds _interval;

		private void OnEnable() => _gamePause.SetPause(true);

		private void OnDisable() => _gamePause.SetPause(false);

		private void OnGUI()
		{
			_button.gameObject.SetActive(false);
			_randomCoins = Random.Range(1, 100);
			_coinsText.text = "0";
			_interval = new WaitForSeconds(2.6f);
			StartCoroutine(StartCalculating());
		}

		public void GetReward()
		{
			_playerData.AddRewardCoins(_randomCoins);
			_coinsUpdater.OnCountChanged?.Invoke();
		}

		[Inject] private void Construct(GamePause pause, CountUp countUp, PlayerData data, CoinsUpdater updater)
		{
			_gamePause = pause;
			_countUp = countUp;
			_playerData = data;
			_coinsUpdater = updater;
		}
		
		private IEnumerator StartCalculating() {
			_countUp.StartCoroutine(_countUp.Activate(_randomCoins, 0, _coinsText));
			yield return _interval;
			_button.gameObject.SetActive(true);
		}
	}
	}

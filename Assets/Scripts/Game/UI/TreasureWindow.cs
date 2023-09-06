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
		private float _randomCoins;
		[SerializeField] private TextMeshProUGUI _coinsText;
		private CountUp _countUp;
		private PlayerData _playerData;
		private CoinsUpdater _coinsUpdater;
		private WaitForSeconds _interval;

		private void OnEnable()
		{
			_gamePause.SetPause(true);
			_button.gameObject.SetActive(false);
			_randomCoins = Random.Range(1f, 100f);
			_coinsText.text = "0";
			_interval = new WaitForSeconds(2.6f);
			StartCoroutine(StartCalculating());
		}

		private void OnDisable() => _gamePause.SetPause(false);

		public void GetReward()
		{
			_playerData.AddRewardCoins(Mathf.FloorToInt(_randomCoins));
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
			_countUp.Initialize(_randomCoins, 0, _coinsText);
			yield return _interval;
			_button.gameObject.SetActive(true);
		}
	}
	}

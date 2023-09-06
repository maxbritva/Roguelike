using System.Collections;
using Game.Core;
using Game.FX.CountUpAnimator;
using Game.Player;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class EndGameWindow : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private float _coins;
        [SerializeField] private TextMeshProUGUI _coinsText;
        private CountUp _countUp;
        private PlayerData _playerData;
        private SaveProgress _saveProgress;
        private WaitForSeconds _interval;
        private GamePause _gamePause;

        private void OnEnable()
        {
            _gamePause.SetPause(true);
            _button.gameObject.SetActive(false);
            _coins = _playerData.Coins;
            _coinsText.text = "0";
            _interval = new WaitForSeconds(2.6f);
            StartCoroutine(StartCalculating());
        }

        public void ExitGame()
        {
            _saveProgress.SaveData();
            SceneManager.LoadSceneAsync(0);
        }

        [Inject] private void Construct(SaveProgress save, CountUp countUp, PlayerData data, CoinsUpdater updater, GamePause pause)
        {
            _countUp = countUp;
            _playerData = data;
            _gamePause = pause;
            _saveProgress = save;
        }
		
        private IEnumerator StartCalculating() {
            if(_coins > 5)
                _countUp.Initialize(_coins, 0, _coinsText);
            else
            {
                _coinsText.text = _coins.ToString();
                _button.gameObject.SetActive(true);
            }
            yield return _interval;
            _button.gameObject.SetActive(true);
        }
    }
}
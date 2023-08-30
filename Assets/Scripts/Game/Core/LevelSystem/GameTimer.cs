using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Core.LevelSystem
{
	public class GameTimer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _gameTimer;
		private LevelSystem _levelSystem;
		private WaitForSeconds _tick = new WaitForSeconds(1f);
		private Coroutine _timeRoutine;
		private int _seconds;
		private int _minutes;
		public int Minutes => _minutes;

		private void Start() => Activate();
		public void Activate() => _timeRoutine = StartCoroutine(Timer());

		public void Deactivate() => StopCoroutine(_timeRoutine);

		[Inject] private void Construct(LevelSystem levelSystem) => _levelSystem = levelSystem;

		private IEnumerator Timer()
		{
			while (true)
			{
				_seconds++;
				if (_seconds >= 60)
				{
					_minutes++;
					_seconds = 0;
					_levelSystem.OnLevelChanged?.Invoke();
				}
				TimeFormat();
				yield return _tick;
			}
		}

		private void TimeFormat()
		{
			_gameTimer.text = $"{_minutes}:{_seconds}";
			if (_seconds < 10 && _minutes < 10)
				_gameTimer.text = $"0{_minutes}:0{_seconds}";
			else if (_seconds < 10)
				_gameTimer.text = $"{_minutes}:0{_seconds}";
			else if (_minutes < 10)
				_gameTimer.text = $"0{_minutes}:{_seconds}";
		}
	}
}
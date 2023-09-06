using System;
using System.Collections;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class PlayerHealth : ObjectHealth
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private GameObject _endGameWindow;
		public Action OnHealthChanged;
		private WaitForSeconds _regenerationInterval = new WaitForSeconds(5f);
		private float _regeneration = 1f;
		private WaitForSeconds _interval = new WaitForSeconds(1f);
		private GamePause _gamePause;
		

		private void Start() => StartCoroutine(Regeneration());

		public void UpgradeHealth()
		{
			_maxHealth += 10;
			_currentHealth += 10;
			OnHealthChanged?.Invoke();
		}

		public void Heal()
		{
			_currentHealth += 30;
			if (_currentHealth >= _maxHealth)
				_currentHealth = _maxHealth;
			OnHealthChanged?.Invoke();
		}

		public void RegenerationUpgrade() => _regeneration += 3f;

		private IEnumerator Regeneration()
		{
			while (true)
			{
				_currentHealth += _regeneration;
				yield return _regenerationInterval;
			}
		}

		public override void TakeDamage(float damage)
		{
			base.TakeDamage(damage);
			if (_currentHealth <= 0) 
				StartCoroutine(PlayerDied());
		}

		private IEnumerator PlayerDied()
		{
			_gamePause.SetPause(true);
			_animator.SetTrigger("Die");
			yield return _interval;
			_endGameWindow.gameObject.SetActive(true);
		}

		[Inject] private void Construct(GamePause pause) => _gamePause = pause;
	}
}
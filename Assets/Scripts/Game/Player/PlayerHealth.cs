using System;
using System.Collections;
using Game.Core;
using UnityEngine;

namespace Game.Player
{
	public class PlayerHealth : ObjectHealth
	{
		public Action OnHealthChanged;
		private WaitForSeconds _regenerationInterval = new WaitForSeconds(5f);
		private float _regeneration = 1f;

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
	}
}
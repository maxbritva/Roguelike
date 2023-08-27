using System;
using UnityEngine;

namespace Game.Core
{
	public abstract class ObjectHealth : MonoBehaviour, IDamageable
	{
		
		[SerializeField] private float _maxHealth;
		[SerializeField] private float _currentHealth;
		public float MaxHealth => _maxHealth;
		public float CurrentHealth => _currentHealth;

		private void Start() => _currentHealth = _maxHealth;

		public void TakeDamage(float damage)
		{
			
			if (damage <= 0)
				throw new ArgumentOutOfRangeException(nameof(damage));
			_currentHealth -= damage;
			if (_currentHealth <= 0)
			{
				//death
			}
		}
	}
}
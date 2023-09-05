using System.Collections.Generic;
using Game.Enemy;
using Game.FX.DamageText;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Player.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		[SerializeField] private List<WeaponStats> _weaponStats = new List<WeaponStats>();
		[SerializeField] protected float _damage;
		private DiContainer _container;
		protected DamageTextSpawner _damageTextSpawner;
		private int _currentLevel = 1;
		private int _maxLevel = 8;
		public List<WeaponStats> WeaponStats => _weaponStats;
		public int CurrentLevel => _currentLevel;
		public float Damage => _damage;


		protected virtual void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out EnemyHealth health));
			{
				if(health == null) return;
				float damage = Random.Range(_damage / 2f, _damage * 1.5f);
				health.TakeDamage(damage);
				
			}
		}
		private void Awake() => _container.Inject(this);

		private void Start() => SetStats(0);

		[Inject] private void Construct(DamageTextSpawner damageTextSpawner, DiContainer container)
		{
			_damageTextSpawner = damageTextSpawner;
			_container = container;
		}
		protected virtual void SetStats(int value) => _damage = _weaponStats[value].Damage;

		public virtual void LevelUp()
		{
			if (_currentLevel < _maxLevel)
				_currentLevel++;
			SetStats(_currentLevel-1);
		}
	}
}
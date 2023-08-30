using System;
using Game.Enemy;
using Game.FX.DamageText;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Player.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		[SerializeField] private WeaponStats _weaponStats = new WeaponStats();
		[SerializeField] private float _damage;
		private DiContainer _container;
		private DamageTextSpawner _damageTextSpawner;
		public WeaponStats WeaponStats => _weaponStats;

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out EnemyHealth health));
			{
				if(health == null)
					return;
				float damage = Random.Range(_damage / 2f, _damage * 1.5f);
				health.TakeDamage(damage);
				health.gameObject.SetActive(false);
				_damageTextSpawner.Activate(transform,(int)damage);
			}
		}
		private void Awake() => _container.Inject(this);

		private void Start() => SetStats();

		[Inject] private void Construct(DamageTextSpawner damageTextSpawner, DiContainer container)
		{
			_damageTextSpawner = damageTextSpawner;
			_container = container;
		}

		protected virtual void SetStats() => _damage = _weaponStats.Damage;
	}
}
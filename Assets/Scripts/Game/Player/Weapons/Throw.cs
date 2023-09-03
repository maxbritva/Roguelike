using System.Collections;
using Game.Enemy;
using Game.FX.DamageText;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons
{
	public abstract class Throw : MonoBehaviour
	{
		private DamageTextSpawner _damageTextSpawner;
		protected WaitForSeconds Timer;
		protected float Damage;

		protected virtual void OnEnable() => StartCoroutine(TimerToHide());

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out EnemyHealth health));
			{
				if(health == null) return;
				float damage = Random.Range(Damage / 1.5f, Damage * 1.8f);
				health.TakeDamage(damage);
				_damageTextSpawner.Activate(transform,(int)damage);
			}
		}
		[Inject] private void Construct(DamageTextSpawner damageTextSpawner) => _damageTextSpawner = damageTextSpawner;

		private IEnumerator TimerToHide()
		{
			yield return Timer;
			gameObject.SetActive(false);
		}
	}
}
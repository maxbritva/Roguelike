using Game.Enemy;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.FrozenFire
{
	public class FrozenBall : Throw
	{
		private FrozenFire _frozenFire;
		private void Update() => transform.position += transform.up * (_frozenFire.Speed * Time.deltaTime);

		protected override void OnEnable()
		{
			base.OnEnable();
			Timer = new WaitForSeconds(_frozenFire.Duration);
			Damage = _frozenFire.Damage;
		}

		protected override void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out EnemyHealth health));
			{
				if(health == null) return;
				health.TakeDamage(Damage);
				_damageTextSpawner.Activate(transform,(int)Damage);
				health.GetComponent<EnemyMove>().Freeze();
			}
			if (_frozenFire.CurrentLevel <= 4) 
				gameObject.SetActive(false);
		}

		[Inject] private void Construct(FrozenFire fire) => _frozenFire = fire;
	}
}
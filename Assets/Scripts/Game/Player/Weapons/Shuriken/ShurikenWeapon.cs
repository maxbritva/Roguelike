using System.Collections;
using Game.Core.Pool;
using UnityEngine;

namespace Game.Player.Weapons.Shuriken
{
	public class ShurikenWeapon : BaseWeapon
	{
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private Transform _targetContainer;
		[SerializeField] private LayerMask _mask;
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _attackRoutine;
		private float _duration;
		private float _speed;
		private float _range; 
		private Vector3 _direction; 
		public float Duration => _duration;
		public float Speed => _speed;
		public Vector3 Direction => _direction;

		private void OnEnable() => Activate();
		
		private void Activate()
		{
			SetStats(0);
			_attackRoutine = StartCoroutine(StartThrow());
		}
		private void Deactivate() => StopCoroutine(_attackRoutine);
		
		protected override void SetStats(int value)
		{
			base.SetStats(CurrentLevel-1);
			_timeBetweenAttack = new WaitForSeconds(WeaponStats[CurrentLevel-1].TimeBetweenAttack);
			_speed = WeaponStats[CurrentLevel-1].Speed;
			_range = WeaponStats[CurrentLevel-1].Range;
			_duration = WeaponStats[CurrentLevel-1].Duration;
		}
		
		private IEnumerator StartThrow()
		{
			while (true)
			{
				Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, _range, _mask);
				if (enemiesInRange.Length > 0)
				{
					Vector3 targetPosition = enemiesInRange[Random.Range(0, enemiesInRange.Length)].transform.position;
					_direction = targetPosition - transform.position;
					float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
					angle -= 90f;
					GameObject throwFromPool = _objectPool.GetFromPool();
					throwFromPool.transform.SetParent(_targetContainer);
					throwFromPool.transform.position = transform.position;
					throwFromPool.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					yield return _timeBetweenAttack;
				}
				else
					yield return _timeBetweenAttack;
			}
		}
	}
}
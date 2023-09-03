using System.Collections;
using Game.Core.Pool;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.Bow
{
	public class Bow : BaseWeapon
	{
		[SerializeField] private Transform _targetContainer;
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private Animator _animator;
		private WaitForSeconds _animatorTick = new WaitForSeconds(0.5f);
		private PlayerController _playerController;
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _attackRoutine;
		private float _duration = 1f;
		private float _speed = 5f;
		private Vector3 _direction;
		public float Duration => _duration;
		public float Speed => _speed;
		public Vector3 Direction => _direction;

		private void Update() =>
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,
				(Mathf.Atan2(_playerController.Movement.y, _playerController.Movement.x) 
				 * Mathf.Rad2Deg) + 90f), 8f * Time.deltaTime);


		private void OnEnable() => Activate();

		[Inject] private void Construct(PlayerController playerController) => _playerController = playerController;

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
			_duration = WeaponStats[CurrentLevel-1].Duration;
		}
		
		private IEnumerator StartThrow()
		{
			while (true)
			{
				if (_playerController.Movement != Vector3.zero)
				{
					_animator.SetTrigger("Attack");
					yield return _animatorTick;
					GameObject throwFromPool = _objectPool.GetFromPool();
					throwFromPool.transform.SetParent(_targetContainer);
					_direction = _playerController.Movement.normalized;
					throwFromPool.transform.position = _shootPoint.position;
					throwFromPool.transform.rotation = transform.rotation;
					_animator.SetTrigger("Idle");
				}
				yield return _timeBetweenAttack;
				
			}
		}
	}
}
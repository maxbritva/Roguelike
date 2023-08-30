using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons
{
	public class SpinWeapon : BaseWeapon
	{
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private float _range;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private Collider2D _collider;
		[SerializeField] private Transform _targetWeapon;
		[Inject] private DiContainer _container;
		private WaitForSeconds _interval;
		private WaitForSeconds _duration;
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _coroutine;
		private bool _isActivePhase;

		private void Awake() => _container.Inject(this);
		private void Start()
		{
			Activate();
			SetStats();
			SetupRange();
		}

		private void Update() => transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
		private void Activate() => _coroutine = StartCoroutine(LifeCycle());
		private void Deactivate() => StopCoroutine(_coroutine);

		protected override void SetStats()
		{
			base.SetStats();
			_rotationSpeed = WeaponStats.Speed;
			_range = WeaponStats.Range;
			_duration = new WaitForSeconds(WeaponStats.Duration);
			_timeBetweenAttack = new WaitForSeconds(WeaponStats.TimeBetweenAttack);
		}

		private IEnumerator LifeCycle()
		{
			while (true)
			{
				_spriteRenderer.enabled = !_spriteRenderer.enabled;
				_collider.enabled = !_collider.enabled;
				_collider.isTrigger = !_collider.isTrigger;
				SetupPhase();
				yield return _interval;
			}
		}

		private void SetupRange()
		{
			_targetWeapon.transform.localPosition = new Vector3(WeaponStats.Range, 0, 0);
			_collider.offset = new Vector3(WeaponStats.Range, 0, 0);
		}

		private void SetupPhase()
		{
			_isActivePhase = _spriteRenderer.enabled;
			_interval = _isActivePhase ? _duration : _timeBetweenAttack;
		}
		
	}
}
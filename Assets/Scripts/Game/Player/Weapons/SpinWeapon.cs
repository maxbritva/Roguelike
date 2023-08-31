using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons
{
	public class SpinWeapon : BaseWeapon
	{
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private float _range;
		[Header("Single")]
		[SerializeField] private SpriteRenderer _spriteRenderer1X;
		[SerializeField] private Collider2D _collider;
		[SerializeField] private Transform _targetSprite1X;
		[SerializeField] private Transform _targetContainer1X;
		[Header("Double")]
		[SerializeField] private List<SpriteRenderer> _spriteRenderers2X;
		[SerializeField] private List<Collider2D> _colliders2X;
		[SerializeField] private List<Transform> _targetsSprite2X;
		[SerializeField] private Transform _targetContainer2X;
		
		[Inject] private DiContainer _container;
		private WaitForSeconds _interval;
		private WaitForSeconds _duration;
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _coroutine;
		private bool _isActivePhase;
		[SerializeField] private bool _isDoubleWeapon;

		private void Awake() => _container.Inject(this);
		private void Start()
		{
			Activate();
			SetStats(0);
			SetupRange();
		}

		private void Update() => transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
		private void Activate()
		{
			CheckForDoubleWeapon();
			_coroutine = StartCoroutine(LifeCycle());
		}

		private void CheckForDoubleWeapon()
		{
			if (_isDoubleWeapon == false)
			{
				_targetContainer1X.gameObject.SetActive(true);
				_targetContainer2X.gameObject.SetActive(false);
			}
			else
			{
				_targetContainer2X.gameObject.SetActive(true);
				_targetContainer1X.gameObject.SetActive(false);
				for (int i = 0; i < _colliders2X.Count; i++) 
					_colliders2X[i].gameObject.SetActive(true);
			}
		}

		private void Deactivate() => StopCoroutine(_coroutine);

		protected override void SetStats(int value)
		{
			base.SetStats(CurrentLevel-1);
			_rotationSpeed = WeaponStats[CurrentLevel-1].Speed;
			_range = WeaponStats[CurrentLevel-1].Range;
			_duration = new WaitForSeconds(WeaponStats[CurrentLevel-1].Duration);
			_timeBetweenAttack = new WaitForSeconds(WeaponStats[CurrentLevel-1].TimeBetweenAttack);
		}

		private IEnumerator LifeCycle()
		{
			while (true)
			{
				if (_isDoubleWeapon == false)
				{
					_spriteRenderer1X.enabled = !_spriteRenderer1X.enabled;
					_collider.enabled = !_collider.enabled;
					//_collider.isTrigger = !_collider.isTrigger;
				}
				else
				{
					for (int i = 0; i < _spriteRenderers2X.Count; i++)
						_spriteRenderers2X[i].enabled = !_spriteRenderers2X[i].enabled;
					for (int i = 0; i < _colliders2X.Count; i++)
						_colliders2X[i].enabled = !_colliders2X[i].enabled;
				}
				SetupPhase();
				yield return _interval;	
			}
		}

		private void SetupRange()
		{
			if (_isDoubleWeapon == false)
			{
				_targetSprite1X.transform.localPosition = new Vector3(_range, 0, 0);
				_collider.offset = new Vector3(_range, 0, 0);
			}
			else
			{
				_targetsSprite2X[0].transform.localPosition = new Vector3(_range, 0, 0);
				_targetsSprite2X[1].transform.localPosition = new Vector3(-_range, 0, 0);
				_colliders2X[0].offset = new Vector3(_range, 0, 0);
				_colliders2X[1].offset = new Vector3(-_range, 0, 0);
			}
			
		}

		private void SetupPhase()
		{
			_isActivePhase = _isDoubleWeapon == false ? _spriteRenderer1X.enabled : _spriteRenderers2X[0].enabled;
			_interval = _isActivePhase ? _duration : _timeBetweenAttack;
		}

		protected override void LevelUp()
		{
			base.LevelUp();
			if (CurrentLevel != 4) return;
			_isDoubleWeapon = true;
			CheckForDoubleWeapon();
		}
	}
}
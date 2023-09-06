using System.Collections;
using Game.Core;
using Game.Core.Interfaces;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public class EnemyMove : MonoBehaviour, IMovable
	{
		[SerializeField] private float _moveSpeed;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _freezeTimer;
		private PlayerController _playerController;
		private GamePause _gamePause;
		private Vector3 _movement;
		private float _moveSpeedInitial;
		private WaitForSeconds _timer;
		private void Update() => Move();
		private void Start()
		{
			_moveSpeedInitial = _moveSpeed;
			_timer = new WaitForSeconds(_freezeTimer);
		}

		[Inject] private void Construct(PlayerController playerController, GamePause pause)
		{
			_playerController = playerController;
			_gamePause = pause;
		}

		public void Move()
		{
			_moveSpeed = _gamePause.IsStopped ? 0f : _moveSpeedInitial;
			_movement = (_playerController.gameObject.transform.position -
			            transform.position).normalized;
			_animator.SetFloat("Horizontal", _movement.x);
			_animator.SetFloat("Vertical", _movement.y);
			transform.position += _movement * (_moveSpeed * Time.deltaTime);
			CheckDistanceToHide();
		}
		public void Freeze()
		{
			if(gameObject.activeSelf)
				StartCoroutine(StartFreeze());
		}
		public void StopEnemy(bool value) => _moveSpeed = value ? 0f : _moveSpeedInitial;

		private void CheckDistanceToHide()
		{
			float distance = Vector3.Distance(transform.position, _playerController.gameObject.transform.position);
			if(distance > 27f)
				gameObject.SetActive(false);
		}

		private IEnumerator StartFreeze()
		{
			_moveSpeed /= 2f;
			yield return _timer;
			_moveSpeed = _moveSpeedInitial;
		}
	}
}
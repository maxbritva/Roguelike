using System;
using Game.Core;
using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour, IMovable
	{
		[SerializeField] private Rigidbody2D _rigidbody2D;
		[SerializeField] private Animator _playerAnimator;
		[SerializeField] private float _moveSpeed;
		private Vector3 _movement;
		private int maxXPosition = 50;
		private GamePause _gamePause;
		public Vector3 Movement => _movement;

		private void Update() => Move();
		public void UpgradeSpeed() => _moveSpeed += 0.3f;

		public void Move()
		{
			_movement = _gamePause.IsStopped == false ? new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) : Vector3.zero;
			_playerAnimator.SetFloat("Horizontal", _movement.x);
			_playerAnimator.SetFloat("Vertical", _movement.y);
			_playerAnimator.SetFloat("Speed", _movement.sqrMagnitude);
			transform.position += _movement.normalized * (_moveSpeed * Time.deltaTime);
			if (transform.position.x > maxXPosition)
				transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
		}

		//private void FixedUpdate() => _rigidbody2D.AddForce(_movement * _moveSpeed /4,ForceMode2D.Impulse);

		[Inject] private void Construct(GamePause pause) => _gamePause = pause;
	}
}
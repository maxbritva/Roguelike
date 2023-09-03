using System;
using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour, IMovable
	{
		[SerializeField] private Rigidbody2D _playerRigidbody2D;
		[SerializeField] private Animator _playerAnimator;
		[SerializeField] private float _moveSpeed;
		private Vector3 _movement;
		public Vector3 Movement => _movement;

		private void Update() => Move();

		public void Move()
		{
			_movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			if (Input.GetKeyDown(KeyCode.Space))
				_playerRigidbody2D.AddForce(_movement * (4000f * Time.deltaTime), ForceMode2D.Impulse);
			_playerAnimator.SetFloat("Horizontal", _movement.x);
			_playerAnimator.SetFloat("Vertical", _movement.y);
			_playerAnimator.SetFloat("Speed", _movement.sqrMagnitude);
			transform.position += _movement.normalized * (_moveSpeed * Time.deltaTime);
		}
	}
}
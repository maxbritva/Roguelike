using Game.Core;
using UnityEngine;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour, IMovable
	{
		[SerializeField] private float _moveSpeed;
		[SerializeField] private Animator _playerAnimator;
		private Vector3 _movement;
		
		private void Update() => Move();

		public void Move()
		{
			_movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			_playerAnimator.SetFloat("Horizontal", _movement.x);
			_playerAnimator.SetFloat("Vertical", _movement.y);
			_playerAnimator.SetFloat("Speed", _movement.sqrMagnitude);
			transform.position += _movement.normalized * (_moveSpeed * Time.deltaTime);
		}
	}
}
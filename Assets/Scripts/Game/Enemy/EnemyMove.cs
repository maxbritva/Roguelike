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
		private PlayerController _playerController;
		private Vector3 _movement;
		private void Update() => Move();

		[Inject] private void Construct(PlayerController playerController) => _playerController = playerController;
		public void Move()
		{
			_movement = (_playerController.gameObject.transform.position -
			            transform.position).normalized;
			_animator.SetFloat("Horizontal", _movement.x);
			_animator.SetFloat("Vertical", _movement.y);
			transform.position += _movement * (_moveSpeed * Time.deltaTime);
			CheckDistanceToHide();
		}

		private void CheckDistanceToHide()
		{
			float distance = Vector3.Distance(transform.position, _playerController.gameObject.transform.position);
			if(distance > 27f)
				gameObject.SetActive(false);
		}
	}
}
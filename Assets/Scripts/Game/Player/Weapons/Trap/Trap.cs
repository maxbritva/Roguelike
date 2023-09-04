using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.Trap
{
	public class Trap : Throw
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private CircleCollider2D _circleCollider2D;
		private WaitForSeconds _checkInterval = new WaitForSeconds(5f);
		private WaitForSeconds _animationTime = new WaitForSeconds(0.5f);
		private PlayerHealth _playerHealth;
		private TrapPlacer _trapPlacer;
		protected override void OnEnable()
		{
			Timer = new WaitForSeconds(_trapPlacer.Duration - 0.5f);
			_circleCollider2D.isTrigger = false;
			StartCoroutine(PrepareTrap());
			StartCoroutine(CheckDistance());
		}

		protected override void OnTriggerEnter2D(Collider2D col)
		{
			base.OnTriggerEnter2D(col);
			// damage over time
		}
		private IEnumerator PrepareTrap()
		{
			yield return Timer;
			_animator.SetTrigger("Attack");
			yield return _animationTime;
			_circleCollider2D.isTrigger = true;
		}

		private IEnumerator CheckDistance()
		{
			while (true)
			{
				if(Vector3.Distance(transform.position, _playerHealth.transform.position) > 15f)
					gameObject.SetActive(false);
				yield return _checkInterval;
			}
		}

		[Inject] private void Construct(PlayerHealth playerHealth, TrapPlacer trapPlacer)
		{
			_playerHealth = playerHealth;
			_trapPlacer = trapPlacer;
		}
	}
}
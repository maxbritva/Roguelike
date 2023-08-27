using Game.Player;
using UnityEngine;

namespace Game.Enemy
{
	public class EnemyAttack : MonoBehaviour
	{
		[SerializeField] private float _damage;

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out PlayerHealth player));
			{
				player.TakeDamage(_damage);
				player.OnHealthChanged?.Invoke();
			}
			gameObject.SetActive(false);
		}

		
	}
}
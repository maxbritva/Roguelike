using Game.Player;
using UnityEngine;

namespace Game.Enemy
{
	public class EnemyCollision : MonoBehaviour
	{
		[SerializeField] private float _damage;
		[SerializeField] private EnemyHealth _enemyHealth;
		

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out PlayerHealth player));
			{
				if (player == null) return;
				player.TakeDamage(_damage);
				player.OnHealthChanged?.Invoke();
				gameObject.SetActive(false);
			}
		}
	}
}
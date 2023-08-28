using Game.Player;
using Game.Player.Weapons;
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
				if (player != null)
				{
					player.TakeDamage(_damage);
					player.OnHealthChanged?.Invoke();
					gameObject.SetActive(false);
				}
				
			}
			if (col.gameObject.TryGetComponent(out BaseWeapon weapon));
			{ 
				if(weapon != null)
					_enemyHealth.TakeDamage(weapon.Damage);
				gameObject.SetActive(false);
			}
		}

		
	}
}
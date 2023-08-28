using Game.Enemy;
using UnityEngine;

namespace Game.Player.Weapons
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		[SerializeField] private float _damage;
		public float Damage => _damage;
		
	}
}
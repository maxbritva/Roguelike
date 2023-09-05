using Game.Player;
using UnityEngine;

namespace Game.Core.Loot
{
	public abstract class Loot : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out PlayerController playerController) ) 
				Pickup();
		}
		protected virtual void Pickup() => gameObject.SetActive(false);
	}
}
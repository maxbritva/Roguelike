using UnityEngine;

namespace Game.Core.Loot
{
	public class Treasure : Loot
	{
		//private PlayerHealth _playerHealth;

		protected override void Pickup()
		{
			base.Pickup();
			
		}
		
	//	[Inject] private void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;
	}
}
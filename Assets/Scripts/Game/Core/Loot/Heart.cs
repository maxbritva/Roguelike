using Game.Player;
using Zenject;

namespace Game.Core.Loot
{
	public class Heart : Loot
	{
		private PlayerHealth _playerHealth;

		protected override void Pickup()
		{
			base.Pickup();
			_playerHealth.Heal();
		}
		
		[Inject] private void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;
	}
}
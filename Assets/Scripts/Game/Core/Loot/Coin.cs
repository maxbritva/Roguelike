using Game.UI;
using Zenject;

namespace Game.Core.Loot
{
	public class Coin : Loot
	{
		private CoinsUpdater _coinsUpdater;

		protected override void Pickup()
		{
			base.Pickup();
			_coinsUpdater.OnCountChanged?.Invoke();
		}
		
		[Inject] private void Construct(CoinsUpdater coinsUpdater) => _coinsUpdater = coinsUpdater;
	}
}
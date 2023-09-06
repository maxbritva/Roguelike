using Game.UI;
using Zenject;

namespace Game.Core.Loot
{
	public class Treasure : Loot
	{
		private TreasureWindow _treasureWindow;

		protected override void Pickup()
		{
			base.Pickup();
			_treasureWindow.gameObject.SetActive(true);
		}
		
		[Inject] private void Construct(TreasureWindow treasureWindow) => _treasureWindow = treasureWindow;
	}
}
using System;
using Game.Core;

namespace Game.Player
{
	public class PlayerHealth : ObjectHealth
	{
		public Action OnHealthChanged;
	}
}
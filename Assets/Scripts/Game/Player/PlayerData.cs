using System;
using UnityEngine;

namespace Game.Player
{
	public class PlayerData : MonoBehaviour
	{
		public int Coins { get; private set; }
		public int MaxHealthUpgradeIndex { get; private set; }
		public int SpeedUpgradeIndex { get; private set; }
		public int RegenUpgradeIndex { get; private set; }
		public int RangeExpUpgradeIndex { get; private set; }


		public void TrySpendCoins(int value)
		{
			if(value <=0 || value > Coins)
				throw new ArgumentOutOfRangeException(nameof(value));
			Coins -= value;
		}
		public void AddCoins() => Coins++;
		public void AddRewardCoins(int value)
		{
			if(value <=0)
				throw new ArgumentOutOfRangeException(nameof(value));
			Coins += value;
		}
		
		public void SetUpgradeIndex(int value, int id)
		{
			if (value < 0 || value > 5)
				throw new ArgumentOutOfRangeException("Upgrade must be in range from 1 to 5");
			if (id == 1)
				MaxHealthUpgradeIndex = value;
			else if (id == 2)
				SpeedUpgradeIndex = value;
			else if (id == 3)
				RegenUpgradeIndex = value;
			else if (id == 4) RangeExpUpgradeIndex = value;
		}
	}
}
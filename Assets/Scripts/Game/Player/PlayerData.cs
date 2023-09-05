using System;
using UnityEngine;

namespace Game.Player
{
	public class PlayerData : MonoBehaviour
	{
		public int Coins { get; private set; }

		public void AddCoins() => Coins++;
		public void AddRewardCoins(int value)
		{
			if(value <=0)
				throw new ArgumentOutOfRangeException(nameof(value));
			Coins += value;
		}
	}
}
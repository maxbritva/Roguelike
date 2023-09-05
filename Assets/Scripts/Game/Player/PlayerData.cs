using UnityEngine;

namespace Game.Player
{
	public class PlayerData : MonoBehaviour
	{
		public int Coins { get; private set; }

		public void AddCoins() => Coins++;
	}
}
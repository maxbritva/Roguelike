using UnityEngine;

namespace Game.Core
{
	public interface IAttack
	{
		void Attack(float value, GameObject target);
	}
}
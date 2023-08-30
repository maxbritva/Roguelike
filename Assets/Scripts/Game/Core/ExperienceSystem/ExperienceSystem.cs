using System;
using UnityEngine;

namespace Game.Core.ExperienceSystem
{
	public class ExperienceSystem : MonoBehaviour
	{
		public Action<int> OnExperiencePickedUp;
		private int _currentExperience;

		private void OnEnable() => OnExperiencePickedUp += ExperienceAddValue;

		private void OnDisable() => OnExperiencePickedUp -= ExperienceAddValue;


		private void ExperienceAddValue(int value)
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException(nameof(value));
			_currentExperience += value;
			Debug.Log(_currentExperience);
		}
	}
}
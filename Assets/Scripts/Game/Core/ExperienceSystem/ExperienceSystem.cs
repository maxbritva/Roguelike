using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.ExperienceSystem
{
	public class ExperienceSystem : MonoBehaviour
	{
		public Action<int> OnExperiencePickedUp;
		private int _currentExperience;
		private int _experienceToLevelUp = 5;
		private int _currentLevel = 1;

		public int CurrentExperience => _currentExperience;
		public int ExperienceToLevelUp => _experienceToLevelUp;
		public int CurrentLevel => _currentLevel;

		private void OnEnable() => OnExperiencePickedUp += ExperienceAddValue;

		private void OnDisable() => OnExperiencePickedUp -= ExperienceAddValue;


		private void ExperienceAddValue(int value)
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException(nameof(value));
			_currentExperience += value;
			if (_currentExperience >= _experienceToLevelUp) 
				LevelUp();
		}

		private void LevelUp()
		{
			_currentExperience = 0;
			_currentLevel++;
			switch (_currentLevel)
			{
				case <= 20:
					_experienceToLevelUp += 10;
					break;
				case <= 40 and > 20:
					_experienceToLevelUp += 13;
					break;
				case >= 60:
					_experienceToLevelUp += 16;
					break;
			}
		}
	}
}
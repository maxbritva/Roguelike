using System;
using Game.Core.ExperienceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
	public class PlayerExperienceUIUpdater : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _expText;
		[SerializeField] private Image _fillImage;
		private ExperienceSystem _experienceSystem;
		private void Start() => UpdateExperienceBar(_experienceSystem.CurrentLevel);

		private void OnEnable() => _experienceSystem.OnExperiencePickedUp += UpdateExperienceBar;
		private void OnDisable() => _experienceSystem.OnExperiencePickedUp -= UpdateExperienceBar;

		private void UpdateExperienceBar(int exp)
		{
			_fillImage.fillAmount = (float)_experienceSystem.CurrentExperience / _experienceSystem.ExperienceToLevelUp;
			_fillImage.fillAmount = Mathf.Clamp01(_fillImage.fillAmount);
			_expText.text = $"{_experienceSystem.CurrentLevel} LVL.";
		}
		[Inject] private void Construct(ExperienceSystem experienceSystem) => _experienceSystem = experienceSystem;
	}
}
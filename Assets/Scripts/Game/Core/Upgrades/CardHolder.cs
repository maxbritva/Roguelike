using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core.Upgrades
{
	public class CardHolder : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _descriptionText;
		[SerializeField] private TextMeshProUGUI _nameText;
		[SerializeField] private UpgradeCard _upgradeCard;
		[SerializeField] private Image _icon;
		private UpgradeWindow _upgradeWindow;
		private int _id;
		private void Start()
		{
			_nameText.text = _upgradeCard.Name;
			_icon.sprite = _upgradeCard.Icon;
			_descriptionText.text = _upgradeCard.Description;
			_id = _upgradeCard.ID;
		}

		public void Upgrade() => _upgradeWindow.Upgrade(_id);

		[Inject] private void Construct(UpgradeWindow upgradeWindow) => _upgradeWindow = upgradeWindow;
	}
}
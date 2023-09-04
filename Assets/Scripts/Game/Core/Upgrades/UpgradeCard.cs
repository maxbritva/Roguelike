using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCard", menuName = "ScriptableObject/UpgradeCard")]
    public class UpgradeCard : ScriptableObject
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _description;
        
    }
}
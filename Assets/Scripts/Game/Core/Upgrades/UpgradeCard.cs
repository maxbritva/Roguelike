using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCard", menuName = "ScriptableObject/UpgradeCard")]
    public class UpgradeCard : ScriptableObject
    {
        [Header("value")]
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _id;

        public string Name => _name;
        public string Description => _description;
        public int ID => _id;

        public Sprite Icon => _icon;
    }
}
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Core.Inventories
{
    [CreateAssetMenu(fileName = "WeaponInfo",
        menuName = "Weapons/New WeaponInfo")]
    public class WeaponInfo : ScriptableObject
    {
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private Sprite _sprite;

        public WeaponType WeaponType => _weaponType;
        public Sprite Sprite => _sprite;
    }
}
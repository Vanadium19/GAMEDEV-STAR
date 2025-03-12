using System;
using System.Collections.Generic;
using System.Linq;
using Game.Content.Weapons;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Core.Inventories
{
    [CreateAssetMenu(fileName = "WeaponCatalog",
        menuName = "Weapons/New WeaponCatalog")]
    public class WeaponCatalog : ScriptableObject
    {
        [SerializeField] private WeaponInfo[] _weaponInfos;

        private readonly Dictionary<Type, WeaponType> _weaponTypeMap = new()
        {
            { typeof(Pistol), WeaponType.Pistol },
            { typeof(Rifle), WeaponType.Rifle },
            { typeof(ShootGun), WeaponType.Shotgun },
        };

        public Sprite GetWeaponImage(IWeapon weapon)
        {
            Type type = weapon.GetType();

            if (!_weaponTypeMap.TryGetValue(type, out var weaponType))
                throw new ArgumentOutOfRangeException(nameof(type), type, "Weapon type not found");

            var info = FindWeaponInfo(weaponType);

            return info.Sprite;
        }

        private WeaponInfo FindWeaponInfo(WeaponType weaponType)
        {
            foreach (var weaponInfo in _weaponInfos)
            {
                if (weaponInfo.WeaponType == weaponType)
                {
                    return weaponInfo;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, "Weapon info not found");
        }
    }
}
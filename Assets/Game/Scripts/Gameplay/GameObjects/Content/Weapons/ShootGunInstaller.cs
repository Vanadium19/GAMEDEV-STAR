using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGunInstaller : MonoInstaller
    {
        [SerializeField] private Transform _shootPoint;

        [SerializeField] private float _speed;
        [SerializeField] private float _delay;
        [SerializeField] private int _maxAmmoCount;
        [SerializeField] private int _damage;
        [SerializeField] private TeamType _team;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShootGun>()
                .AsSingle()
                .WithArguments(_shootPoint, _team, _speed, _delay, _maxAmmoCount, _damage);
        }
    }
}

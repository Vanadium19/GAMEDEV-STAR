using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Transform _shootPoint;

        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private int _damage = 2;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Gun>()
                .AsSingle()
                .WithArguments(_shootPoint, _speed, _delay, _damage);
        }
    }
}
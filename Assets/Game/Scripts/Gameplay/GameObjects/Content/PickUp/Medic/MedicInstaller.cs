using Zenject;
using UnityEngine;
using Game.Content.PickUp;

namespace Game.Gameplay.Content.PickUp
{
    public class MedicInstaller : MonoInstaller
    {
        [SerializeField] private int _heal;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Medic>()
                .AsSingle()
                .WithArguments(_heal);
        }
    }
}

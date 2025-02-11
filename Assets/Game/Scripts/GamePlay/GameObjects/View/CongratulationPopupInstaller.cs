using UnityEngine;
using Zenject;

namespace Game.View
{
    public class CongratulationPopupInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _congratulationPopup;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<СongratulationPopup>()
                .AsSingle()
                .WithArguments(_congratulationPopup)
                .NonLazy();
        }
    }
}
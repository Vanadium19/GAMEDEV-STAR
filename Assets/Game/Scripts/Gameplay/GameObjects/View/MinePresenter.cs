using Game.Core.Components;
using System;
using Zenject;

namespace Game.View
{
    public class MinePresenter : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly MineView _mineView;

        public MinePresenter(IAttacker attacker, MineView mineView)
        {
            _attacker = attacker;
            _mineView = mineView;
        }

        public void Initialize()
        {
            _attacker.Attacked += OnAttacked;
        }

        public void Dispose()
        {
            _attacker.Attacked -= OnAttacked;
        }

        private void OnAttacked()
        {
            _mineView.OnMineExploded();
        }
    }
}
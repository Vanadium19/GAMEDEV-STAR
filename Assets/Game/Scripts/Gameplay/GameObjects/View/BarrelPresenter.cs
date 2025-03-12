using Game.Core.Components;
using System;
using Zenject;

namespace Game.View
{
    public class BarrelPresenter : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly BarrelView _barrelView;

        public BarrelPresenter(IAttacker attacker, BarrelView barrelView)
        {
            _attacker = attacker;
            _barrelView = barrelView;
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
            _barrelView.OnBarrelExploded();
        }
    }
}
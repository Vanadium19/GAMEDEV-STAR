using System;
using Cysharp.Threading.Tasks;
using Game.Core.Components;
using Game.Modules.Entities;
using Zenject;

namespace Game.Content.Traps
{
    public class Mine : IInitializable, IDisposable
    {
        private const float _destroyDelay = 1.0f;
        
        private readonly IEntity _entity;
        private readonly IAttacker _attacker;

        public Mine(IAttacker attacker, IEntity entity)
        {
            _entity = entity;
            _attacker = attacker;
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
            DestroyEntityAsync().Forget();
        }

        private async UniTaskVoid DestroyEntityAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_destroyDelay));
            _entity.Destroy();
        }
    }
}
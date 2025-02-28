using System;
using Cysharp.Threading.Tasks;

namespace Game.Core.Components
{
    public class DelayAttackDecorator : IAttacker
    {
        private readonly IAttacker _attacker;
        private readonly float _delay;

        private bool _isRunning;

        public DelayAttackDecorator(IAttacker attacker, float delay)
        {
            _attacker = attacker;
            _delay = delay;
        }

        public void Attack()
        {
            if (_isRunning)
                return;

            AttackAsync().Forget();
        }

        private async UniTaskVoid AttackAsync()
        {
            _isRunning = true;

            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            _attacker.Attack();
            _isRunning = false;
        }
    }
}
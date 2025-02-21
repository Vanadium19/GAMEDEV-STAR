using System;

namespace Game.Modules.FSM
{
    public sealed class StateTransition<TKey>
    {
        public readonly TKey From;
        public readonly TKey To;

        private readonly Func<bool> _condition;

        public StateTransition(TKey from, TKey to, Func<bool> condition)
        {
            From = from;
            To = to;

            _condition = condition;
        }

        public bool CanPerform()
        {
            return _condition == null || _condition.Invoke();
        }
    }
}
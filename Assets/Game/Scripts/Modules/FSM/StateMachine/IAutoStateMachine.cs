using System;
using System.Collections.Generic;

namespace Game.Modules.FSM
{
    public interface IAutoStateMachine<TKey> : IStateMachine<TKey>
    {
        public event Action<StateTransition<TKey>> OnTransitionAdded;
        public event Action<StateTransition<TKey>> OnTransitionRemoved;

        public int TransitionCount { get; }
        public IEnumerable<(TKey, TKey)> Transitions { get; }

        public bool AddTransition(StateTransition<TKey> transition);
        public bool AddTransition(TKey from, TKey to, Func<bool> condition);

        public bool RemoveTransition(StateTransition<TKey> transition);
        public bool RemoveTransition(TKey from, TKey to);

        public bool ContainsTransition(StateTransition<TKey> transition);
        public bool ContainsTransition(TKey from, TKey to);
    }
}
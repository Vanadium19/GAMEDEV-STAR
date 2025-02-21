namespace Game.Modules.FSM
{
    public interface IStateTransition<TKey>
    {
        public TKey From { get; }
        public TKey To { get; }

        public bool CanPerform();
    }
}
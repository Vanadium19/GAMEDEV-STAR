namespace Game.Core.Components
{
    public interface IPickUpList
    {
        public bool Add(ICollectable item);
        public bool Remove(ICollectable item);
        public void Collect();
    }
}
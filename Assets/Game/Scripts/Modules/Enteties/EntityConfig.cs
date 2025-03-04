using UnityEngine;

namespace Game.Modules.Entities
{
    [CreateAssetMenu(
        fileName = "EntityConfig",
        menuName = "Modules/Entities/New Entity Config"
    )]
    public sealed class EntityConfig : ScriptableObject
    {
        [field: SerializeField] public Entity Prefab { get; private set; }

        [field: SerializeField] public string Name { get; private set; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Name = Prefab ? Prefab.name : string.Empty;
        }
#endif
    }
}
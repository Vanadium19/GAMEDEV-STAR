using UnityEngine;

namespace Game.Modules.Entities
{
    [CreateAssetMenu(
        fileName = "EntityCatalog",
        menuName = "Modules/Entities/New Entity Catalog"
    )]
    public sealed class EntityCatalog : ScriptableObject
    {
        [SerializeField] private EntityConfig[] _configs;

        public bool FindConfig(string entityName, out EntityConfig config)
        {
            for (int i = 0, count = _configs.Length; i < count; i++)
            {
                config = _configs[i];
                
                if (config.Name == entityName)
                    return true;
            }

            config = default;
            return false;
        }
    }
}
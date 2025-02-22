using Game.Core;
using Game.Core.Components;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SlowZone : MonoBehaviour
{
    [SerializeField] private float _multipler;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IEntity entity) && entity.TryGet(out IMovable movable))
        {
            movable.SetSpeedMultipler(_multipler);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IEntity entity) && entity.TryGet(out IMovable movable))
        {
            movable.NormalizeSpeedMultipler();
        }
    }
}

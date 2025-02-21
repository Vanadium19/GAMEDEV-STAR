using Game.Content.Player;
using Game.Core;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Sensors
{
    public class TargetEnteredSensor : MonoBehaviour
    {
        private Blackboard _blackboard;

        [Inject]
        public void Construct(Blackboard blackboard)
        {
            _blackboard = blackboard;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out Character character))
                _blackboard.SetObject((int)BlackboardTag.Target, other.transform);
        }
    }
}
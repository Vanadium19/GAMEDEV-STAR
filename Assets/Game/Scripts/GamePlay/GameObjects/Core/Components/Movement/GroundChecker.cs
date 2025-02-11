using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class GroundChecker : ITickable
    {
        private const float OverlapAngle = 0;

        private readonly Transform _jumpPoint;
        private readonly Vector2 _overlapSize;
        private readonly int _layerMask;

        private bool _isGrounded;

        public GroundChecker(GroundCheckParams checkParams)
        {
            _jumpPoint = checkParams.Point;
            _overlapSize = checkParams.OverlapSize;
            _layerMask = checkParams.GroundLayer;
        }

        public bool IsGrounded => _isGrounded;

        public void Tick()
        {
            _isGrounded = Physics2D.OverlapBox(_jumpPoint.position, _overlapSize, OverlapAngle, _layerMask);
        }
    }
}
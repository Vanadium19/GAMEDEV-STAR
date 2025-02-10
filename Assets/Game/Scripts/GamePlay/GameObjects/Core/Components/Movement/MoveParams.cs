using System;
using UniRx;
using UnityEngine;

namespace Game.Core.Components
{
    [Serializable]
    public struct MoveParams
    {
        [SerializeField] private FloatReactiveProperty _speed;
        [SerializeField] private FloatReactiveProperty _gravityScale;
        [SerializeField] private FloatReactiveProperty _fallFactor;

        public IReadOnlyReactiveProperty<float> Speed => _speed;
        public IReadOnlyReactiveProperty<float> GravityScale => _gravityScale;
        public IReadOnlyReactiveProperty<float> FallFactor => _fallFactor;
    }
}
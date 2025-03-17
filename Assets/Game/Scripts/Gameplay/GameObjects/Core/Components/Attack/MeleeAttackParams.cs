using System;
using UnityEngine;

namespace Game.Core.Components
{
    [Serializable]
    public struct MeleeAttackParams
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _radius;
        [SerializeField] private float _delay;
        [SerializeField] private int _damage;

        public Transform Point => _point;
        public float Radius => _radius;
        public float Delay => _delay;
        public int Damage => _damage;
    }
}
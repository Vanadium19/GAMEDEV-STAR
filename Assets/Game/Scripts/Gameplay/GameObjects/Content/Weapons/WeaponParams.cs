using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Weapons
{
    [Serializable]
    public struct WeaponParams
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private TeamType _team;
        [SerializeField] private float _speed;
        [SerializeField] private float _delay;
        [SerializeField] private int _damage;

        public Transform Handle => _transform;
        public Transform ShootPoint => _shootPoint;
        public TeamType Team => _team;
        public float Speed => _speed;
        public float Delay => _delay;
        public int Damage => _damage;
    }
}
using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Enemies
{
    public class Saw : MonoBehaviour, IMovable
    {
        private TransformMover _mover;
        private Attacker _attacker;

        private Transform _transform;
        private UnityEventReceiver _unityEvents;

        public Vector2 Position => _transform.position;

        [Inject]
        public void Construct(TransformMover mover,
            UnityEventReceiver unityEvents,
            Attacker attacker)
        {
            _mover = mover;
            _unityEvents = unityEvents;
            _attacker = attacker;
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            _unityEvents.OnTriggerEntered += Attack;
        }

        private void OnDisable()
        {
            _unityEvents.OnTriggerEntered -= Attack;
        }

        public void Move(Vector2 direction)
        {
            _mover.Move(direction);
        }

        private void Attack(Collider2D target)
        {
            _attacker.Attack(target);
        }
    }
}
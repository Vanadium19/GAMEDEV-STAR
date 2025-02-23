using Game.Core.Components;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    [RequireComponent(typeof(BoxCollider))]
    public class MineCollisionController : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        [SerializeField] private float _delay;
        private IAttacker _attacker;


        private bool _isActivated;
        private float _currentTime;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void Update()
        {
            if (_isActivated)
            {
                _currentTime -= Time.deltaTime;
                Debug.Log(TimeSpan.FromSeconds(Mathf.RoundToInt(_currentTime)));
                if(_currentTime <= 0)
                {
                    _attacker.Attack();
                    _isActivated = false;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_tags.Contains(other.tag))
            {
                _isActivated = true;
                _currentTime = _delay;
                Debug.Log("активация мины");
            }
        }

    }
}

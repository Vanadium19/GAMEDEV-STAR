using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.View
{
    public class LoopRotater : MonoBehaviour
    {
        private const int LoopCount = -1;

        [SerializeField] private float _angle = 180f;
        [SerializeField] private float _duration;

        private void Start()
        {
            var rotation = new Vector3(0f, 0f, _angle);

            transform.DORotate(rotation, _duration, RotateMode.FastBeyond360).SetLoops(LoopCount, LoopType.Restart).SetEase(Ease.Linear);
        }
    }
}
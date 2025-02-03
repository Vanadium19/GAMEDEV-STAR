using UnityEngine;

namespace Game.Scripts.Common
{
    public static class AnimatorParams
    {
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
        public static readonly int IsFalling = Animator.StringToHash("IsFalling");
        public static readonly int Jump = Animator.StringToHash("Jump");
        public static readonly int Die = Animator.StringToHash("Die");
    }
}
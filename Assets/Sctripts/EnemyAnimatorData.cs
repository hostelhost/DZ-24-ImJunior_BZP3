using UnityEngine;

public class EnemyAnimatorData
{
    public readonly int Idle = Animator.StringToHash(nameof(Idle));
    public readonly int UpWalk = Animator.StringToHash(nameof(UpWalk));
    public readonly int RightWalk = Animator.StringToHash(nameof(RightWalk));
    public readonly int LeftWalk = Animator.StringToHash(nameof(LeftWalk));
    public readonly int DownWalk = Animator.StringToHash(nameof(DownWalk));
}

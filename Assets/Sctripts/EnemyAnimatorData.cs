using UnityEngine;

public class EnemyAnimatorData
{
    //private const string Idle = "Idle";
    //private const string UpWalk = "UpWalk";
    //private const string RightWalk = "RightWalk";
    //private const string LeftWalk = "LeftWalk";
    //private const string DownWalk = "DownWalk";

    //public readonly int IdleHash = Animator.StringToHash(Idle);
    //public readonly int UpWalkHash = Animator.StringToHash(UpWalk);
    //public readonly int RightWalkHash = Animator.StringToHash(RightWalk);
    //public readonly int LeftWalkHash = Animator.StringToHash(LeftWalk);
    //public readonly int DownWalkHash = Animator.StringToHash(DownWalk);

    public readonly int Idle = Animator.StringToHash(nameof(Idle));
    public readonly int UpWalk = Animator.StringToHash(nameof(UpWalk));
    public readonly int RightWalk = Animator.StringToHash(nameof(RightWalk));
    public readonly int LeftWalk = Animator.StringToHash(nameof(LeftWalk));
    public readonly int DownWalk = Animator.StringToHash(nameof(DownWalk));
}

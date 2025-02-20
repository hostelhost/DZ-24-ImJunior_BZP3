using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyMover _enemyMover;

    private EnemyAnimatorData _animatorData = new EnemyAnimatorData();
    private Dictionary<Vector2, int> _animations = new Dictionary<Vector2, int>();

    private void Start()
    {
        _animations.Add(Vector2.right, _animatorData.RightWalk);
        _animations.Add(Vector2.left, _animatorData.LeftWalk);
        _animations.Add(Vector2.up, _animatorData.UpWalk);
        _animations.Add(Vector2.down, _animatorData.DownWalk);
    }

    private void Update()
    {
        ManageAnimator(DirectionCorrector(_enemyMover.Direction));
    }

    private void ManageAnimator(Vector2 direction)
    {
        if (_animations.TryGetValue(direction, out int value))
            _animator.Play(value);
    }

    private Vector2 DirectionCorrector(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            return direction.x > 0 ? Vector2.right : Vector2.left;
        else
            return direction.y > 0 ? Vector2.up : Vector2.down;
    }
}

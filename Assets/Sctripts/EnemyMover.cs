using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Point[] _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private EnemyDetector _detector;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _targetReachMaxDistanse = 0.1f;

    private EnemyAnimatorData _animatorData = new EnemyAnimatorData();
    private Vector3 _pathTarget;
    private int _currentIndexOfTarget;

    private void Start()
    {
        _currentIndexOfTarget = _path.Length - 1;
        _pathTarget = TakeNextTarget();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 nextPosition;

        if (_detector.GetGlobalTarget() == null)        
            nextPosition = FollowPath();                  
        else
            nextPosition = FollowGlobalTarget();    

        ManageAnimator(nextPosition);
    }

    private Vector2 TakeNextTarget()
    {
        _currentIndexOfTarget = ++_currentIndexOfTarget % _path.Length;
        return _path[_currentIndexOfTarget].transform.position;
    }

    private Vector3 FollowGlobalTarget()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _detector.GetGlobalTarget().transform.position, _speed * Time.deltaTime);
        Vector2 direction = (nextPosition - transform.position).normalized;
        transform.position = nextPosition;
        return direction;
    }

    private Vector2 FollowPath()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _pathTarget, _speed * Time.deltaTime);
        Vector2 direction = (nextPosition - transform.position).normalized;
        transform.position = nextPosition;

        if (Vector2.SqrMagnitude(transform.position - _pathTarget) <= _targetReachMaxDistanse * _targetReachMaxDistanse)
            _pathTarget = TakeNextTarget();

        return direction;
    }

    private void ManageAnimator(Vector2 direction)
    {
        Dictionary<Vector2, int> animations = new Dictionary<Vector2, int>();

        animations.Add(Vector2.zero, _animatorData.Idle);
        animations.Add(Vector2.right, _animatorData.RightWalk);
        animations.Add(Vector2.left, _animatorData.LeftWalk);
        animations.Add(Vector2.up, _animatorData.UpWalk);
        animations.Add(Vector2.down, _animatorData.DownWalk);


       
    }
}


using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Point[] _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private EnemyDetector _detector;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _targetReachMaxDistanse = 0.1f;

    private EnemyAnimatorData _animatorData = new EnemyAnimatorData();
    private Dictionary<Vector2, int> _animations = new Dictionary<Vector2, int>();
    private Vector3 _pathTarget;
    private int _currentIndexOfTarget;

    private void Start()
    {
        _animations.Add(Vector2.zero, _animatorData.Idle);
        _animations.Add(Vector2.right, _animatorData.RightWalk);
        _animations.Add(Vector2.left, _animatorData.LeftWalk);
        _animations.Add(Vector2.up, _animatorData.UpWalk);
        _animations.Add(Vector2.down, _animatorData.DownWalk);

        _currentIndexOfTarget = _path.Length - 1;
        _pathTarget = TakeNextTarget();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction;

        if (_detector.GetGlobalTarget() == null)
            direction = FollowPath();
        else
            direction = FollowGlobalTarget();

        ManageAnimator(CorrectorDirection(direction));
    }

    private Vector2 TakeNextTarget()
    {
        _currentIndexOfTarget = ++_currentIndexOfTarget % _path.Length;
        return _path[_currentIndexOfTarget].transform.position;
    }

    private Vector2 FollowGlobalTarget()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _detector.GetGlobalTarget().transform.position, _speed * Time.deltaTime);
        Vector2 direction = (nextPosition - transform.position);
        transform.position = nextPosition;
        return direction;
    }

    private Vector2 FollowPath()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _pathTarget, _speed * Time.deltaTime);
        Vector2 direction = (nextPosition - transform.position);
        transform.position = nextPosition;

        if (Vector2.SqrMagnitude(transform.position - _pathTarget) <= _targetReachMaxDistanse * _targetReachMaxDistanse)
            _pathTarget = TakeNextTarget();

        return direction;
    }

    private void ManageAnimator(Vector2 direction)
    {
        if (_animations.TryGetValue(direction, out int value))
            _animator.Play(value);
    }

    private Vector2 CorrectorDirection(Vector2 direction)
    {
        float coordinateX = direction.x;
        float coordinateY = direction.y;
        Math.Round(coordinateX);
        Math.Round(coordinateY);

        direction = new Vector2(coordinateX, coordinateY); 

        // ��������� ������� ��� �� ���! ��������� � ����� ������� ��������������! !!! !
        return direction;
    }
}


using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Point[] _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private EnemyDetector _detector;
    [SerializeField] private float _targetReachMaxDistanse = 0.1f;

    private Vector3 _pathTarget;
    private int _currentIndexOfTarget;

    public Vector2 Direction { get; private set; }

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
        if (_detector.GetGlobalTarget() == null)
            Direction = FollowPath();
        else
            Direction = FollowGlobalTarget();
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
}


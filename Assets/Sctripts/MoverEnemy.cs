using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private Point[] _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private EnemyDetector _detector;

    private Vector3 _pathTarget;
    private int _currentIndexOfTarget;

    private void Start()
    {
        _currentIndexOfTarget = _path.Length - 1;
        _pathTarget = TakeNextTarget();
    }

    private void Update()
    {
        if (_detector.GetGlobalTarget() == null)
            FollowPath();
        else
            FollowGlobalTarget();
    }

    private void FollowGlobalTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _detector.GetGlobalTarget().transform.position, _speed * Time.deltaTime);
    }

    private void FollowPath()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pathTarget, _speed * Time.deltaTime);

        if (Vector2.SqrMagnitude(transform.position - _pathTarget) == 0*0)
            _pathTarget = TakeNextTarget();
    }

    private Vector3 TakeNextTarget()
    {
        _currentIndexOfTarget = ++_currentIndexOfTarget % _path.Length;
        return _path[_currentIndexOfTarget].transform.position;
    }
}

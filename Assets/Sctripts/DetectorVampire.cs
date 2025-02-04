using System.Collections.Generic;
using UnityEngine;

public class DetectorVampire : MonoBehaviour
{
    [SerializeField] Vampirism _vampirism;

    private List<Enemy> _enemys = new List<Enemy>();
    private Enemy _enemy;

    private void OnEnable()
    {
        _vampirism.StartedWork += FindEveryoneAround;
    }

    private void OnDisable()
    {
        _vampirism.StartedWork -= FindEveryoneAround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_vampirism.IsWorking)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
                _enemys.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_vampirism.IsWorking)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
                _enemys.Remove(enemy);
        }
    }

    public ITakingDamage IdentifyNearestTarget()
    {
        _enemy = null;

        if (_enemys.Count != 0)
        {
            _enemy = _enemys[0];

            for (int i = 1; i < _enemys.Count; i++)
            {
                if (Vector2.SqrMagnitude(_enemy.transform.position - transform.position) > Vector2.SqrMagnitude(_enemys[i].transform.position))
                    _enemy = _enemys[i];
            }
        }

        return _enemy;
    }

    private void FindEveryoneAround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x / 2);
        _enemys = new List<Enemy>();

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                _enemys.Add(enemy);
        }
    }
}

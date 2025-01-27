using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _detectorZone;

    private List<Enemy> _enemys = new List<Enemy>();

    private void Start()
    {
        _detectorZone.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemys.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemys.Remove(enemy);
    }

    public ITakingDamage IdentifyNearestTarget()
    {
        Enemy enemy = _enemys[0]; //Проверить если список пуст. вовзвращается ли кладется ли в enemy null.

        for (int i = 1; i < _enemys.Count; i++)
        {

            if (Vector3.Distance(enemy.transform.position, transform.position) > Vector3.Distance(_enemys[i].transform.position, transform.position))
                enemy = _enemys[i];
        }

        return enemy;
    }
}

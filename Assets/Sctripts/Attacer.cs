using System.Collections;
using UnityEngine;

public class Attacer : MonoBehaviour
{
    [SerializeField] private int _attack = 10;
    [SerializeField] private float _timeInterval = 1f;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakingDamage component))
            _coroutine = StartCoroutine(AttackEveryTimeInterval(component));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakingDamage component))
            StopCoroutine(_coroutine);
    }

    private IEnumerator AttackEveryTimeInterval(ITakingDamage attacked)
    {
        while (attacked != null)
        {
            attacked.TakeDamage(_attack);
            yield return _waitForSeconds;
        }
    }  
}

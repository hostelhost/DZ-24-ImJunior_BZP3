using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour 
{
    [SerializeField] private int _attack = 10;
    [SerializeField] private float _timeInterval = 1f;
    private Dictionary<IDamageable, Coroutine> _activeCoroutines = new Dictionary<IDamageable, Coroutine>();

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable iTakingDamage))
        {
            if (!_activeCoroutines.ContainsKey(iTakingDamage))
            {
                Coroutine coroutine = StartCoroutine(AttackEveryTimeInterval(iTakingDamage));
                _activeCoroutines.Add(iTakingDamage, coroutine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable iTakingDamage))
        {
            if (_activeCoroutines.TryGetValue(iTakingDamage, out var coroutine))
            {
                StopCoroutine(coroutine);
                _activeCoroutines.Remove(iTakingDamage);
            }
        }
    }

    private IEnumerator AttackEveryTimeInterval(IDamageable attacked)
    {
        while (attacked != null)
        {
            attacked.TakeDamage(_attack);

            yield return _waitForSeconds;
        }
    }  
}

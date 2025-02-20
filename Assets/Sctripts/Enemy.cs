using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] Health _health;

    public void TakeDamage(int damage)
    {
        if (_health.TryShortenHealth(damage))
        {
            if (IsAlive() == false || _health == null)
                DeleteObject();
        }
    }

    private bool IsAlive() =>
       _health.LifeForce > 0;

    private void DeleteObject() =>
        Destroy(gameObject);
}

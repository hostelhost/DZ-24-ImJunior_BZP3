using UnityEngine;

public class Enemy : MonoBehaviour, ITakingDamage
{
    [SerializeField] Health _health;

    public void TakeDamage(int damage)
    {
        if (_health.TryShortenHealth(damage))
        {
            if (IsAlive() || _health == null)
                DeleteObject();
        }
    }

    private bool IsAlive() =>
         0 >= _health.LifeForce;

    private void DeleteObject() =>
        Destroy(gameObject);
}

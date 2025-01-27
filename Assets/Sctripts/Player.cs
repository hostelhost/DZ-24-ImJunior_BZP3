using UnityEngine;

public class Player : MonoBehaviour, ITakingDamage
{
    [SerializeField] private Health _health;
    [SerializeField] private Bag _bag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            if (collectable is Gold gold)
                TakeCoin(gold.Execute());
            else if (collectable is AidKit aidKit)
                TryToAcceptLifeForce(aidKit.Execute());
        }
    }

    public void TryToAcceptLifeForce(int lifeForce) =>  
        _health.TryToAcceptLifeForce(lifeForce);

    public void TakeDamage(int damage)
    {
        if (_health.TryShortenHealth(damage))
        {
            if (IsAlive())
                DeleteObject();
        }
    }

    private void TakeCoin(int coin) =>   
        _bag.TakeCoin(coin);
    
    private bool IsAlive() =>
         0 >= _health.LifeForce;

    private void DeleteObject() =>    
        Destroy(gameObject);
}

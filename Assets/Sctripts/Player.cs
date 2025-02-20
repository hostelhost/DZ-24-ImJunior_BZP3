using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Bag _bag;
    //[SerializeField] private Animator _animator;
    //[SerializeField] private InputReader _inputReader;

    //private PlayerAnimatorData _animatorData = new PlayerAnimatorData();

    //private void Update()
    //{
    //    ManageAnimator();
    //}

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
            if (IsAlive() == false || _health == null)
                DeleteObject();
        }
    }

    //private void ManageAnimator()
    //{
    //    _animator.SetFloat(_animatorData.HorizonalAxisID, _inputReader.InputHorizontal);
    //    _animator.SetFloat(_animatorData.VerticalAxisID, _inputReader.InputVertical);
    //}

    private void TakeCoin(int coin) =>   
        _bag.TakeCoin(coin);

    private bool IsAlive() =>
       _health.LifeForce >= 0;

    private void DeleteObject() =>    
        Destroy(gameObject);
}

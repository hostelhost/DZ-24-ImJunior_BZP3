using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDetector : MonoBehaviour
{
    private Player _globalTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player prosecuted)) 
            _globalTarget = prosecuted;                    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player prosecuted))
            _globalTarget = null;        
    }

    public Player GetGlobalTarget()
    {
        return _globalTarget;
    }
}

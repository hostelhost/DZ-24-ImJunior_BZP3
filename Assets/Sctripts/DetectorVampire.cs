using UnityEngine;

public class DetectorVampire : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Collider2D[] _colliders;

    public bool TryIdentifyNearestTarget(out Enemy enemy)
    {
        enemy = null;
        _colliders = new Collider2D[1];
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, GetRadius(), _colliders, _layerMask);

        if (count == 0)
            return false;

        if (_colliders[0].TryGetComponent(out enemy))        
            return enemy;

        return false;
    }

    private float GetRadius()
    {
        int diameterDivider = 2;            
        return transform.localScale.x / diameterDivider;   
    }
}

using UnityEngine;

public class AidKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int _lifeForce = 25;

    public int Execute()
    {
        Destroy(gameObject);

        return _lifeForce;
    }
}

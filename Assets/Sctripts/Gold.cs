using UnityEngine;

public class Gold : MonoBehaviour, ICollectable
{
    [SerializeField] private int _quantity = 1;

    public int Execute()
    {
        Destroy(gameObject);

        return _quantity;
    }
}

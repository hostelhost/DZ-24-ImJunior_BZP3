using UnityEngine;

public class FollowTheAim : MonoBehaviour
{
    [SerializeField] private Transform _aim;

    private void Update()
    {
        if (_aim == null)
            Destroy(gameObject);
        else if (transform.position != _aim.position)
            NextPosition();
    }

    private void NextPosition()
    {
        transform.position = _aim.position;
    }
}
using UnityEngine;

public class FollowTheAim : MonoBehaviour
{
    [SerializeField] private Transform _aim;

    private void Update()
    {
        if (transform.position != _aim.position)       
            NextPosition();

        if (_aim == null)       
            Destroy(gameObject);      
    }

    private void NextPosition()
    {
        transform.position = _aim.position;
    }
}
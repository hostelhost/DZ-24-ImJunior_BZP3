using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3 _oldPosition;

    public float GetAxis(Axis axis)
    {
        Vector3 delta = transform.position - _oldPosition;

        if (axis == Axis.Horizontal)
        {
            return Vector3.Normalize(new Vector3(delta.x, 0, 0)).x;
        }
        else if (axis == Axis.Vertical)
        {
            return Vector3.Normalize(new Vector3(0, delta.y, 0)).y;
        }
        else return 0;
    }
}

public enum Axis
{
    Vertical,
    Horizontal
}
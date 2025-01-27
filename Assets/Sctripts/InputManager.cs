using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public float InputHorizontal { get; private set; }
    public float InputVertical { get; private set; }

    private void Update()
    {
        InputHorizontal = Input.GetAxisRaw(Horizontal);
        InputVertical = Input.GetAxisRaw(Vertical);
    }
}

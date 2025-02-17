using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed = 5.0f;

    private void Update()
    {
        transform.Translate(_inputReader.InputHorizontal * Time.deltaTime * _speed, _inputReader.InputVertical * Time.deltaTime * _speed, 0, Space.World);
    }
}

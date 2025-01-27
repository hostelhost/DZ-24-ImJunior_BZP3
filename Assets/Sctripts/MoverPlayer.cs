using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerAnimatorData _playerAnimatorData;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _speed = 5.0f;

    private void Update()
    {
        ManageAnimator();

        transform.Translate(_inputManager.InputHorizontal * Time.deltaTime * _speed, _inputManager.InputVertical * Time.deltaTime * _speed, 0, Space.World);
    }

    private void ManageAnimator()
    {
        _animator.SetFloat(_playerAnimatorData.HorizonalAxisID, _inputManager.InputHorizontal);
        _animator.SetFloat(_playerAnimatorData.VerticalAxisID, _inputManager.InputVertical);
    }
}

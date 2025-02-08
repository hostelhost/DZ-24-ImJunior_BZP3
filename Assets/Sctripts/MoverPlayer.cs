using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _speed = 5.0f;

    private PlayerAnimatorData _animatorData = new PlayerAnimatorData();

    private void Update()
    {
        ManageAnimator();

        transform.Translate(_inputManager.InputHorizontal * Time.deltaTime * _speed, _inputManager.InputVertical * Time.deltaTime * _speed, 0, Space.World);
    }

    private void ManageAnimator()
    {
        _animator.SetFloat(_animatorData.HorizonalAxisID, _inputManager.InputHorizontal);
        _animator.SetFloat(_animatorData.VerticalAxisID, _inputManager.InputVertical);
    }
}

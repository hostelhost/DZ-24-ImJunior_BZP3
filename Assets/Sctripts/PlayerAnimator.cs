using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private PlayerAnimatorData _animatorData = new PlayerAnimatorData();

    private void Update()
    {
        ManageAnimator();
    }

    private void ManageAnimator()
    {
        _animator.SetFloat(_animatorData.HorizonalAxisID, _inputReader.InputHorizontal);
        _animator.SetFloat(_animatorData.VerticalAxisID, _inputReader.InputVertical);
    }
}

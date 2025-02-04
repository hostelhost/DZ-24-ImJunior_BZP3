using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderDisplay : MonoBehaviour, IDisplayHealth
{
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _delayTime = 0.03f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public void Initialization(int maximumLifeForce)
    {
        _smoothSlider.maxValue = maximumLifeForce;
        _smoothSlider.value = maximumLifeForce;
        _waitForSeconds = new WaitForSeconds(_delayTime);
    }

    public void Print(int lifeForce)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothSlide(lifeForce));
    }

    private IEnumerator SmoothSlide(int lifeForce)
    {
        while (_smoothSlider.value != lifeForce)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, lifeForce, _speed);
            yield return _waitForSeconds;
        }
    }
}

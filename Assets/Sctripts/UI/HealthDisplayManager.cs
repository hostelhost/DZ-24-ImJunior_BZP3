using UnityEngine;

public class HealthDisplayManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthTextDisplay _healthTextDisplay;
    [SerializeField] private HealthSmoothSliderDisplay _healthSmoothSliderDisplay;

    private int _maximumLifeForce;

    private void Start()
    {
        Initialization();
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += Print;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= Print;
    }

    private void Initialization()
    {
        _maximumLifeForce = _health.GetMaximumLifeForce();
        _healthTextDisplay.Print(_health.LifeForce, _maximumLifeForce);
        _healthSmoothSliderDisplay.Initialization(_maximumLifeForce);
    }

    private void Print()
    {
        _healthTextDisplay.Print(_health.LifeForce, _maximumLifeForce);
        _healthSmoothSliderDisplay.StartSmoothSlide(_health.LifeForce);
    }
}

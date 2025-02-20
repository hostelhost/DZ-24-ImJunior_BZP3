using UnityEngine;

public class HealthDisplayUserInterface : MonoBehaviour
{
    [SerializeField] private Health _health;
    private IDisplayHealth[] _displayHealths;

    private void Start()
    {
        _displayHealths = GetComponents<IDisplayHealth>();
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
        foreach (IDisplayHealth displayHealth in _displayHealths)
        {
            displayHealth.Initialization(_health.GetMaximumLifeForce());
            displayHealth.Print(_health.LifeForce);
        }
    }

    private void Print()
    {
        foreach (IDisplayHealth displayHealth in _displayHealths)
            displayHealth.Print(_health.LifeForce);
    }
}

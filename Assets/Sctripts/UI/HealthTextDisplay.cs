using TMPro;
using UnityEngine;

public class HealthTextDisplay : MonoBehaviour, IDisplayHealth
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _maximumLifeForce;

    public void Initialization(int maximumLifeForce)
    {
        _maximumLifeForce = maximumLifeForce;
    }

    public void Print(int lifeForce)
    {
        _text.text = $"{lifeForce}/{_maximumLifeForce}";
    }
}

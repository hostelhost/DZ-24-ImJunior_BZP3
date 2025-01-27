using TMPro;
using UnityEngine;

public class HealthTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Print(int lifeForce, int maximumLifeForce)
    {
        _text.text = $"{lifeForce}/{maximumLifeForce}";
    }
}

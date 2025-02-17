using TMPro;
using UnityEngine;

public class CoinTextDisplay : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _bag.ValueChanged += Print;
    }

    private void OnDisable()
    {
        _bag.ValueChanged -= Print;
    }

    public void Print()
    {
        _text.text = $"Coin - {_bag.CoinCount}";
    }
}
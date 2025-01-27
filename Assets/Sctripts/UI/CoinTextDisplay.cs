using TMPro;
using UnityEngine;

public class CoinTextDisplay : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _bag.NumberCoinHasChanged += Print;
    }

    private void OnDisable()
    {
        _bag.NumberCoinHasChanged -= Print;
    }

    public void Print()
    {
        _text.text = $"Coin - {_bag.CoinCount}";
    }
}
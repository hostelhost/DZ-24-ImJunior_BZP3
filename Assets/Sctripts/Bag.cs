using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public event Action ValueChanged;

    public int CoinCount { get; private set; }

    public void TakeCoin(int coin)
    {
        CoinCount += coin;

        ValueChanged?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GemCurrency", menuName = "Currency/gemCurrency")]
public class GemCurrency : CurrencyBase
{
    public override void DecreaseCurrency(int cost)
    {
        if (Amount >= cost)
        {
            MinusAmount(cost);

            RaiseEvent();
        }
    }
}

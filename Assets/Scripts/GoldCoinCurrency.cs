using UnityEngine;

[CreateAssetMenu(fileName = "GoldCoinCurrency", menuName = "Currency/GoldCoinCurrency")]
public class GoldCoinCurrency : CurrencyBase
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

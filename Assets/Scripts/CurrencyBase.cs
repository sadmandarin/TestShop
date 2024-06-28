using System;
using UnityEngine;


public abstract class CurrencyBase : ScriptableObject
{
    [SerializeField] private string _currencyName;
    [SerializeField] private int _amount;
    [SerializeField] private Sprite _currencyImage;

    public event Action AmountChanged;

    public Sprite CurrencyImage { get { return _currencyImage; } }

    public string CurrencyName {  get { return _currencyName; } }

    public int Amount { get { return _amount; } set { _amount = value; } }

    public abstract void DecreaseCurrency(int cost);

    protected void RaiseEvent()
    {
        AmountChanged?.Invoke();
    }

    protected void MinusAmount(int cost)
    {
        _amount -= cost;
    }
}

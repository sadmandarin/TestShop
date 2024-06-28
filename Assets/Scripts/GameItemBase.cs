using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItemBase : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemIcon;
    [SerializeField] private List <PurchaseOption> _purchaseOption;
    [SerializeField] private bool _isLocked;
    [SerializeField] private bool _isLimitedTime;

    [Tooltip("¬ведите врем€ в секундах")]
    [ConditionalField("_isLimitedTime")]
    [SerializeField] private int _timeLimit;

    public string ItemName { get { return _itemName; } }

    public Sprite ItemIcon { get { return _itemIcon; } } 
    public List<PurchaseOption> PurchaseOptions { get { return _purchaseOption; } }

    public bool IsLocked {  get { return _isLocked; }  set { _isLocked = value; } }

    public bool IsLimitedTime { get { return _isLimitedTime; } set { _isLimitedTime = value; } }

    public int TimeLimit { get { return _timeLimit; } set { _timeLimit = value; } }

    public event Action OnUnlockItem;

    public abstract void UseItem();

    public abstract void EventHandler();

    public abstract void ReducingTime();

    public void UnlockItem()
    {
        _isLocked = false;
    }

    protected void OnChangeLockedStatus()
    {
        OnUnlockItem?.Invoke();
    }
}

[System.Serializable]
public class PurchaseOption
{
    public CurrencyBase Currency;
    public int Cost;
}

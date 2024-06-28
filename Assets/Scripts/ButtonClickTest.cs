using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickTest : MonoBehaviour
{
    private Button _button;
    private PurchaseOption _purchaseOption;

    [SerializeField] private Text _itemCost;

    [SerializeField] private SetItemBox _itemBox;

    public PurchaseOption PurchaseOption { get { return _purchaseOption; } set { _purchaseOption = value; } }

    public Text ItemCost {  get { return _itemCost; } set { _itemCost = value; } }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Decrease);
        _itemCost.text = _purchaseOption.Cost.ToString();
    }

    private void Decrease()
    {
        if (_purchaseOption.Currency.Amount >= _purchaseOption.Cost)
        {
            _purchaseOption.Currency.DecreaseCurrency(_purchaseOption.Cost);

            _itemBox.UnlockItem();
        }
    }
}

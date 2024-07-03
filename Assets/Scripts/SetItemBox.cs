using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItemBox : MonoBehaviour
{
    [SerializeField] private GameItemBase _gameItem;
    [SerializeField] private LimitedAccesView _limitedAccesView;
    [SerializeField] private Text _itemName;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private List<Button> _buyButtons;

    public GameItemBase GameItem {  get { return _gameItem; } }

    private void OnEnable()
    {
        _gameItem.OnUnlockItem += UnlockItem;
        _itemName.text = _gameItem.ItemName;
        _itemSprite.sprite = _gameItem.ItemIcon;
        for (int i = 0; i < _buyButtons.Count; i++)
        {
            _buyButtons[i].GetComponent<ButtonClickTest>().PurchaseOption = _gameItem.PurchaseOptions[i];

            _buyButtons[i].GetComponent<ButtonClickTest>().PurchaseOption.Currency = _gameItem.PurchaseOptions[i].Currency;
        }
    }

    private void OnDisable()
    {
        _gameItem.OnUnlockItem -= UnlockItem;
    }

    public void UnlockItem()
    {
        for (int i = 0; i < _buyButtons.Count; i++)
        {
            _buyButtons[i].interactable = false;

            if (_limitedAccesView.gameObject != null)
            {
                _limitedAccesView.gameObject.SetActive(false);
            }
        }
    }
}

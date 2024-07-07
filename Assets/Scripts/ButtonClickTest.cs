using UnityEngine;
using UnityEngine.UI;

public class ButtonClickTest : MonoBehaviour
{
    private Button _button;
    private PurchaseOption _purchaseOption;

    [SerializeField] private Text _itemCost;

    [SerializeField] private SetItemBox _itemBox;

    public PurchaseOption PurchaseOption { get { return _purchaseOption; } set { _purchaseOption = value; } }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Decrease);
        _button.interactable = _itemBox.GameItem.IsLocked == true ? true : false;
        _itemCost.text = _purchaseOption.Cost.ToString();
    }

    private void Decrease()
    {
        if (_purchaseOption.Currency.Amount >= _purchaseOption.Cost)
        {
            _purchaseOption.Currency.DecreaseCurrency(_purchaseOption.Cost);

            _itemBox.GameItem.UnlockItem();

            _itemBox.GameItem.DeactivateLimitedTime();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _currencyImage;

    [SerializeField] private Text _currencyText;

    [SerializeField] private CurrencyBase _currency;

    private void Start()
    {
        float amount = _currency.Amount;

        _currencyText.text = amount.ToString();
    }

    private void OnEnable()
    {
        _currency.AmountChanged += DisplayAmount;

        _currencyText.text = _currency.Amount.ToString();

        _currencyImage.sprite = _currency.CurrencyImage;
    }

    private void OnDisable()
    {
        _currency.AmountChanged -= DisplayAmount;    
    }

    public void DisplayAmount()
    {
        float amount = _currency.Amount;

        _currencyText.text = amount.ToString();
    }
}

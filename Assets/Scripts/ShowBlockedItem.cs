using UnityEngine;
using UnityEngine.UI;

public class ShowBlockedItem : MonoBehaviour
{
    [SerializeField] SetItemBox _itemBox;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (_itemBox.GameItem.IsLocked == true)
        {
            _image.enabled = true;
        }

        else
        {
            _image.enabled = false;
        }
    }
}

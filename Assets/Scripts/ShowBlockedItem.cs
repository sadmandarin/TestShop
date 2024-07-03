using UnityEngine;
using UnityEngine.UI;

public class ShowBlockedItem : MonoBehaviour
{
    [SerializeField] SetItemBox _itemBox;

    private Image _image;

    private void OnEnable()
    {
        _itemBox.GameItem.OnUnlockItem += HideBlockImage;
    }

    private void Start()
    {
        _image = GetComponent<Image>();

        if (_itemBox.GameItem.IsLocked == true)
            _image.enabled = true;

        else
            _image.enabled = false;
    }

    private void OnDisable()
    {
        _itemBox.GameItem.OnUnlockItem -= HideBlockImage;
    }

    //private void Update()
    //{
    //    if (_itemBox.GameItem.IsLocked == true)
    //    {
    //        _image.enabled = true;
    //    }

    //    else
    //    {
    //        _image.enabled = false;
    //    }
    //}

    void HideBlockImage()
    {
        _image.enabled = false;
    }
}

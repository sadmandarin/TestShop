using System;
using UnityEngine;
using UnityEngine.UI;

public class LimitedAccesView : MonoBehaviour
{
    [SerializeField] private SetItemBox _itemBox;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        if (_itemBox != null)
        {
            if (_itemBox.GameItem != null)
            {
                if (_itemBox.GameItem.IsLimitedTime == true)
                {
                    UpdateTimerText();

                    if (_itemBox.GameItem.TimeLimit >= 1)
                    {
                        InvokeRepeating(nameof(UpdateCountdown), 1f, 1f);
                    }
                }
            }
        }
    }

    private void OnDisable()
    {
        StopInvoke();
    }

    void UpdateCountdown()
    {
        if (_itemBox.GameItem.TimeLimit >= 1)
        {
            _itemBox.GameItem.ReducingTime();

            UpdateTimerText();
        }

        else
        {
            StopInvoke();
        }
    }

    void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(_itemBox.GameItem.TimeLimit / 3600);
        int minutes = Mathf.FloorToInt((_itemBox.GameItem.TimeLimit % 3600) / 60);
        int seconds = Mathf.FloorToInt(_itemBox.GameItem.TimeLimit % 60);
        _text.text = $"Time remaining: {hours:00}:{minutes:00}:{seconds:00}";
    }

    void StopInvoke()
    {
        CancelInvoke(nameof(UpdateCountdown));
    }
}

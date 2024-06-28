using System;
using UnityEngine;
using UnityEngine.UI;

public class LimitedAccesView : MonoBehaviour
{
    [SerializeField] private SetItemBox _timeRemaining;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        if (_timeRemaining != null)
        {
            if (_timeRemaining.GameItem != null)
            {
                if (_timeRemaining.GameItem.IsLimitedTime == true)
                {
                    UpdateTimerText();

                    if (_timeRemaining.GameItem.TimeLimit >= 1)
                    {
                        InvokeRepeating(nameof(UpdateCountdown), 1f, 1f);
                    }
                }
            }
        }
    }

    void UpdateCountdown()
    {
        if (_timeRemaining.GameItem.TimeLimit >= 1)
        {
            _timeRemaining.GameItem.ReducingTime();

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(_timeRemaining.GameItem.TimeLimit / 3600);
        int minutes = Mathf.FloorToInt((_timeRemaining.GameItem.TimeLimit % 3600) / 60);
        int seconds = Mathf.FloorToInt(_timeRemaining.GameItem.TimeLimit % 60);
        _text.text = $"Time remaining: {hours:00}:{minutes:00}:{seconds:00}";
    }

    void StopInvoke()
    {
        CancelInvoke(nameof(UpdateCountdown));
    }
}

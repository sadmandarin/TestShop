using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public IEnumerator SaveGameCoroutine(List<GameItemBase> gameItems, List<CurrencyBase> currencies)
    {
        DateTime moscowTime = DateTime.Now;
        SaveData saveData = new SaveData
        {
            gameItems = new List<GameItemData>(),
            currencies = new List<CurrencyData>(),
            lastExitTime = moscowTime.ToString("yyyy-MM-ddTHH:mm:ss")
        };

        foreach (var item in gameItems)
        {
            saveData.gameItems.Add(new GameItemData
            {
                itemName = item.ItemName,
                isLocked = item.IsLocked,
                timeRemaining = item.TimeLimit,
                isLimitedTime = item.IsLimitedTime
            });
        }

        foreach (var currency in currencies)
        {
            saveData.currencies.Add(new CurrencyData
            {
                currencyName = currency.CurrencyName,
                amount = currency.Amount
            });
        }

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(saveFilePath, json);

        yield return null;
    }
    public SaveData LoadGame()
    {
        if (!File.Exists(saveFilePath))
            return null;

        string json = File.ReadAllText(saveFilePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void GetTimeSinceLastExit(Action<TimeSpan> onSuccess)
    {
        SaveData saveData = LoadGame();
        if (saveData == null || string.IsNullOrEmpty(saveData.lastExitTime))
        {
            onSuccess?.Invoke(TimeSpan.Zero);
            return;
        }

        DateTime moscowTime = DateTime.Parse(saveData.lastExitTime).ToUniversalTime();

        TimeSpan timeSinceLastExit = DateTime.UtcNow - moscowTime;

        onSuccess?.Invoke(timeSinceLastExit);
    }
}

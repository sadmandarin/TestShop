using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameItemBase> gameItems;
    public List<CurrencyBase> currencies;
    private SaveManager saveManager;

    private void OnEnable()
    {
        saveManager = GetComponent<SaveManager>();

        LoadGame();
    }

    private void OnApplicationQuit()
    {
        StartCoroutine(SaveGameAndExitCoroutine());
    }

    private IEnumerator SaveGameAndExitCoroutine()
    {
        yield return StartCoroutine(saveManager.SaveGameCoroutine(gameItems, currencies));
    }

    public void LoadGame()
    {
        saveManager.GetTimeSinceLastExit(timeSinceLastExit =>
        {
            int seconds = (int)timeSinceLastExit.TotalSeconds;

            SaveData saveData = saveManager.LoadGame();
            if (saveData == null)
                return;

            foreach (var itemData in saveData.gameItems)
            {
                var item = gameItems.Find(i => i.ItemName == itemData.itemName);
                if (item != null)
                {
                    item.IsLocked = itemData.isLocked;
                    if (itemData.timeRemaining >= seconds)
                    {
                        item.TimeLimit = itemData.timeRemaining - seconds;
                    }

                    else
                    {
                        item.TimeLimit = 0;
                    }
                    item.IsLimitedTime = itemData.isLimitedTime;
                }
            }

            foreach (var currencyData in saveData.currencies)
            {
                var currency = currencies.Find(c => c.CurrencyName == currencyData.currencyName);
                if (currency != null)
                {
                    currency.Amount = currencyData.amount;
                }
            }

            Debug.Log($"Time since last exit: {timeSinceLastExit}");
        });
    }
}

using System.Collections.Generic;
using System;

[Serializable]
public class SaveData
{
    public List<GameItemData> gameItems;
    public List<CurrencyData> currencies;
    public string lastExitTime;
}

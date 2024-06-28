using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Shop/Items/Sword")]
public class SwordSO : GameItemBase
{
    private int attackPower;

    public override void EventHandler()
    {
        UnlockItem();

        OnChangeLockedStatus();
    }

    public override void ReducingTime()
    {
        TimeLimit --;
    }

    public override void UseItem()
    {
        //Debug.Log($"Using {ItemName} with {attackPower} attack power.");
    }
}
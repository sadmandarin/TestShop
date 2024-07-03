using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Shop/Items/Shield")]
public class Shield : GameItemBase
{
    private float _shieldHP;

    public override void EventHandler()
    {
        throw new System.NotImplementedException();
    }

    public override void ReducingTime()
    {
        TimeLimit --;
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }


}

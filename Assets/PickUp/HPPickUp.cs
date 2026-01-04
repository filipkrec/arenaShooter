using UnityEngine;

public class HPPickUp : WorldPickUpBase
{
    [SerializeField] private float HealAmount;

    public override void OnPickUp(Player _player)
    {
        _player.HP.UpdateHP(HealAmount);
    }

}

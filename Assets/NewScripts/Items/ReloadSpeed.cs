using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ReloadSpeedBuff")]
public class ReloadSpeed : ItemEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerGunStats>().reloadSpeed -= amount;
    }
}
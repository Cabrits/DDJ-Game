using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/AmmoBuff")]
public class AmmoBuff : ItemEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerGunStats>().maxAmmo += amount;
        target.GetComponent<PlayerShoot>().ammo += amount;
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DamageBuff")]
public class DamageBuff : ItemEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerGunStats>().gunDamage += amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/FireRateBuff")]
public class FireRateBuff : ItemEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerGunStats>().fireRate += amount;
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletSpeedBuff")]
public class BulletSpeedBuff : ItemEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerGunStats>().bulletForce += amount;
    }
}



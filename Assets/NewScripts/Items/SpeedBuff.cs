using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : ItemEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerStats>().playerSpeed += amount;
    }
}

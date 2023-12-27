using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealthPotion")]

public class HealthPotion : ItemEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().health += amount;

        if (target.GetComponent<Player>().health > target.GetComponent<Player>().maxHealth)
        {
            target.GetComponent<Player>().health = target.GetComponent<Player>().maxHealth;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealthPotion")]

public class HealthPotion : ItemEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().currentHealth += amount;

        if (target.GetComponent<Health>().currentHealth > target.GetComponent<Health>().maxHealth)
        {
            target.GetComponent<Health>().currentHealth = target.GetComponent<Health>().maxHealth;
        }
    }
}

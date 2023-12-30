using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemEffect itemEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerComponent)) 
        {
            if(itemEffect is HealthPotion)
            {
                collision.gameObject.TryGetComponent<Health>(out Health health);
                if(health.currentHealth == health.maxHealth)
                {

                }
                else
                {
                    Destroy(this.gameObject);
                    itemEffect.Apply(collision.gameObject);
                }
            }
            else
            {
                Destroy(this.gameObject);
                itemEffect.Apply(collision.gameObject);
            }
        }
    }
}

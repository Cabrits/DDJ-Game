using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Item : MonoBehaviour{
    public ItemEffect itemEffect;

    private void OnTriggerEnter2D(Collider2D collision){

        GameObject player = collision.gameObject;
        
        if (player.TryGetComponent<PlayerStats>(out PlayerStats playerStats)) {
            if(itemEffect is HealthPotion){
                player.TryGetComponent<Health>(out Health health);
                if(health.currentHealth == health.maxHealth)
                {

                }
                else
                {
                    Destroy(this.gameObject);
                    itemEffect.Apply(player);
                }
            }
            else{
                Destroy(this.gameObject);
                itemEffect.Apply(player);

                player.GetComponent<PlayerGrowth>().Grow(player);
                playerStats.powerUpCount += 1;
            }
        }
    }
}

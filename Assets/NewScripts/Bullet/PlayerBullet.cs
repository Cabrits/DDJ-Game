using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour{

    public int damage = 10;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().gunDamage;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            
            Destroy(gameObject);
        }

    }
}
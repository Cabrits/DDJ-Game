using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Health>().takeDamage(damage);
            
            Destroy(gameObject);
        }

    }
}


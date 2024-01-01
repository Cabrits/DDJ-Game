using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public GameObject target;
    public float speed;
    public float timeAlive;
    public int damage;
    Rigidbody2D rb;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Bullet")){
            
        }
        else if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall")){
            Destroy(this.gameObject);
        }

    }
}

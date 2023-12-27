using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int maxHealth;
    public int health;
    [Range(1, 10)] public float speed;
    public Transform target;
    public float lineOfSite;
    public int damage;

    protected virtual void Start()
    {
        maxHealth = 50;
        lineOfSite = 6;
        health = maxHealth;
        damage = 10;
        speed = 3;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void FixedUpdate()
    {
        //If its in range it will start follow the target
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position); // When player goes near enemy
        if (distanceFromPlayer < lineOfSite)
        {

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}

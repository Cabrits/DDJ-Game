using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPlayer : MonoBehaviour{

    public GameObject enemyObject;
    public float lineOfSite;
    private Transform target;
    private float speed;

    void Start(){
        target = enemyObject.GetComponent<Enemy>().target;
    }
    void Update(){
        speed = enemyObject.GetComponent<Enemy>().enemySpeed;
    }

   protected virtual void FixedUpdate(){
        //If its in range it will start follow the target
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position); // When player goes near enemy
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public virtual void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}

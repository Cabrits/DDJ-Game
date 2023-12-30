using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIFollowAndShoot : MonoBehaviour
{
    
    public float speed;
    public int enemyDamage;
    public Transform target;
    public float lineOfSite;
    public float shootingRange; // Range to Start shooting
    public float fireRate;
    public float ReloadSpeed;
    public int MaxAmmo;
    public int ammo;

    private float nextFireTime;

    public GameObject bullet;
    public GameObject firePoint;

    



    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ammo = MaxAmmo;
    }

    void FixedUpdate()
    {
        // It will follow until a certain point and then starts shooting
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
            transform.right = target.position - transform.position;
        }
        else if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            transform.right = target.position - transform.position;
            GameObject bulletObject = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            ammo -= 1;
            if(ammo == 0)
            {
                nextFireTime = Time.time + ReloadSpeed;
                ammo = MaxAmmo;
            }
            else
            {
                nextFireTime = Time.time + (1 / fireRate);
            }
        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Shooter : EnemyBase
{
    public float shootingRange; // Range to Start shooting
    public float fireRate;
    public float ReloadSpeed;
    public int MaxAmmo;
    public int ammo;

    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    protected override void Start()
    {
        //Base Stats
        //maxHealth = 50;
        //lineOfSite = 6;
        //health = maxHealth;
        //damage = 10;
        //speed = 3;

        //Shooter Stats
        //shootingRange = 2;
        //fireRate = 2;
        //ReloadSpeed = 5;
        //MaxAmmo = 2;
        ammo = MaxAmmo;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        // It will follow until a certain point and then starts shooting
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            GameObject bulletObject = Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
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

    new void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}

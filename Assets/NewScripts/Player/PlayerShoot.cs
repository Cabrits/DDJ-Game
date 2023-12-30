using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPrefab;

    private float nextFireTime;

    private float bulletForce;
    private int maxAmmo;
    public int ammo;
    private float fireRate;
    private float reloadSpeed;

    void Start(){
        maxAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().maxAmmo;
        ammo = maxAmmo;
    }

    void Update(){
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if(Input.GetKeyDown("r")){
            if(maxAmmo != ammo){
                nextFireTime = Time.time + reloadSpeed;
                ammo = maxAmmo;

                Debug.Log("Reloading");
            }
        }

        bulletForce = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().bulletForce;
        maxAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().maxAmmo;
        fireRate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().fireRate;
        reloadSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().reloadSpeed;
    }

    void Shoot(){
        if(nextFireTime < Time.time)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            //rb.velocity = firePoint.up * bulletForce;

            Destroy(bullet, 2);

            ammo -= 1;
            if (ammo == 0)
            {
                nextFireTime = Time.time + reloadSpeed;
                ammo = maxAmmo;
            }
            else
            {
                nextFireTime = Time.time + (1 / fireRate);
            }
        }
    }
}

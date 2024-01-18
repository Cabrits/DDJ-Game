using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShoot : MonoBehaviour{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public TextMeshProUGUI ammoText;
    public Image loadingCircle;

    private float nextFireTime;

    private bool isInventoryOpen = false;


    private float bulletForce;
    private int maxAmmo;
    public int ammo;
    private float fireRate;
    private float reloadSpeed;

    public AudioSource audioSource;

    private Vector2 mousePos;

    public Camera cam;

    void Start(){
        maxAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunStats>().maxAmmo;
        ammo = maxAmmo;
    }

    void Update(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(nextFireTime < Time.time){
            changeAmmoDisplay();
        }

        if (!isInventoryOpen){

            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
        }

        if(Input.GetKeyDown("r")){
            if(maxAmmo > ammo){
                ammoText.text = "Reloading...";
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
        if(nextFireTime < Time.time){
            audioSource.Play();
            changeAmmoDisplay();

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (mousePos - rb.position).normalized;
            rb.rotation = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            rb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

            Destroy(bullet, 2);

            ammo -= 1;
            if (ammo == 0)
            {
                ammoText.text = "Reloading...";
                nextFireTime = Time.time + reloadSpeed;
                ammo = maxAmmo;
            }
            else
            {
                nextFireTime = Time.time + (1 / fireRate);
            }
        }
    }

    void changeAmmoDisplay(){
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + ammo.ToString();
        }
    }
}

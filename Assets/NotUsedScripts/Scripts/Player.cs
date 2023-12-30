using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField]
    [Range(5,20)]
    public float playerSpeed;

    public int gunDamage;

    private Rigidbody2D rb;

    private Vector2 moveDirection;

    public int health;
    public int maxHealth;

    public Camera cam;
    private Vector2 mousePos;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private float nextFireTime;
    public int ammo;
    public int maxAmmo;
    public float fireRate;
    public float reloadSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ammo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; //normalized  faz com que o player se mova sempre na mesma velocidade (vertical, horizontal e diagonal)

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; //Mathf.Atan2 calcula o angulo em radianos - Mathf.Rad2Deg converte de radianos para graus
        rb.rotation = angle;
    }

    public void TakeDamage(int damageAmount)
    {

        Debug.Log("HIT");
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        if(nextFireTime < Time.time)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            //rb.velocity = firePoint.up * bulletForce;

            Destroy(bullet, 3);

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

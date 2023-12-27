using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField]
    [Range(5,20)]
    public float playerSpeed;

    private Rigidbody2D rb;

    float movex;
    float movey;

    public int health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");
        movey = Input.GetAxisRaw("Vertical");
       
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movex * playerSpeed, movey * playerSpeed);
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


}

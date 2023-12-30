// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class UserInGame : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;
//     public HealthBar healthBar; //add
//     // Start is called before the first frame update
//     void Start()
//     {
//         healthBar.SetMaxHealth(maxHealth);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         maxHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().maxHealth;
//         healthBar.SetHealth(currentHealth);
//     }
// }

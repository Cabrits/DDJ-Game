using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healtha : MonoBehaviour{

    public int maxHealth = 3;
    public int currentHealth;

    [SerializeField] protected int damage;

    void Start(){
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
    }



}

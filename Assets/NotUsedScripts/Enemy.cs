using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public int enemyDamage;
    public Transform target;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

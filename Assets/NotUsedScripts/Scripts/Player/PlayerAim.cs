using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAima : MonoBehaviour{

    [SerializeField] public Rigidbody2D rb;
    public Camera cam;

    private Vector2 mousePos;

    void Update(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; //Mathf.Atan2 calcula o angulo em radianos - Mathf.Rad2Deg converte de radianos para graus
        rb.rotation = angle;
    }
}

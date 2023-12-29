using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    [SerializeField] public float moveSpeed;
    [SerializeField] public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; //normalized  faz com que o player se mova sempre na mesma velocidade (vertical, horizontal e diagonal)
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}

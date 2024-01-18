using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    [SerializeField] public Rigidbody2D rb;
    private Vector2 moveDirection;

    public AudioSource audioSource;
    private bool isInventoryOpen = false;
    public GameObject uiInventory;

    void Update(){
        if (!isInventoryOpen){
            HandleMovement();

            if(moveDirection.x != 0 || moveDirection.y != 0){
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }
            } else{
                audioSource.Stop();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.I)){
            ToggleInventory();
        }
    }

    void FixedUpdate(){
        if (!isInventoryOpen){
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void ToggleInventory(){
        isInventoryOpen = !isInventoryOpen;

        uiInventory.SetActive(isInventoryOpen);
        rb.velocity = Vector2.zero;
    }

    void HandleMovement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerSpeed;

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

}



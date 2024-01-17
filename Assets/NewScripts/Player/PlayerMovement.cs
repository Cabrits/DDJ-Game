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

    private bool isDashing = false;
    private float dashTime = 0.2f;
    private float dashTimer = 0f;
    private bool canDash = true;
    private float dashCooldown = 1f; // Set the cooldown time as needed

    void Update()
    {
        if (!isInventoryOpen){
            HandleMovement();
            HandleDash();
            
            if(moveDirection.x != 0 || moveDirection.y != 0){
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }
            } else {
                audioSource.Stop();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void FixedUpdate()
    {
        if (!isInventoryOpen)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        uiInventory.SetActive(isInventoryOpen);
        rb.velocity = Vector2.zero;
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerSpeed;

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void HandleDash()
    {
        if (canDash && Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                canDash = false;
                StartCoroutine(DashCooldown());
                // You can add additional logic after the dash ends
            }
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        dashTimer = dashTime;
        float dashDistance = 5f;

        Vector2 dashDirection = moveDirection.normalized;
        Vector2 dashTarget = (Vector2)transform.position + dashDirection * dashDistance;

        while (isDashing)
        {
            transform.position = Vector2.MoveTowards(transform.position, dashTarget, dashDistance * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
